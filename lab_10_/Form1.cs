using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TwoPaneFileManager
{
    public partial class Form1 : Form
    {
        string leftCurrentPath = "";
        string rightCurrentPath = "";
        bool lastFocusedLeft = true;
        int key = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillLeft();
            fillRight();
            btnCopy.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtLeftPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLeftGo_Click(sender, e);
        }

        private void txtRightPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnRightGo_Click(sender, e);
        }

        private void fillLeft()
        {
            lstLeft.Items.Clear();
            txtLeftPath.Text = "This PC";
            leftCurrentPath = "";
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable || drive.DriveType == DriveType.Network)
                    lstLeft.Items.Add(drive.Name);
            }
        }

        private void fillRight()
        {
            lstRight.Items.Clear();
            txtRightPath.Text = "This PC";
            rightCurrentPath = "";
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable || drive.DriveType == DriveType.Network)
                    lstRight.Items.Add(drive.Name);
            }
        }

        private void loadLeft(string path)
        {
            lstLeft.Items.Clear();
            lstLeft.Items.Add(".");
            lstLeft.Items.Add("..");
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (DirectoryInfo sub in dir.GetDirectories())
                lstLeft.Items.Add("[DIR] " + sub.Name);
            foreach (FileInfo file in dir.GetFiles())
                lstLeft.Items.Add("      " + file.Name);
            txtLeftPath.Text = path;
            leftCurrentPath = path;
        }

        private void loadRight(string path)
        {
            lstRight.Items.Clear();
            lstRight.Items.Add(".");
            lstRight.Items.Add("..");
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (DirectoryInfo sub in dir.GetDirectories())
                lstRight.Items.Add("[DIR] " + sub.Name);
            foreach (FileInfo file in dir.GetFiles())
                lstRight.Items.Add("      " + file.Name);
            txtRightPath.Text = path;
            rightCurrentPath = path;
        }

        private void lstLeft_DoubleClick(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItem == null) return;
            string item = lstLeft.SelectedItem.ToString();

            if (item == ".")
            {
                if (string.IsNullOrEmpty(leftCurrentPath)) return;
                string parent = Path.GetDirectoryName(leftCurrentPath);
                if (string.IsNullOrEmpty(parent))
                    fillLeft();
                else
                    loadLeft(parent);
                return;
            }

            if (item == "..")
            {
                fillLeft();
                return;
            }

            if (string.IsNullOrEmpty(leftCurrentPath))
            {
                loadLeft(item);
                return;
            }

            if (item.StartsWith("[DIR] "))
            {
                string folderName = item.Substring(6);
                loadLeft(Path.Combine(leftCurrentPath, folderName));
                return;
            }

            string fileName = item.TrimStart();
            string filePath = Path.Combine(leftCurrentPath, fileName);
            DialogResult dr = MessageBox.Show("'" + fileName + "' is a file. Do you want to open it?", "Open File", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try { System.Diagnostics.Process.Start(filePath); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void lstRight_DoubleClick(object sender, EventArgs e)
        {
            if (lstRight.SelectedItem == null) return;
            string item = lstRight.SelectedItem.ToString();

            if (item == ".")
            {
                if (string.IsNullOrEmpty(rightCurrentPath)) return;
                string parent = Path.GetDirectoryName(rightCurrentPath);
                if (string.IsNullOrEmpty(parent))
                    fillRight();
                else
                    loadRight(parent);
                return;
            }

            if (item == "..")
            {
                fillRight();
                return;
            }

            if (string.IsNullOrEmpty(rightCurrentPath))
            {
                loadRight(item);
                return;
            }

            if (item.StartsWith("[DIR] "))
            {
                string folderName = item.Substring(6);
                loadRight(Path.Combine(rightCurrentPath, folderName));
                return;
            }

            string fileName = item.TrimStart();
            string filePath = Path.Combine(rightCurrentPath, fileName);
            DialogResult dr = MessageBox.Show("'" + fileName + "' is a file. Do you want to open it?", "Open File", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try { System.Diagnostics.Process.Start(filePath); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void lstLeft_Click(object sender, EventArgs e)
        {
            lastFocusedLeft = true;
            btnCopy.Enabled = lstLeft.SelectedItem != null;
            btnDelete.Enabled = lstLeft.SelectedItem != null;
        }

        private void lstRight_Click(object sender, EventArgs e)
        {
            lastFocusedLeft = false;
            btnCopy.Enabled = lstRight.SelectedItem != null;
            btnDelete.Enabled = lstRight.SelectedItem != null;
        }

        private void btnLeftGo_Click(object sender, EventArgs e)
        {
            string path = txtLeftPath.Text.Trim();
            if (string.IsNullOrEmpty(path) || path == "This PC") { fillLeft(); return; }
            if (path.Length == 1) path = path.ToUpper() + @":\";
            if (path.Length == 2 && path[1] == ':') path = path.ToUpper() + @"\";
            if (Directory.Exists(path))
                loadLeft(path);
            else
                MessageBox.Show("Path not found: " + path);
        }

        private void btnRightGo_Click(object sender, EventArgs e)
        {
            string path = txtRightPath.Text.Trim();
            if (string.IsNullOrEmpty(path) || path == "This PC") { fillRight(); return; }
            if (path.Length == 1) path = path.ToUpper() + @":\";
            if (path.Length == 2 && path[1] == ':') path = path.ToUpper() + @"\";
            if (Directory.Exists(path))
                loadRight(path);
            else
                MessageBox.Show("Path not found: " + path);
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            if (lstLeft.SelectedItem == null) { MessageBox.Show("Select an item from the left pane."); return; }
            if (string.IsNullOrEmpty(leftCurrentPath) || string.IsNullOrEmpty(rightCurrentPath)) { MessageBox.Show("Both panes must be inside a folder."); return; }

            string item = lstLeft.SelectedItem.ToString();
            if (item == "." || item == "..") return;

            string name = item.StartsWith("[DIR] ") ? item.Substring(6) : item.TrimStart();
            string src = Path.Combine(leftCurrentPath, name);
            string dst = Path.Combine(rightCurrentPath, name);

            try
            {
                if (Directory.Exists(src)) Directory.Move(src, dst);
                else File.Move(src, dst);
                loadLeft(leftCurrentPath);
                loadRight(rightCurrentPath);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (lstRight.SelectedItem == null) { MessageBox.Show("Select an item from the right pane."); return; }
            if (string.IsNullOrEmpty(leftCurrentPath) || string.IsNullOrEmpty(rightCurrentPath)) { MessageBox.Show("Both panes must be inside a folder."); return; }

            string item = lstRight.SelectedItem.ToString();
            if (item == "." || item == "..") return;

            string name = item.StartsWith("[DIR] ") ? item.Substring(6) : item.TrimStart();
            string src = Path.Combine(rightCurrentPath, name);
            string dst = Path.Combine(leftCurrentPath, name);

            try
            {
                if (Directory.Exists(src)) Directory.Move(src, dst);
                else File.Move(src, dst);
                loadLeft(leftCurrentPath);
                loadRight(rightCurrentPath);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
   
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (lastFocusedLeft)
            {
                if (lstLeft.SelectedItem == null) { MessageBox.Show("Select an item to copy."); return; }
                if (string.IsNullOrEmpty(leftCurrentPath) || string.IsNullOrEmpty(rightCurrentPath)) { MessageBox.Show("Both panes must be inside a folder."); return; }

                string item = lstLeft.SelectedItem.ToString();
                if (item == "." || item == "..") return;

                string name = item.StartsWith("[DIR] ") ? item.Substring(6) : item.TrimStart();
                string src = Path.Combine(leftCurrentPath, name);
                string dst = Path.Combine(rightCurrentPath, name);

                try
                {
                    if (Directory.Exists(src)) copyFolder(src, dst);
                    else File.Copy(src, dst, true);
                    loadRight(rightCurrentPath);
                    MessageBox.Show("Copied Successfully");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                if (lstRight.SelectedItem == null) { MessageBox.Show("Select an item to copy."); return; }
                if (string.IsNullOrEmpty(leftCurrentPath) || string.IsNullOrEmpty(rightCurrentPath)) { MessageBox.Show("Both panes must be inside a folder."); return; }

                string item = lstRight.SelectedItem.ToString();
                if (item == "." || item == "..") return;

                string name = item.StartsWith("[DIR] ") ? item.Substring(6) : item.TrimStart();
                string src = Path.Combine(rightCurrentPath, name);
                string dst = Path.Combine(leftCurrentPath, name);

                try
                {
                    if (Directory.Exists(src)) copyFolder(src, dst);
                    else File.Copy(src, dst, true);
                    loadLeft(leftCurrentPath);
                    MessageBox.Show("Copied Successfully");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void copyFolder(string source, string dest)
        {
            Directory.CreateDirectory(dest);
            foreach (string file in Directory.GetFiles(source))
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)), true);
            foreach (string dir in Directory.GetDirectories(source))
                copyFolder(dir, Path.Combine(dest, Path.GetFileName(dir)));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lastFocusedLeft)
            {
                if (lstLeft.SelectedItem == null) { MessageBox.Show("Select an item to delete."); return; }
                if (string.IsNullOrEmpty(leftCurrentPath)) { MessageBox.Show("Cannot delete drives."); return; }

                string item = lstLeft.SelectedItem.ToString();
                if (item == "." || item == "..") return;

                string name = item.StartsWith("[DIR] ") ? item.Substring(6) : item.TrimStart();
                string fullPath = Path.Combine(leftCurrentPath, name);

                DialogResult dr = MessageBox.Show("Are you sure you want to delete '" + name + "'?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (Directory.Exists(fullPath)) Directory.Delete(fullPath, true);
                        else File.Delete(fullPath);
                        loadLeft(leftCurrentPath);
                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            else
            {
                if (lstRight.SelectedItem == null) { MessageBox.Show("Select an item to delete."); return; }
                if (string.IsNullOrEmpty(rightCurrentPath)) { MessageBox.Show("Cannot delete drives."); return; }

                string item = lstRight.SelectedItem.ToString();
                if (item == "." || item == "..") return;

                string name = item.StartsWith("[DIR] ") ? item.Substring(6) : item.TrimStart();
                string fullPath = Path.Combine(rightCurrentPath, name);

                DialogResult dr = MessageBox.Show("Are you sure you want to delete '" + name + "'?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        if (Directory.Exists(fullPath)) Directory.Delete(fullPath, true);
                        else File.Delete(fullPath);
                        loadRight(rightCurrentPath);
                        MessageBox.Show("Deleted Successfully");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (lastFocusedLeft)
            {
                if (string.IsNullOrEmpty(leftCurrentPath)) { MessageBox.Show("Navigate into a folder first."); return; }
                string name = Interaction.InputBox("Enter folder name:", "New Folder", "NewFolder");
                if (string.IsNullOrWhiteSpace(name)) return;
                try
                {
                    Directory.CreateDirectory(Path.Combine(leftCurrentPath, name));
                    loadLeft(leftCurrentPath);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                if (string.IsNullOrEmpty(rightCurrentPath)) { MessageBox.Show("Navigate into a folder first."); return; }
                string name = Interaction.InputBox("Enter folder name:", "New Folder", "NewFolder");
                if (string.IsNullOrWhiteSpace(name)) return;
                try
                {
                    Directory.CreateDirectory(Path.Combine(rightCurrentPath, name));
                    loadRight(rightCurrentPath);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
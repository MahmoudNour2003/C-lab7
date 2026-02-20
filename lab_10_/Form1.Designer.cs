namespace TwoPaneFileManager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtLeftPath = new System.Windows.Forms.TextBox();
            this.btnLeftGo = new System.Windows.Forms.Button();
            this.lstLeft = new System.Windows.Forms.ListBox();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.txtRightPath = new System.Windows.Forms.TextBox();
            this.btnRightGo = new System.Windows.Forms.Button();
            this.lstRight = new System.Windows.Forms.ListBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtLeftPath
            this.txtLeftPath.Location = new System.Drawing.Point(12, 12);
            this.txtLeftPath.Size = new System.Drawing.Size(255, 22);
            this.txtLeftPath.Text = "This PC";
            this.txtLeftPath.Name = "txtLeftPath";
            this.txtLeftPath.TabIndex = 0;
            this.txtLeftPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLeftPath_KeyDown);

            // btnLeftGo
            this.btnLeftGo.Location = new System.Drawing.Point(272, 10);
            this.btnLeftGo.Size = new System.Drawing.Size(45, 25);
            this.btnLeftGo.Text = "GO";
            this.btnLeftGo.Name = "btnLeftGo";
            this.btnLeftGo.TabIndex = 1;
            this.btnLeftGo.Click += new System.EventHandler(this.btnLeftGo_Click);

            // lstLeft
            this.lstLeft.Location = new System.Drawing.Point(12, 42);
            this.lstLeft.Size = new System.Drawing.Size(300, 368);
            this.lstLeft.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstLeft.Name = "lstLeft";
            this.lstLeft.TabIndex = 2;
            this.lstLeft.DoubleClick += new System.EventHandler(this.lstLeft_DoubleClick);
            this.lstLeft.Click += new System.EventHandler(this.lstLeft_Click);

            // btnMoveRight >>
            this.btnMoveRight.Location = new System.Drawing.Point(320, 170);
            this.btnMoveRight.Size = new System.Drawing.Size(45, 30);
            this.btnMoveRight.Text = ">>";
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.TabIndex = 3;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);

            // btnMoveLeft <<
            this.btnMoveLeft.Location = new System.Drawing.Point(320, 210);
            this.btnMoveLeft.Size = new System.Drawing.Size(45, 30);
            this.btnMoveLeft.Text = "<<";
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.TabIndex = 4;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);

            // txtRightPath
            this.txtRightPath.Location = new System.Drawing.Point(372, 12);
            this.txtRightPath.Size = new System.Drawing.Size(255, 22);
            this.txtRightPath.Text = "This PC";
            this.txtRightPath.Name = "txtRightPath";
            this.txtRightPath.TabIndex = 5;
            this.txtRightPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRightPath_KeyDown);

            // btnRightGo
            this.btnRightGo.Location = new System.Drawing.Point(632, 10);
            this.btnRightGo.Size = new System.Drawing.Size(45, 25);
            this.btnRightGo.Text = "GO";
            this.btnRightGo.Name = "btnRightGo";
            this.btnRightGo.TabIndex = 6;
            this.btnRightGo.Click += new System.EventHandler(this.btnRightGo_Click);

            // lstRight
            this.lstRight.Location = new System.Drawing.Point(372, 42);
            this.lstRight.Size = new System.Drawing.Size(300, 368);
            this.lstRight.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstRight.Name = "lstRight";
            this.lstRight.TabIndex = 7;
            this.lstRight.DoubleClick += new System.EventHandler(this.lstRight_DoubleClick);
            this.lstRight.Click += new System.EventHandler(this.lstRight_Click);

            // btnCopy
            this.btnCopy.Location = new System.Drawing.Point(130, 426);
            this.btnCopy.Size = new System.Drawing.Size(110, 35);
            this.btnCopy.Text = "COPY";
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(280, 426);
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnNew
            this.btnNew.Location = new System.Drawing.Point(430, 426);
            this.btnNew.Size = new System.Drawing.Size(110, 35);
            this.btnNew.Text = "NEW";
            this.btnNew.Name = "btnNew";
            this.btnNew.TabIndex = 10;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 475);
            this.MinimumSize = new System.Drawing.Size(690, 475);
            this.Text = "Two Pane File Manager";
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtLeftPath,  this.btnLeftGo,  this.lstLeft,
                this.btnMoveRight, this.btnMoveLeft,
                this.txtRightPath, this.btnRightGo, this.lstRight,
                this.btnCopy,      this.btnDelete,  this.btnNew
            });

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtLeftPath;
        private System.Windows.Forms.TextBox txtRightPath;
        private System.Windows.Forms.ListBox lstLeft;
        private System.Windows.Forms.ListBox lstRight;
        private System.Windows.Forms.Button btnLeftGo;
        private System.Windows.Forms.Button btnRightGo;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
    }
}
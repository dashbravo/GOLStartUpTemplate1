namespace GOLStartUpTemplate1
{
    partial class ModalDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1Seed = new System.Windows.Forms.Label();
            this.numericUpDown1Seed = new System.Windows.Forms.NumericUpDown();
            this.button1Cancel = new System.Windows.Forms.Button();
            this.button1OK = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1Seed)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1Seed);
            this.panel1.Controls.Add(this.numericUpDown1Seed);
            this.panel1.Controls.Add(this.button1Cancel);
            this.panel1.Controls.Add(this.button1OK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 213);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1Seed
            // 
            this.label1Seed.AutoSize = true;
            this.label1Seed.Location = new System.Drawing.Point(117, 62);
            this.label1Seed.Name = "label1Seed";
            this.label1Seed.Size = new System.Drawing.Size(32, 13);
            this.label1Seed.TabIndex = 3;
            this.label1Seed.Text = "Seed";
            this.label1Seed.Click += new System.EventHandler(this.label1Seed_Click);
            // 
            // numericUpDown1Seed
            // 
            this.numericUpDown1Seed.Location = new System.Drawing.Point(155, 58);
            this.numericUpDown1Seed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1Seed.Name = "numericUpDown1Seed";
            this.numericUpDown1Seed.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1Seed.TabIndex = 2;
            this.numericUpDown1Seed.ValueChanged += new System.EventHandler(this.numericUpDown1Seed_ValueChanged);
            // 
            // button1Cancel
            // 
            this.button1Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1Cancel.Location = new System.Drawing.Point(263, 178);
            this.button1Cancel.Name = "button1Cancel";
            this.button1Cancel.Size = new System.Drawing.Size(75, 23);
            this.button1Cancel.TabIndex = 1;
            this.button1Cancel.Text = "Cancel";
            this.button1Cancel.UseVisualStyleBackColor = true;
            this.button1Cancel.Click += new System.EventHandler(this.button1Cancel_Click);
            // 
            // button1OK
            // 
            this.button1OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1OK.Location = new System.Drawing.Point(183, 178);
            this.button1OK.Name = "button1OK";
            this.button1OK.Size = new System.Drawing.Size(75, 23);
            this.button1OK.TabIndex = 0;
            this.button1OK.Text = "OK";
            this.button1OK.UseVisualStyleBackColor = true;
            this.button1OK.Click += new System.EventHandler(this.button1OK_Click);
            // 
            // ModalDialog
            // 
            this.AcceptButton = this.button1OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1Cancel;
            this.ClientSize = new System.Drawing.Size(350, 213);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModalDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModalDialog";
            this.Load += new System.EventHandler(this.ModalDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1Seed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1OK;
        private System.Windows.Forms.NumericUpDown numericUpDown1Seed;
        private System.Windows.Forms.Button button1Cancel;
        private System.Windows.Forms.Label label1Seed;
    }
}
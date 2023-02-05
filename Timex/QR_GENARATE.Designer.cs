namespace Timex
{
    partial class QR_GENARATE
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
            this.OLD_QR = new System.Windows.Forms.PictureBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.input = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.output = new MetroFramework.Controls.MetroTextBox();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            ((System.ComponentModel.ISupportInitialize)(this.OLD_QR)).BeginInit();
            this.SuspendLayout();
            // 
            // OLD_QR
            // 
            this.OLD_QR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OLD_QR.Location = new System.Drawing.Point(57, 79);
            this.OLD_QR.Name = "OLD_QR";
            this.OLD_QR.Size = new System.Drawing.Size(300, 300);
            this.OLD_QR.TabIndex = 0;
            this.OLD_QR.TabStop = false;
            // 
            // metroTile1
            // 
            this.metroTile1.Location = new System.Drawing.Point(406, 79);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(75, 23);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "Genarate";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(406, 108);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(192, 23);
            this.input.TabIndex = 3;
            this.input.Click += new System.EventHandler(this.metroTextBox1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(379, 110);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(21, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "ID";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(406, 289);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(192, 23);
            this.output.TabIndex = 6;
            // 
            // metroTile3
            // 
            this.metroTile3.Location = new System.Drawing.Point(406, 260);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(75, 23);
            this.metroTile3.TabIndex = 7;
            this.metroTile3.Text = "Test";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(379, 291);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(21, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "ID";
            // 
            // metroTile2
            // 
            this.metroTile2.Location = new System.Drawing.Point(282, 385);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(75, 23);
            this.metroTile2.TabIndex = 8;
            this.metroTile2.Text = "Save";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // QR_GENARATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 434);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile3);
            this.Controls.Add(this.output);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.input);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.OLD_QR);
            this.Name = "QR_GENARATE";
            this.Text = "QR_GENARATE";
            this.Load += new System.EventHandler(this.QR_GENARATE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OLD_QR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OLD_QR;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTextBox input;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox output;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile metroTile2;
    }
}
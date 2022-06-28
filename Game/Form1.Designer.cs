
namespace Game
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.scorelabel = new System.Windows.Forms.Label();
            this.gameoverlabel = new System.Windows.Forms.Label();
            this.win_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 760);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.scorelabel);
            this.panel1.Location = new System.Drawing.Point(457, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 760);
            this.panel1.TabIndex = 1;
            // 
            // scorelabel
            // 
            this.scorelabel.AutoSize = true;
            this.scorelabel.Font = new System.Drawing.Font("Montserrat Light", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scorelabel.ForeColor = System.Drawing.Color.White;
            this.scorelabel.Location = new System.Drawing.Point(15, 252);
            this.scorelabel.MaximumSize = new System.Drawing.Size(100, 50);
            this.scorelabel.MinimumSize = new System.Drawing.Size(100, 50);
            this.scorelabel.Name = "scorelabel";
            this.scorelabel.Size = new System.Drawing.Size(100, 50);
            this.scorelabel.TabIndex = 0;
            this.scorelabel.Text = "Score: ";
            // 
            // gameoverlabel
            // 
            this.gameoverlabel.AutoSize = true;
            this.gameoverlabel.BackColor = System.Drawing.Color.Transparent;
            this.gameoverlabel.Font = new System.Drawing.Font("Montserrat Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gameoverlabel.ForeColor = System.Drawing.Color.Black;
            this.gameoverlabel.Location = new System.Drawing.Point(77, 252);
            this.gameoverlabel.MaximumSize = new System.Drawing.Size(300, 200);
            this.gameoverlabel.MinimumSize = new System.Drawing.Size(300, 200);
            this.gameoverlabel.Name = "gameoverlabel";
            this.gameoverlabel.Size = new System.Drawing.Size(300, 200);
            this.gameoverlabel.TabIndex = 1;
            this.gameoverlabel.Text = "Game over! Press R to restart. ";
            this.gameoverlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameoverlabel.Click += new System.EventHandler(this.gameoverlabel_Click);
            // 
            // win_label
            // 
            this.win_label.AutoSize = true;
            this.win_label.BackColor = System.Drawing.Color.Transparent;
            this.win_label.Font = new System.Drawing.Font("Montserrat Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.win_label.ForeColor = System.Drawing.Color.Black;
            this.win_label.Location = new System.Drawing.Point(77, 252);
            this.win_label.MaximumSize = new System.Drawing.Size(300, 200);
            this.win_label.MinimumSize = new System.Drawing.Size(300, 200);
            this.win_label.Name = "win_label";
            this.win_label.Size = new System.Drawing.Size(300, 200);
            this.win_label.TabIndex = 2;
            this.win_label.Text = "You win! Press R to restart. ";
            this.win_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 762);
            this.Controls.Add(this.win_label);
            this.Controls.Add(this.gameoverlabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label scorelabel;
        private System.Windows.Forms.Label gameoverlabel;
        private System.Windows.Forms.Label win_label;
    }
}


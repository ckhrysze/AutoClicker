namespace AutoClicker
{
    partial class Settings
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xLowerInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.xUpperInput = new System.Windows.Forms.TextBox();
            this.yUpperInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.yLowerInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 54);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(60, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "23";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time Between Clicks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "milisec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(9, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Press F1 to Start/Stop AutoClicking";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "AutoClicker State";
            // 
            // lstate
            // 
            this.lstate.AutoSize = true;
            this.lstate.ForeColor = System.Drawing.Color.Red;
            this.lstate.Location = new System.Drawing.Point(148, 58);
            this.lstate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lstate.Name = "lstate";
            this.lstate.Size = new System.Drawing.Size(64, 13);
            this.lstate.TabIndex = 7;
            this.lstate.Text = "Not Clicking";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "X Bounds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Y Bounds";
            // 
            // xLowerInput
            // 
            this.xLowerInput.Location = new System.Drawing.Point(70, 97);
            this.xLowerInput.Name = "xLowerInput";
            this.xLowerInput.Size = new System.Drawing.Size(46, 20);
            this.xLowerInput.TabIndex = 10;
            this.xLowerInput.Text = "1050";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "to";
            // 
            // xUpperInput
            // 
            this.xUpperInput.Location = new System.Drawing.Point(144, 97);
            this.xUpperInput.Name = "xUpperInput";
            this.xUpperInput.Size = new System.Drawing.Size(46, 20);
            this.xUpperInput.TabIndex = 12;
            this.xUpperInput.Text = "1450";
            // 
            // yUpperInput
            // 
            this.yUpperInput.Location = new System.Drawing.Point(144, 118);
            this.yUpperInput.Name = "yUpperInput";
            this.yUpperInput.Size = new System.Drawing.Size(46, 20);
            this.yUpperInput.TabIndex = 15;
            this.yUpperInput.Text = "700";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "to";
            // 
            // yLowerInput
            // 
            this.yLowerInput.Location = new System.Drawing.Point(70, 118);
            this.yLowerInput.Name = "yLowerInput";
            this.yLowerInput.Size = new System.Drawing.Size(46, 20);
            this.yLowerInput.TabIndex = 13;
            this.yLowerInput.Text = "300";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 159);
            this.Controls.Add(this.yUpperInput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.yLowerInput);
            this.Controls.Add(this.xUpperInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.xLowerInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "AutoClicker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lstate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox xLowerInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox xUpperInput;
        private System.Windows.Forms.TextBox yUpperInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox yLowerInput;
    }
}


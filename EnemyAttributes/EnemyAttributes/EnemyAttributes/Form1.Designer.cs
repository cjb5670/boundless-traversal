namespace EnemyAttributes
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
            this.loadButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pointsNumeric = new System.Windows.Forms.NumericUpDown();
            this.clearButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.dexterityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.healthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dexterityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(35, 227);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 28;
            this.loadButton.Text = "LOAD";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(241, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Thank you! Enemy attributes have been updated!";
            this.label6.Visible = false;
            // 
            // pointsNumeric
            // 
            this.pointsNumeric.Location = new System.Drawing.Point(99, 45);
            this.pointsNumeric.Name = "pointsNumeric";
            this.pointsNumeric.Size = new System.Drawing.Size(59, 20);
            this.pointsNumeric.TabIndex = 26;
            this.pointsNumeric.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.pointsNumeric.ValueChanged += new System.EventHandler(this.pointsNumeric_ValueChanged_1);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(198, 227);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 25;
            this.clearButton.Text = "CLEAR";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click_1);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(114, 193);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 24;
            this.submitButton.Text = "SUBMIT";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click_1);
            // 
            // dexterityNumericUpDown
            // 
            this.dexterityNumericUpDown.Location = new System.Drawing.Point(98, 111);
            this.dexterityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dexterityNumericUpDown.Name = "dexterityNumericUpDown";
            this.dexterityNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.dexterityNumericUpDown.TabIndex = 23;
            this.dexterityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dexterityNumericUpDown.ValueChanged += new System.EventHandler(this.dexterityNumericUpDown_ValueChanged_1);
            // 
            // healthNumericUpDown
            // 
            this.healthNumericUpDown.Location = new System.Drawing.Point(98, 144);
            this.healthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.healthNumericUpDown.Name = "healthNumericUpDown";
            this.healthNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.healthNumericUpDown.TabIndex = 21;
            this.healthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.healthNumericUpDown.ValueChanged += new System.EventHandler(this.healthNumericUpDown_ValueChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Dexterity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Constitution:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Points to Allocate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Change the difficulty of your levels by changing enemy stats!";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Data loaded. Please hit submit to use these settings.";
            this.label7.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 261);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pointsNumeric);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.dexterityNumericUpDown);
            this.Controls.Add(this.healthNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "EnemyAttributes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pointsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dexterityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.healthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown pointsNumeric;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.NumericUpDown dexterityNumericUpDown;
        private System.Windows.Forms.NumericUpDown healthNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
    }
}


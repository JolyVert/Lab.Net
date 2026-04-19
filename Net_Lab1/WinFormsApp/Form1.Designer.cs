namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxN = new TextBox();
            textBoxSeed = new TextBox();
            textBoxCapacity = new TextBox();
            textBoxResult = new TextBox();
            buttonSolve = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxNN = new TextBox();
            label4 = new Label();
            labelN = new Label();
            SuspendLayout();
            // 
            // textBoxN
            // 
            textBoxN.Location = new Point(0, 0);
            textBoxN.Name = "textBoxN";
            textBoxN.Size = new Size(100, 27);
            textBoxN.TabIndex = 11;
            // 
            // textBoxSeed
            // 
            textBoxSeed.Location = new Point(598, 180);
            textBoxSeed.Name = "textBoxSeed";
            textBoxSeed.Size = new Size(125, 27);
            textBoxSeed.TabIndex = 1;
            // 
            // textBoxCapacity
            // 
            textBoxCapacity.Location = new Point(598, 272);
            textBoxCapacity.Name = "textBoxCapacity";
            textBoxCapacity.Size = new Size(125, 27);
            textBoxCapacity.TabIndex = 2;
            // 
            // textBoxResult
            // 
            textBoxResult.Location = new Point(78, 50);
            textBoxResult.Multiline = true;
            textBoxResult.Name = "textBoxResult";
            textBoxResult.ReadOnly = true;
            textBoxResult.Size = new Size(246, 344);
            textBoxResult.TabIndex = 3;
            // 
            // buttonSolve
            // 
            buttonSolve.Location = new Point(583, 350);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(94, 29);
            buttonSolve.TabIndex = 4;
            buttonSolve.Text = "Solve";
            buttonSolve.UseVisualStyleBackColor = true;
            buttonSolve.Click += buttonSolve_Click;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(550, 183);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 6;
            label2.Text = "Seed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(526, 275);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 7;
            label3.Text = "Capacity";
            // 
            // textBoxNN
            // 
            textBoxNN.Location = new Point(599, 104);
            textBoxNN.Name = "textBoxNN";
            textBoxNN.Size = new Size(125, 27);
            textBoxNN.TabIndex = 10;
            // 
            // label4
            // 
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 0;
            // 
            // labelN
            // 
            labelN.AutoSize = true;
            labelN.Location = new Point(570, 106);
            labelN.Name = "labelN";
            labelN.Size = new Size(20, 20);
            labelN.TabIndex = 12;
            labelN.Text = "N";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 486);
            Controls.Add(labelN);
            Controls.Add(label4);
            Controls.Add(textBoxNN);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonSolve);
            Controls.Add(textBoxResult);
            Controls.Add(textBoxCapacity);
            Controls.Add(textBoxSeed);
            Controls.Add(textBoxN);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxN;
        private TextBox textBoxSeed;
        private TextBox textBoxCapacity;
        private TextBox textBoxResult;
        private Button buttonSolve;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxNN;
        private Label label4;
        private Label labelN;
    }
}

namespace GraphicsEnvironmentComp2
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
            this.Runbutton = new System.Windows.Forms.Button();
            this.SyntaxButton = new System.Windows.Forms.Button();
            this.MultiLine = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Singleline = new System.Windows.Forms.TextBox();
            this.GraphicPanel = new System.Windows.Forms.Panel();
            this.MultiLineRunBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Runbutton
            // 
            this.Runbutton.Location = new System.Drawing.Point(15, 568);
            this.Runbutton.Name = "Runbutton";
            this.Runbutton.Size = new System.Drawing.Size(75, 23);
            this.Runbutton.TabIndex = 0;
            this.Runbutton.Text = "Run";
            this.Runbutton.UseVisualStyleBackColor = true;
            this.Runbutton.Click += new System.EventHandler(this.Runbutton_Click);
            // 
            // SyntaxButton
            // 
            this.SyntaxButton.Location = new System.Drawing.Point(96, 568);
            this.SyntaxButton.Name = "SyntaxButton";
            this.SyntaxButton.Size = new System.Drawing.Size(75, 23);
            this.SyntaxButton.TabIndex = 1;
            this.SyntaxButton.Text = "Syntax";
            this.SyntaxButton.UseVisualStyleBackColor = true;
            this.SyntaxButton.Click += new System.EventHandler(this.SyntaxButton_Click);
            // 
            // MultiLine
            // 
            this.MultiLine.Location = new System.Drawing.Point(12, 9);
            this.MultiLine.Multiline = true;
            this.MultiLine.Name = "MultiLine";
            this.MultiLine.Size = new System.Drawing.Size(507, 433);
            this.MultiLine.TabIndex = 2;
            this.MultiLine.TextChanged += new System.EventHandler(this.MultiLine_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Singleline
            // 
            this.Singleline.Location = new System.Drawing.Point(15, 542);
            this.Singleline.Name = "Singleline";
            this.Singleline.Size = new System.Drawing.Size(507, 20);
            this.Singleline.TabIndex = 4;
            this.Singleline.TextChanged += new System.EventHandler(this.Singleline_TextChanged);
            // 
            // GraphicPanel
            // 
            this.GraphicPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GraphicPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GraphicPanel.Location = new System.Drawing.Point(528, 9);
            this.GraphicPanel.Name = "GraphicPanel";
            this.GraphicPanel.Size = new System.Drawing.Size(592, 433);
            this.GraphicPanel.TabIndex = 5;
            this.GraphicPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphicPanel_Paint);
            // 
            // MultiLineRunBtn
            // 
            this.MultiLineRunBtn.Location = new System.Drawing.Point(12, 448);
            this.MultiLineRunBtn.Name = "MultiLineRunBtn";
            this.MultiLineRunBtn.Size = new System.Drawing.Size(75, 23);
            this.MultiLineRunBtn.TabIndex = 0;
            this.MultiLineRunBtn.Text = "Run";
            this.MultiLineRunBtn.UseVisualStyleBackColor = true;
            this.MultiLineRunBtn.Click += new System.EventHandler(this.MultiLineRunBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1129, 613);
            this.Controls.Add(this.MultiLineRunBtn);
            this.Controls.Add(this.GraphicPanel);
            this.Controls.Add(this.Singleline);
            this.Controls.Add(this.MultiLine);
            this.Controls.Add(this.SyntaxButton);
            this.Controls.Add(this.Runbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Runbutton;
        private System.Windows.Forms.Button SyntaxButton;
        private System.Windows.Forms.TextBox MultiLine;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox Singleline;
        private System.Windows.Forms.Panel GraphicPanel;
        private System.Windows.Forms.Button MultiLineRunBtn;
    }
}


namespace _2048
{
    partial class AI
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
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.b0 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.b1 = new System.Windows.Forms.Button();
            this.b3 = new System.Windows.Forms.Button();
            this.BGetBest = new System.Windows.Forms.Button();
            this.lbest = new System.Windows.Forms.Label();
            this.moveAI = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.grid.ColumnCount = 4;
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.Location = new System.Drawing.Point(66, 54);
            this.grid.Name = "grid";
            this.grid.RowCount = 4;
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.grid.Size = new System.Drawing.Size(338, 237);
            this.grid.TabIndex = 0;
            // 
            // b0
            // 
            this.b0.Location = new System.Drawing.Point(66, 12);
            this.b0.Name = "b0";
            this.b0.Size = new System.Drawing.Size(338, 36);
            this.b0.TabIndex = 1;
            this.b0.Text = "up";
            this.b0.UseVisualStyleBackColor = true;
            this.b0.Click += new System.EventHandler(this.buttonClick);
            this.b0.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AI_KeyUp);
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(66, 297);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(338, 36);
            this.b2.TabIndex = 2;
            this.b2.Text = "down";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.buttonClick);
            this.b2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AI_KeyUp);
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(410, 54);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(42, 237);
            this.b1.TabIndex = 3;
            this.b1.Text = "right";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.buttonClick);
            this.b1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AI_KeyUp);
            // 
            // b3
            // 
            this.b3.Location = new System.Drawing.Point(18, 54);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(42, 237);
            this.b3.TabIndex = 4;
            this.b3.Text = "left";
            this.b3.UseVisualStyleBackColor = true;
            this.b3.Click += new System.EventHandler(this.buttonClick);
            this.b3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AI_KeyUp);
            // 
            // BGetBest
            // 
            this.BGetBest.Location = new System.Drawing.Point(135, 349);
            this.BGetBest.Name = "BGetBest";
            this.BGetBest.Size = new System.Drawing.Size(75, 23);
            this.BGetBest.TabIndex = 9;
            this.BGetBest.Text = "GetBest";
            this.BGetBest.UseVisualStyleBackColor = true;
            this.BGetBest.Click += new System.EventHandler(this.GetBest_Click);
            this.BGetBest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AI_KeyUp);
            // 
            // lbest
            // 
            this.lbest.AutoSize = true;
            this.lbest.Location = new System.Drawing.Point(216, 354);
            this.lbest.Name = "lbest";
            this.lbest.Size = new System.Drawing.Size(10, 13);
            this.lbest.TabIndex = 10;
            this.lbest.Text = "-";
            // 
            // moveAI
            // 
            this.moveAI.Location = new System.Drawing.Point(395, 349);
            this.moveAI.Name = "moveAI";
            this.moveAI.Size = new System.Drawing.Size(75, 23);
            this.moveAI.TabIndex = 13;
            this.moveAI.Text = "Move AI";
            this.moveAI.UseVisualStyleBackColor = true;
            this.moveAI.Click += new System.EventHandler(this.moveAI_Click);
            // 
            // AI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 376);
            this.Controls.Add(this.moveAI);
            this.Controls.Add(this.lbest);
            this.Controls.Add(this.BGetBest);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b0);
            this.Controls.Add(this.grid);
            this.Name = "AI";
            this.Text = "2048";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AI_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel grid;
        private System.Windows.Forms.Button b0;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b3;
        private System.Windows.Forms.Button BGetBest;
        private System.Windows.Forms.Label lbest;
        private System.Windows.Forms.Button moveAI;
    }
}


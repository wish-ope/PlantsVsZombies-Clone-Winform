namespace PlantsVSZombies_Clone
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            

            this.gamePanel = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.plantButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gamePanel
            this.gamePanel.Location = new System.Drawing.Point(22, 89);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(750, 250); // Kích thước chia hết cho 50
            this.gamePanel.TabIndex = 0;
           
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(19, 23);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(35, 13);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Điểm: 0";
            // 
            // plantButton
            // 
            this.plantButton.Location = new System.Drawing.Point(110, 23);
            this.plantButton.Name = "plantButton";
            this.plantButton.Size = new System.Drawing.Size(75, 23);
            this.plantButton.TabIndex = 2;
            this.plantButton.Text = "Trồng Cây";
            this.plantButton.UseVisualStyleBackColor = true;
            this.plantButton.Click += new System.EventHandler(this.plantButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plantButton);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.gamePanel);
            this.Name = "Form1";
            this.Text = "Plants vs Zombies Clone";
            this.ResumeLayout(false);
            this.PerformLayout();
            
        }

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Button plantButton;
    }
}

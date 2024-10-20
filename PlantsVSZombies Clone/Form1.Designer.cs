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
            this.selectShooterButton = new System.Windows.Forms.Button();
            this.selectPotatoButton = new System.Windows.Forms.Button();
            this.selectEnergyButton = new System.Windows.Forms.Button();
            this.energyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(22, 89);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(750, 250);
            this.gamePanel.TabIndex = 0;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(19, 23);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(43, 13);
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
            // selectShooterButton
            // 
            this.selectShooterButton.Location = new System.Drawing.Point(200, 23);
            this.selectShooterButton.Name = "selectShooterButton";
            this.selectShooterButton.Size = new System.Drawing.Size(75, 23);
            this.selectShooterButton.TabIndex = 3;
            this.selectShooterButton.Text = "Cây Bắn";
            this.selectShooterButton.UseVisualStyleBackColor = true;
            this.selectShooterButton.Click += new System.EventHandler(this.SelectShooterButton_Click);
            // 
            // selectPotatoButton
            // 
            this.selectPotatoButton.Location = new System.Drawing.Point(300, 23);
            this.selectPotatoButton.Name = "selectPotatoButton";
            this.selectPotatoButton.Size = new System.Drawing.Size(100, 23);
            this.selectPotatoButton.TabIndex = 4;
            this.selectPotatoButton.Text = "Cây Khoai Tây";
            this.selectPotatoButton.UseVisualStyleBackColor = true;
            this.selectPotatoButton.Click += new System.EventHandler(this.SelectPotatoButton_Click);
            // 
            // selectEnergyButton
            // 
            this.selectEnergyButton.Location = new System.Drawing.Point(410, 23);
            this.selectEnergyButton.Name = "selectEnergyButton";
            this.selectEnergyButton.Size = new System.Drawing.Size(100, 23);
            this.selectEnergyButton.TabIndex = 5;
            this.selectEnergyButton.Text = "Cây Năng Lượng";
            this.selectEnergyButton.UseVisualStyleBackColor = true;
            this.selectEnergyButton.Click += new System.EventHandler(this.SelectEnergyButton_Click);
            // 
            // energyLabel
            // 
            this.energyLabel.AutoSize = true;
            this.energyLabel.Location = new System.Drawing.Point(19, 50);
            this.energyLabel.Name = "energyLabel";
            this.energyLabel.Size = new System.Drawing.Size(64, 13);
            this.energyLabel.TabIndex = 6;
            this.energyLabel.Text = "Energy: 300";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.energyLabel);
            this.Controls.Add(this.selectEnergyButton);
            this.Controls.Add(this.selectPotatoButton);
            this.Controls.Add(this.selectShooterButton);
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
        private System.Windows.Forms.Button selectShooterButton;
        private System.Windows.Forms.Button selectPotatoButton;
        private System.Windows.Forms.Button selectEnergyButton;
        private System.Windows.Forms.Label energyLabel;
    }
}

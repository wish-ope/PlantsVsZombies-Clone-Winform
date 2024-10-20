using System;
using System.Windows.Forms;

public class GameEngine
{
    private Panel gamePanel;
    private Timer zombieTimer;
    private Label scoreLabel;
    private int score = 0;
    private int energy = 300; // Năng lượng ban đầu
    private Label energyLabel; // Hiển thị năng lượng

    public GameEngine(Panel panel, Label label, Label energyLabel)
    {
        gamePanel = panel;
        scoreLabel = label;
        this.energyLabel = energyLabel; // Lưu label năng lượng

        zombieTimer = new Timer { Interval = 2000 };
        zombieTimer.Tick += (s, e) => SpawnZombie();
        zombieTimer.Start();
    }
    public void GenerateEnergy(int amount)
    {
        energy += amount; // Cập nhật năng lượng
        UpdateEnergyLabel(); // Cập nhật label hiển thị năng lượng
    }

    private void UpdateEnergyLabel()
    {
        energyLabel.Text = "Năng lượng: " + energy; // Cập nhật label hiển thị năng lượng
    }

    public bool CanPlacePlant(int cost)
    {
        return energy >= cost; // Kiểm tra nếu đủ năng lượng để trồng cây
    }

    public void UseEnergy(int amount)
    {
        energy -= amount; // Giảm năng lượng khi trồng cây
        UpdateEnergyLabel(); // Cập nhật label hiển thị năng lượng
    }
    public void PlantFlower(IPlant plant)
    {
        if (energy >= plant.Cost)
        {
            energy -= plant.Cost; // Trừ năng lượng
            // Thêm logic để đặt cây vào gamePanel
            gamePanel.Controls.Add((Control)plant);
            if (plant is Energy energyPlant)
            {
                energyPlant.StartGeneratingEnergy(this); // Bắt đầu tạo năng lượng
            }
        }
        else
        {
            MessageBox.Show("Không đủ năng lượng để trồng cây này!");
        }
    }

   

    private void SpawnZombie()
    {
        Random rand = new Random();
        int y = rand.Next(0, 5) * 50;

        Zombie zombie = new Zombie { Location = new System.Drawing.Point(750, y) };
        gamePanel.Controls.Add(zombie);

        Timer moveTimer = new Timer { Interval = 100 };
        moveTimer.Tick += (s, e) => MoveZombie(zombie, moveTimer);
        moveTimer.Start();
    }

    private void MoveZombie(Zombie zombie, Timer moveTimer)
    {
        zombie.Move();

        bool isBlocked = false;  // Biến để xác định nếu zombie bị chặn

        foreach (Control control in gamePanel.Controls)
        {
            // Kiểm tra va chạm với các loại cây
            if (control is Plant plant)
            {
                if (zombie.Bounds.IntersectsWith(plant.Bounds))
                {
                    plant.TakeDamage(10); // Cây mất 10 máu khi bị zombie va chạm
                    isBlocked = true; // Zombie đã chạm vào cây
                    break; // Ngừng kiểm tra
                }
            }

            // Kiểm tra va chạm với đạn
            if (control is Bullet bullet && bullet.Bounds.IntersectsWith(zombie.Bounds))
            {
                zombie.Health -= bullet.Damage;
                bullet.Dispose();

                if (zombie.Health <= 0)
                {
                    moveTimer.Stop();
                    gamePanel.Controls.Remove(zombie);
                    zombie.Dispose();
                    UpdateScore();
                    break;
                }
            }
        }

        // Nếu zombie bị chặn, không cho nó di chuyển tiếp
        if (isBlocked)
        {
            zombie.Left += 5;  // Đẩy zombie ra khỏi cây một chút (có thể điều chỉnh)
            return; // Ngăn zombie tiếp tục di chuyển
        }

        // Kiểm tra nếu zombie đi ra ngoài màn hình
        if (zombie.Left < 0)
        {
            moveTimer.Stop();
            MessageBox.Show("Game Over! Zombie đã vào nhà!");
            Application.Exit();
        }
    }





    private void UpdateScore()
    {
        score += 10;
        scoreLabel.Text = "Score: " + score;
    }
}

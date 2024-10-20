using System;
using System.Windows.Forms;

public class GameEngine
{
    private Panel gamePanel;
    private Timer zombieTimer;
    private Label scoreLabel;
    private int score = 0;

    public GameEngine(Panel panel, Label label)
    {
        gamePanel = panel;
        scoreLabel = label;

        zombieTimer = new Timer();
        zombieTimer.Interval = 2000;  // Mỗi 2 giây thêm 1 zombie
        zombieTimer.Tick += (s, e) => SpawnZombie();
        zombieTimer.Start();
    }

    private void SpawnZombie()
    {
        Random rand = new Random();
        int y = rand.Next(0, 5) * 50;  // Chọn vị trí hàng ngẫu nhiên

        Zombie zombie = new Zombie();  // Sử dụng constructor mặc định
        zombie.Location = new System.Drawing.Point(750, y);  // Đặt vị trí zombie
        gamePanel.Controls.Add(zombie);

        // Tạo Timer để di chuyển zombie
        Timer moveTimer = new Timer();
        moveTimer.Interval = 100;
        moveTimer.Tick += (s, e) => MoveZombie(zombie, moveTimer);
        moveTimer.Start();
    }


    private void MoveZombie(Zombie zombie, Timer moveTimer)
    {
        zombie.Move();

        // Kiểm tra nếu zombie ra khỏi màn hình => Game Over
        if (zombie.Left < 0)
        {
            moveTimer.Stop();
            MessageBox.Show("Game Over! Zombie đã vào nhà!");
            Application.Exit();
        }

        // Kiểm tra va chạm giữa zombie và đạn
        foreach (Control control in gamePanel.Controls)
        {
            if (control is Bullet bullet && bullet.Bounds.IntersectsWith(zombie.Bounds))
            {
                zombie.Health -= bullet.Damage;  // Giảm máu zombie
                bullet.Dispose();  // Xóa đạn khi trúng zombie

                if (zombie.Health <= 0)  // Nếu máu zombie <= 0 thì xóa zombie
                {
                    moveTimer.Stop();
                    gamePanel.Controls.Remove(zombie);
                    zombie.Dispose();
                    UpdateScore();  // Cập nhật điểm
                    break;
                }
            }
        }
    }


    public void UpdateScore()
    {
        score += 10;
        scoreLabel.Text = "Score: " + score;
    }
}

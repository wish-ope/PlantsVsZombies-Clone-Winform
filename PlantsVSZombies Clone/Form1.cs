using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PlantsVSZombies_Clone
{
    public partial class Form1 : Form
    {
        private List<Zombie> zombies = new List<Zombie>(); // Danh sách zombie
        private Timer gameTimer; // Bộ đếm thời gian cho game
        private int score = 0; // Điểm số của người chơi

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        // Thiết lập trò chơi
        private void InitializeGame()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 50; // Cập nhật game mỗi 50ms
            gameTimer.Tick += GameTick;
            gameTimer.Start();
        }

        private Random random = new Random(); // Tạo số ngẫu nhiên dùng cho nhiều lần

        private void GameTick(object sender, EventArgs e)
        {
            if (random.Next(0, 100) < 5) // 5% cơ hội sinh zombie mỗi lần tick
            {
                SpawnZombie(); // Sinh zombie
            }

            MoveZombies();   // Di chuyển zombie
            CheckCollisions(); // Kiểm tra va chạm giữa đạn và zombie
        }


        // Sự kiện khi nhấn nút "Trồng Cây"
        private void plantButton_Click(object sender, EventArgs e)
        {
            var plant = new Plant(new Point(50, gamePanel.Controls.Count * 60));
            plant.StartShooting(gamePanel); // Cây bắt đầu bắn đạn
            gamePanel.Controls.Add(plant);
        }

        // Phương thức di chuyển zombie sang trái
        private void MoveZombies()
        {
            foreach (var zombie in zombies)
            {
                zombie.Move(); // Di chuyển zombie

                // Nếu zombie đến rìa trái của màn hình, trò chơi kết thúc
                if (zombie.Left <= 0)
                {
                    gameTimer.Stop();
                    MessageBox.Show("Game Over! Một zombie đã xâm nhập vào căn cứ!");
                    return;
                }
            }
        }

        // Sinh thêm zombie ở vị trí ngẫu nhiên
        private void SpawnZombie()
        {
            Zombie zombie = new Zombie
            {
                Location = new Point(gamePanel.Width - 60, new Random().Next(0, gamePanel.Height - 50))
            };
            zombies.Add(zombie);
            gamePanel.Controls.Add(zombie);
        }

        // Kiểm tra va chạm giữa đạn và zombie
        private void CheckCollisions()
        {
            foreach (Control control in gamePanel.Controls)
            {
                if (control is Bullet bullet)
                {
                    foreach (var zombie in zombies)
                    {
                        if (bullet.Bounds.IntersectsWith(zombie.Bounds))
                        {
                            zombie.TakeDamage(bullet.Damage); // Zombie nhận sát thương
                            gamePanel.Controls.Remove(bullet); // Xóa đạn sau khi bắn trúng
                            score += 10; // Tăng điểm
                            UpdateScore();
                            break;
                        }
                    }
                }
            }

            // Xóa zombie đã chết khỏi danh sách
            zombies.RemoveAll(z => !z.Visible);
        }

        // Cập nhật điểm số trên giao diện
        private void UpdateScore()
        {
            scoreLabel.Text = $"Điểm: {score}";
        }
    }
}

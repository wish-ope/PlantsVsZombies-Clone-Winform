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

        zombieTimer = new Timer { Interval = 2000 };
        zombieTimer.Tick += (s, e) => SpawnZombie();
        zombieTimer.Start();
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

        if (zombie.Left < 0)
        {
            moveTimer.Stop();
            MessageBox.Show("Game Over! Zombie đã vào nhà!");
            Application.Exit();
        }

        foreach (Control control in gamePanel.Controls)
        {
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
    }

    private void UpdateScore()
    {
        score += 10;
        scoreLabel.Text = "Score: " + score;
    }
}

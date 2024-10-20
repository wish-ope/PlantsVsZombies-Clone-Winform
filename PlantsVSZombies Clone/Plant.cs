using System.Drawing;
using System.Windows.Forms;

public class Plant : PictureBox
{
    public Timer ShootTimer { get; private set; }

    public Plant(Point location)
    {
        this.Location = location;
        this.Size = new Size(50, 50);
        this.BackColor = Color.Green;
        this.BorderStyle = BorderStyle.FixedSingle;
    }

    public void StartShooting(Panel panel)
    {
        ShootTimer = new Timer { Interval = 1000 };
        ShootTimer.Tick += (s, e) => Shoot(panel);
        ShootTimer.Start();
    }

    private void Shoot(Panel panel)
    {
        Bullet bullet = new Bullet(this.Location.X + this.Width, this.Location.Y + this.Height / 2);
        panel.Controls.Add(bullet);
    }
}

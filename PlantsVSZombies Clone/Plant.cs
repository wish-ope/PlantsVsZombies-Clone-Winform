using System.Drawing;
using System.Windows.Forms;

public class Plant : PictureBox
{
    public int Health { get; set; } = 10;
    public int Damage { get; set; } = 1; // Damage dealt per bullet
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
        ShootTimer = new Timer();
        ShootTimer.Interval = 1000; // Bullet shooting every 1 second
        ShootTimer.Tick += (s, e) => Shoot(panel);
        ShootTimer.Start();
    }

    private void Shoot(Panel panel)
    {
        Bullet bullet = new Bullet(this.Right, this.Top + this.Height / 2 - 2, Damage);
        panel.Controls.Add(bullet); // Add bullet to the panel
    }
}

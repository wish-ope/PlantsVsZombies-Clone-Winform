using System.Drawing;
using System.Windows.Forms;

public class Shooter : Plant
{
    public Shooter(Point location) : base(location)
    {
        this.BackColor = Color.Green;
    }

    public override int Cost => 30; // Chi phí năng lượng cho cây bắn súng

    public override void StartShooting(Panel panel)
    {
        Timer shootTimer = new Timer { Interval = 1000 }; // 1 giây
        shootTimer.Tick += (s, e) => Shoot(panel);
        shootTimer.Start();
    }

    private void Shoot(Panel panel)
    {
        Bullet bullet = new Bullet(this.Location.X + this.Width, this.Location.Y + this.Height / 2);
        panel.Controls.Add(bullet);
    }
}

using System.Drawing;
using System.Windows.Forms;

public class Bullet : PictureBox
{
    public int Damage { get; private set; } = 10;
    private Timer bulletTimer;

    public Bullet(int x, int y)
    {
        this.Location = new Point(x, y);
        this.Size = new Size(10, 5);
        this.BackColor = Color.Yellow;

        bulletTimer = new Timer { Interval = 50 };
        bulletTimer.Tick += (s, e) => MoveBullet();
        bulletTimer.Start();
    }

    private void MoveBullet()
    {
        this.Left += 10;

        if (this.Parent != null && this.Right > this.Parent.Width)
        {
            bulletTimer.Stop();
            this.Dispose();
        }
    }
}

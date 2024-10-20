using System.Drawing;
using System.Windows.Forms;

public class Bullet : PictureBox
{
    public int Damage { get; private set; }
    private Timer bulletTimer;

    public Bullet(int x, int y, int damage)
    {
        this.Location = new Point(x, y);
        this.Size = new Size(10, 5);
        this.BackColor = Color.Yellow;
        Damage = damage;

        // Set up a timer to move the bullet continuously
        bulletTimer = new Timer();
        bulletTimer.Interval = 50; // Bullet movement every 50ms
        bulletTimer.Tick += (s, e) => MoveBullet();
        bulletTimer.Start();
    }

    // Moves the bullet right and removes it if it exits the panel
    private void MoveBullet()
    {
        this.Left += 10;

        // If the bullet leaves the panel, dispose of it
        if (this.Parent != null && this.Right > this.Parent.Width)
        {
            bulletTimer.Stop();
            this.Parent.Controls.Remove(this);
            bulletTimer.Dispose();
        }
    }
}

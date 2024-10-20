using System.Drawing;
using System.Windows.Forms;

public class Zombie : PictureBox
{
    public int Health { get; set; } = 30;

    public Zombie()
    {
        this.Size = new Size(50, 50);
        this.BackColor = Color.Red; // Màu cho zombie
        this.BorderStyle = BorderStyle.FixedSingle;
    }

    public void Move()
    {
        this.Left -= 5; // Di chuyển zombie sang trái
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            this.Visible = false; // Đánh dấu zombie là chết
        }
    }
}

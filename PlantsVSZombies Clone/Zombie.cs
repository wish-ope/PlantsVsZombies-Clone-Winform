using System.Drawing;
using System.Windows.Forms;

public class Zombie : PictureBox
{
    public int Health { get; set; } = 30;

    public Zombie()
    {
        this.Size = new Size(50, 50);
        this.BackColor = Color.Red;
        this.BorderStyle = BorderStyle.FixedSingle;
    }

    public void Move()
    {
        this.Left -= 5;
    }
}

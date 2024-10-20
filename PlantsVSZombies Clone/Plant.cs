using System.Drawing;
using System.Windows.Forms;

public interface IPlant
{
    int Cost { get; }
    void TakeDamage(int damage);
    int Health { get; }
    Point Location { get; }
    void StartShooting(Panel panel);
}


public class Plant : PictureBox, IPlant
{
    public int Health { get; set; } = 100; // Khởi tạo máu cho các loại cây
    public virtual int Cost => 0; // Chi phí mặc định cho cây

    public Plant(Point location)
    {
        this.Location = location;
        this.Size = new Size(50, 50);
        this.BorderStyle = BorderStyle.FixedSingle;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            this.Dispose(); // Xóa cây khỏi màn hình khi hết máu
        }
    }

    public virtual void StartShooting(Panel panel)
    {
        // Phương thức này có thể được ghi đè bởi các loại cây khác
    }
}


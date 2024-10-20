using System.Drawing;

public class Potato : Plant
{
    public Potato(Point location) : base(location)
    {
        Health = 1000; // Máu cho cây khoai tây
        this.BackColor = Color.Brown; // Màu cho cây khoai tây
    }

    public override int Cost => 10; // Chi phí năng lượng cho cây khoai tây
}

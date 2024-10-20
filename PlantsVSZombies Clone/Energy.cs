using System.Drawing;
using System.Windows.Forms; // Thêm dòng này

public class Energy : Plant
{
    public Energy(Point location) : base(location)
    {
        Health = 500; // Máu cho cây năng lượng
        this.BackColor = Color.Yellow; // Màu cho cây năng lượng
    }

    public override int Cost => 5; // Chi phí năng lượng cho cây năng lượng

    public void StartGeneratingEnergy(GameEngine gameEngine)
    {
        Timer energyTimer = new Timer { Interval = 1000 }; // 1 giây
        energyTimer.Tick += (s, e) => gameEngine.GenerateEnergy(10); // Cung cấp 10 năng lượng mỗi giây
        energyTimer.Start();
    }
}

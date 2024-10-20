using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlantsVSZombies_Clone
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;
        private bool isPlanting = false;  // Xác định nếu đang trồng cây
        private const int CellSize = 50;  // Kích thước mỗi ô vuông
        private int rows, cols;
        private bool[,] gridOccupied;  // Kiểm tra ô đã có cây chưa
        private string selectedPlantType; // Lưu loại cây đã chọn
        private int energy = 300; // Năng lượng ban đầu
        
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            gameEngine = new GameEngine(gamePanel, scoreLabel, energyLabel); // Thêm energyLabel vào đây
            selectedPlantType = "Shooter"; // Mặc định chọn cây bắn súng
        }

        private void InitializeGrid()
        {
            rows = gamePanel.Height / CellSize;
            cols = gamePanel.Width / CellSize;
            gridOccupied = new bool[rows, cols];  // Khởi tạo mảng lưới

            gamePanel.Paint += GamePanel_Paint;  // Đăng ký sự kiện vẽ lưới
            gamePanel.Click += GamePanel_Click;  // Đăng ký sự kiện click
        }

        private void plantButton_Click(object sender, EventArgs e)
        {
            isPlanting = true;
            //MessageBox.Show("Nhấp vào một ô trống để trồng cây!");
        }

        private void GamePanel_Click(object sender, EventArgs e)
        {
            if (isPlanting)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                int row = me.Y / CellSize;
                int col = me.X / CellSize;

                if (!gridOccupied[row, col])
                {
                    PlacePlant(row, col);
                    gridOccupied[row, col] = true;  // Đánh dấu ô đã có cây
                    isPlanting = false;
                }
                else
                {
                    MessageBox.Show("Ô này đã có cây! Vui lòng chọn ô khác.");
                }
            }
        }

        private void PlacePlant(int row, int col)
        {
            Point location = new Point(col * CellSize, row * CellSize);
            Plant plant;

            int cost = 0; // Biến lưu trữ chi phí năng lượng

            switch (selectedPlantType)
            {
                case "Shooter":
                    cost = 30;
                    plant = new Shooter(location);
                    break;
                case "Potato":
                    cost = 10;
                    plant = new Potato(location);
                    break;
                case "Energy":
                    cost = 5;
                    plant = new Energy(location);
                    break;
                default:
                    plant = new Shooter(location); // Mặc định là cây bắn súng
                    break;
            }

            // Kiểm tra xem có đủ năng lượng không
            if (gameEngine.CanPlacePlant(cost))
            {
                gamePanel.Controls.Add(plant);
                gameEngine.UseEnergy(cost); // Giảm năng lượng khi trồng cây
                plant.StartShooting(gamePanel); // Chỉ cây bắn súng mới bắn

                if (plant is Energy energyPlant)
                {
                    energyPlant.StartGeneratingEnergy(gameEngine); // Bắt đầu tạo năng lượng nếu là cây năng lượng
                }
            }
            else
            {
                MessageBox.Show("Không đủ năng lượng để trồng cây!");
            }
        }



        private void SelectShooterButton_Click(object sender, EventArgs e)
        {
            selectedPlantType = "Shooter";
            isPlanting = true;
        }

        private void SelectPotatoButton_Click(object sender, EventArgs e)
        {
            selectedPlantType = "Potato";
            isPlanting = true;
        }

        private void SelectEnergyButton_Click(object sender, EventArgs e)
        {
            selectedPlantType = "Energy";
            isPlanting = true;
        }

        // Sự kiện vẽ lưới ô vuông
        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);

            // Vẽ các đường ngang và dọc tạo thành lưới
            for (int i = 0; i <= rows; i++)
            {
                g.DrawLine(pen, 0, i * CellSize, gamePanel.Width, i * CellSize);
            }
            for (int j = 0; j <= cols; j++)
            {
                g.DrawLine(pen, j * CellSize, 0, j * CellSize, gamePanel.Height);
            }

            pen.Dispose();
        }
    }
}

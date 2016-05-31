using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoulderPusherWPF.GameObject
{
    /// <summary>
    /// Interaction logic for Boulder.xaml
    /// </summary>
    public partial class Boulder : UserControl
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        // Relay Boulder Position to Canvas
        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        public Boulder()
        {
            this.InitializeComponent();

            Width = 50;
            Height = 50;
        }

        // Push function. Called when the player collides with a boulder and its path is not obstructed
        public void Push(int x, int y)
        {
            LocationX = x * 50;
            LocationY = y * 50;
            X = x;
            Y = y;
            UpdatePosition();
        }
    }
}

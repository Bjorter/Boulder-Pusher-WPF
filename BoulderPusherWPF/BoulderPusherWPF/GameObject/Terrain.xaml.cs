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
    /// Interaction logic for Terrain.xaml
    /// </summary>
    public partial class Terrain : UserControl
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        // Relay Terrain Position to Canvas
        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
        public Terrain()
        {
            this.InitializeComponent();

            Width = 50;
            Height = 50;
        }
    }
}

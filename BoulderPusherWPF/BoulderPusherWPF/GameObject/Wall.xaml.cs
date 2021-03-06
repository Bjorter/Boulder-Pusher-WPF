﻿using System;
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
    public partial class Wall : UserControl
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        // Relay Wall Position to Canvas
        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        // Receives the wall's location's int[,] value. Used for determining which wall is generated
        // Also receives the X and Y coordinates as well as the canvas location
        public Wall(int Position, int xX, int yY, int iI, int jJ)
        {
            this.InitializeComponent();
            Height = 50;
            Width = 50;
            // Checks which wall is being created and adjust the SpriteSheetOffset to match the desired wall
            SpriteSheetOffset.Y = (Position - 4) * 50 * (-1);
            LocationX = xX;
            LocationY = yY;
            X = iI;
            Y = jJ;
        }
    }
}
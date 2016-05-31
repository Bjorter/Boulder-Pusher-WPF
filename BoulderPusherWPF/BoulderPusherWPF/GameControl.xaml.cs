using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace BoulderPusherWPF
{
    /// <summary>
    /// Interaction logic for GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        // Constructor and the main variables ------------------------------------------------------

        // Game Objects
        GameObject.Player player;
        GameObject.Boulder boulder;
        GameObject.Terrain terrain;
        GameObject.Wall wall;
        GameObject.Exit exit;
        public List<GameObject.Boulder> Boulds;
        public List<GameObject.Terrain> Terrs;
        public List<GameObject.Wall> Walls;
        public List<GameObject.Exit> Door;

        // level
        private int level = 0;

        // Delay for movement
        DispatcherTimer delay;

        // Constructor
        public GameControl()
        {
            this.InitializeComponent();

            CreatePBT();

            delay = new DispatcherTimer();

            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);

            delay.Interval = new TimeSpan(0, 0, 0, 0, 75);
            delay.Tick += Delay_Tick;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if ((Keyboard.IsKeyDown(Key.Up)) && delay.IsEnabled != true)
            {
                player.MoveUp(Boulds, Terrs, Walls, Door);
                delay.Start();
                Debug.WriteLine("Up");
                LevelSwitch();
            }
            else if ((Keyboard.IsKeyDown(Key.Left)) && delay.IsEnabled != true)
            {
                player.MoveLeft(Boulds, Terrs, Walls, Door);
                delay.Start();
                Debug.WriteLine("Left");
            }
            else if ((Keyboard.IsKeyDown(Key.Right)) && delay.IsEnabled != true)
            {
                player.MoveRight(Boulds, Terrs, Walls, Door);
                delay.Start();
                Debug.WriteLine("Right");
            }
            else if ((Keyboard.IsKeyDown(Key.Down)) && delay.IsEnabled != true)
            {
                player.MoveDown(Boulds, Terrs, Walls, Door);
                delay.Start();
                Debug.WriteLine("Down");
            }
        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            delay.Stop();
        }

        // Level creation --------------------------------------------------------------------------
        // 2D int lists of GameObjects for map generation: 0 = Empty, 1 = Player, 2 = Boulder, 3 = terrain,
        // 4-10 = Various Walls, 11 = Back wall (empty but has collision) and 12 = Exit
        public int[,] pBT =
            {
                { 7,4,4,4,4,12,4,4,4,4,8 },
                { 5,0,0,0,0,2,0,0,0,0,6 },
                { 5,0,0,0,0,3,0,0,0,0,6 },
                { 5,0,0,0,3,3,3,0,0,0,6 },
                { 5,0,0,3,0,3,0,3,0,0,6 },
                { 5,0,0,0,0,3,0,0,0,0,6 },
                { 5,0,0,0,0,3,0,0,0,0,6 },
                { 5,0,0,0,0,3,0,0,0,0,6 },
                { 5,0,0,0,0,0,0,0,0,0,6 },
                { 5,0,0,0,0,1,0,0,0,0,6 },
                { 11,11,11,11,11,11,11,11,11,11,11 }
            };
        public int[,] pBT2 =
             {
                 { 11,11,11,7,4,12,4,8,11,11,11 },
                 { 11,11,7,9,0,0,0,10,8,11,11 },
                 { 11,11,5,2,2,0,2,2,6,11,11 },
                 { 11,11,5,0,2,2,2,0,6,11,11 },
                 { 11,11,5,2,0,0,0,2,6,11,11 },
                 { 11,11,5,0,2,2,2,0,6,11,11 },
                 { 11,11,5,0,0,0,0,0,6,11,11 },
                 { 11,11,5,0,0,0,0,0,6,11,11 },
                 { 11,11,5,0,0,0,0,0,6,11,11 },
                 { 11,11,5,0,0,1,0,0,6,11,11 },
                 { 11,11,11,11,11,11,11,11,11,11,11 }
             };
        public int[,] pBT3 =
            {
                 { 11,7,4,4,4,12,4,4,4,8,11 },
                 { 11,5,0,0,3,0,0,0,0,6,11 },
                 { 11,5,0,0,0,3,3,0,0,6,11 },
                 { 11,5,2,0,2,0,2,0,0,6,11 },
                 { 11,5,0,2,0,2,0,3,3,6,11 },
                 { 11,5,0,0,2,0,2,3,3,6,11 },
                 { 11,5,3,2,0,2,0,0,0,6,11 },
                 { 11,5,0,0,0,0,0,0,0,6,11 },
                 { 11,5,0,0,0,0,0,0,0,6,11 },
                 { 11,5,0,0,0,1,0,0,0,6,11 },
                 { 11,11,11,11,11,11,11,11,11,11,11 }
             };
        public int[,] pBT4 =
            {
                 { 11,11,11,7,4,12,4,8,11,11,11 },
                 { 11,11,7,9,0,0,0,10,8,11,11 },
                 { 11,11,5,0,2,0,2,0,6,11,11 },
                 { 11,11,5,0,2,2,2,0,6,11,11 },
                 { 11,11,5,2,0,2,0,2,6,11,11 },
                 { 11,11,5,0,2,0,2,0,6,11,11 },
                 { 11,11,5,2,0,0,0,2,6,11,11 },
                 { 11,11,5,0,2,2,2,0,6,11,11 },
                 { 11,11,5,0,0,0,0,0,6,11,11 },
                 { 11,11,5,0,0,1,0,0,6,11,11 },
                 { 11,11,11,11,11,11,11,11,11,11,11 }
             };
        public int[,] pBT5 =
            {
                 { 11,11,11,7,4,12,4,8,11,11,11 },
                 { 7,4,4,9,0,2,0,10,4,4,8 },
                 { 5,0,0,0,2,0,2,0,0,0,6 },
                 { 5,0,2,0,2,0,2,0,2,0,6 },
                 { 5,3,0,3,0,3,0,3,0,3,6 },
                 { 5,0,2,0,2,0,2,0,2,0,6 },
                 { 5,3,0,3,0,3,0,3,0,3,6 },
                 { 5,0,2,0,2,0,2,0,2,0,6 },
                 { 5,0,0,2,2,2,2,2,0,0,6 },
                 { 5,0,0,0,0,1,0,0,0,0,6 },
                 { 11,11,11,11,11,11,11,11,11,11,11 }
             };
        public int[,] pBT6 =
            {
                 { 11,11,11,7,4,12,4,8,11,11,11 },
                 { 11,11,7,9,0,0,0,10,8,11,11 },
                 { 11,11,5,2,0,2,0,2,6,11,11 },
                 { 7,4,9,0,2,3,2,0,10,4,8 },
                 { 5,0,2,0,0,3,0,0,2,0,6 },
                 { 5,0,3,2,2,0,2,2,3,0,6 },
                 { 5,0,3,0,2,0,2,0,3,0,6 },
                 { 5,0,3,0,0,0,0,0,3,0,6 },
                 { 5,0,3,3,3,3,3,3,3,0,6 },
                 { 5,0,0,0,0,1,0,0,0,0,6 },
                 { 11,11,11,11,11,11,11,11,11,11,11 }
             };

        // Level switching 
        // if player is in Exit coordinates LevelSwitch method adds level and reloads the map
        // All existing entities are destroyed and the canvas is wiped clean before the new map generates
        public void LevelSwitch()
        {
            if (player.Switch == true)
            {

                level++;
                if (level == 1)
                {
                    pBT = pBT2;
                }
                if (level == 2)
                {
                    pBT = pBT3;
                }
                if (level == 3)
                {
                    pBT = pBT4;
                }
                if (level == 4)
                {
                    pBT = pBT5;
                }
                if (level == 5)
                {
                    pBT = pBT6;
                }

                if (level == 6)
                {
                    ((MainWindow)Application.Current.MainWindow).EndWindow();
                }

                // Deleting all entities and emptying the entity lists
                Boulds = null;
                Terrs = null;
                Walls = null;
                exit = null;

                player = null;
                boulder = null;
                terrain = null;
                wall = null;
                exit = null;

                // Removing existing items from the canvas
                MyCanvas.Children.Clear();

                // Creating the new level
                CreatePBT();
            }
        }

        // LevelReset resets the map if the player is stuck and cannot progress
        // Activates from the player clicking the reset button on screen
        public void LevelReset()
        {
            // Deleting all entities and emptying the entity list
            Boulds = null;
            Terrs = null;
            Walls = null;
            exit = null;

            player = null;
            boulder = null;
            terrain = null;
            wall = null;
            exit = null;

            // Removing existing items from the canvas
            MyCanvas.Children.Clear();

            // Creating the new level
            CreatePBT();
        }

        // Create level
        // Checks what element is in the (i,j) coordinates of the level's 2D integer list
        // Generates the appropriate entity
        public void CreatePBT()
        {
            // Lists of GameObjects introduced. Used for collision detection
            Boulds = new List<GameObject.Boulder>();
            Terrs = new List<GameObject.Terrain>();
            Walls = new List<GameObject.Wall>();
            Door = new List<GameObject.Exit>();
            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    // Block position on the canvas
                    int x = (50) * i; // 0, 50, 100...
                    int y = (50) * j; // 0, 50, 100...

                    // What to generate?
                    if (pBT[j, i] == 1) // Generate Player
                    {
                        player = new GameObject.Player
                        {
                            LocationX = x,
                            LocationY = y,
                            X = i,
                            Y = j
                        };
                        MyCanvas.Children.Add(player);
                        player.UpdatePosition();
                    }
                    else if (pBT[j, i] == 2) // Generate Boulder
                    {
                        boulder = new GameObject.Boulder
                        {
                            LocationX = x,
                            LocationY = y,
                            X = i,
                            Y = j
                        };
                        MyCanvas.Children.Add(boulder);
                        Boulds.Add(boulder);
                        boulder.UpdatePosition();
                    }
                    else if (pBT[j, i] == 3) // Generate Terrain
                    {
                        terrain = new GameObject.Terrain
                        {
                            LocationX = x,
                            LocationY = y,
                            X = i,
                            Y = j
                        };
                        MyCanvas.Children.Add(terrain);
                        Terrs.Add(terrain);
                        terrain.UpdatePosition();
                    }
                    else if (pBT[j, i] == 4) // Generate Wall(top)
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        MyCanvas.Children.Add(wall);
                        Walls.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 5) // Generate Wall(left)
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        MyCanvas.Children.Add(wall);
                        Walls.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 6) // Generate Wall(right)
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        MyCanvas.Children.Add(wall);
                        Walls.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 7) // Generate Wall(top-left corner)
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        Walls.Add(wall);
                        MyCanvas.Children.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 8) // Generate Wall(top-right corner)
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        MyCanvas.Children.Add(wall);
                        Walls.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 9) // Generate Wall(top-left reverse corner)
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        MyCanvas.Children.Add(wall);
                        Walls.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 10) // Generate Wall(top-right reverse corner)
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        MyCanvas.Children.Add(wall);
                        Walls.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 11) // Generate Wall without a texture. Used for the bottom wall
                    {
                        wall = new GameObject.Wall(pBT[j, i], x, y, i, j);
                        MyCanvas.Children.Add(wall);
                        Walls.Add(wall);
                        wall.UpdatePosition();
                    }
                    else if (pBT[j, i] == 12) // Generate Exit
                    {
                        exit = new GameObject.Exit
                        {
                            LocationX = x,
                            LocationY = y,
                            X = i,
                            Y = j
                        };
                        MyCanvas.Children.Add(exit);
                        Door.Add(exit);
                        exit.UpdatePosition();
                    }// if 0, generate nothing
                }
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            LevelReset();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MenuWindow();
        }

        // Movement --------------------------------------------------------------------------------
        // Sends the lists containing the other interactable objects (Walls, boulders etc...) to the player's move functions
        // The player entity then determines whether movement is possible
        // After a move either succeeds or fails, the step counter will increase by one
        // When a key is pressed...

        // End of class
    }
}
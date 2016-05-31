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
using System.Windows.Shapes;

namespace BoulderPusherWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainControl mainControl;
        public GameControl gameControl;
        public EndControl endControl;
        public CreditsControl creditsControl;


        public MainWindow()
        {
            InitializeComponent();
            MenuWindow();
        }

        public void MenuWindow()
        {
            gameControl = null;
            endControl = null;
            creditsControl = null;
            Ikkuna.Children.Clear();

            mainControl = new MainControl();
            Ikkuna.Children.Add(mainControl);
        }

        public void GameWindow()
        {
            mainControl = null;
            Ikkuna.Children.Clear();

            gameControl = new GameControl();
            Ikkuna.Children.Add(gameControl);
        }

        public void CreditsWindow()
        {
            mainControl = null;
            Ikkuna.Children.Clear();

            creditsControl = new CreditsControl();
            Ikkuna.Children.Add(creditsControl);
        }

        public void EndWindow()
        {
            gameControl = null;
            Ikkuna.Children.Clear();

            endControl = new EndControl();
            Ikkuna.Children.Add(endControl);
        }
    }
}
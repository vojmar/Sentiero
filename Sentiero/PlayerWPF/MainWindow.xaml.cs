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

namespace PlayerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool draging;

        public MainWindow()
        {
            InitializeComponent();
            Player.Play(Glovar.URL);
            Player.PositionChanged += Player_PositionChanged;
        }

        private void Player_PositionChanged(object sender, PositionArgs e)
        {
            MainWindow1.Title = Player.GetMediaName();
            Position.Maximum = e.duration;
            if (!draging)
            {
            Position.Value = e.current;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Player.GetPlayState() == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Player.Pause();
            }
            else
            {
                Player.Play();
            }
        }
        
        

        private void Position_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void Position_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Player.SetPosition(Position.Value);
            draging = false;
        }

        private void Position_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            draging = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MainWindow1.WindowStyle == WindowStyle.None)
            {
                MainWindow1.WindowStyle = WindowStyle.SingleBorderWindow;
                MainWindow1.WindowState = WindowState.Normal;
            }
            else
            {
                MainWindow1.WindowState = WindowState.Normal;
                MainWindow1.WindowStyle = WindowStyle.None;
                MainWindow1.WindowState = WindowState.Maximized;
            }
        }
    }
}

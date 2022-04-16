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

namespace DomeTD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer player = new MediaPlayer();
        public MainWindow()
        {
            InitializeComponent();
            player.Open(new Uri(string.Format("{0}\\bgmusic.mp3", AppDomain.CurrentDomain.BaseDirectory)));
            player.MediaEnded+=Player_MediaEnded;
            player.Volume=0.20;
            player.Play();

        }

        private void Player_MediaEnded(object? sender, EventArgs e)
        {
            player.Play();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            new GameWindow().Show();
            player.Stop();
            this.Close();

        }

        private void HowTo_Click(object sender, RoutedEventArgs e)
        {
            new HowToWindow().Show();
            player.Stop();
            this.Close();

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using DomeTD.Controller;
using DomeTD.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DomeTD
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameController controller;
        IGameModel gameModel;
        DispatcherTimer dt;
        DispatcherTimer dt2;
        TimeSpan time;
        DomeLogic logic = new DomeLogic();
        public GameWindow()
        {

            InitializeComponent();
            dt2 = new DispatcherTimer();
            dt2.Interval = TimeSpan.FromSeconds(1);
            dt2.Tick += (sender, eargs) =>
            {
                for (int i = 0; i < logic.Enemies.Count; i++)
                {
                    logic.MoveEnemy(logic.Enemies[i]);
                }
                display.InvalidateVisual();
            };
            time = TimeSpan.FromSeconds(5);
            dt = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timer.Content = time.ToString("c");
                if (time == TimeSpan.Zero)
                {
                    dt.Stop();
                    dt2.Start();
                };
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
            dt.Start();


            display.SetupModel(logic);
            controller = new GameController(logic);
            Binding dirtbinding = new Binding("Dirt");
            dirtbinding.Source = logic.Inventory;
            dirt.SetBinding(Label.ContentProperty, dirtbinding);

            Binding metalbinding = new Binding("Metal");
            metalbinding.Source = logic.Inventory;
            metal.SetBinding(Label.ContentProperty, metalbinding);

            Binding vibbinding = new Binding("Vibranium");
            vibbinding.Source = logic.Inventory;
            vibranium.SetBinding(Label.ContentProperty, vibbinding);

            Binding drillbinding = new Binding("DrillingPower");
            drillbinding.Source = logic.Hero;
            drill.SetBinding(Label.ContentProperty, drillbinding);

            Binding weaponbinding = new Binding("AttackDamage");
            weaponbinding.Source = logic.Dome;
            weapon.SetBinding(Label.ContentProperty, weaponbinding);

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            controller.KeyPressed(e.Key);
            display.InvalidateVisual();
        }

        private void weaponbutton_Click(object sender, RoutedEventArgs e)
        {

            logic.Dome.AttackDamage++;
            display.InvalidateVisual();
        }

        private void drillbutton_Click(object sender, RoutedEventArgs e)
        {
            logic.Hero.DrillingPower++;
            display.InvalidateVisual();

        }
    }
}

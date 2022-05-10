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
        DispatcherTimer dt;
        DispatcherTimer dt2;
        DispatcherTimer dt3;
        DispatcherTimer dt4;
        TimeSpan time;
        DomeLogic logic = new DomeLogic();
        CanvasLogic clogic;
        public GameWindow()
        {

            InitializeComponent();
            cdisplay.InvalidateVisual();
            controller = new GameController(logic);
            
            display.SetupModel(logic);

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

            Binding drillupg = new Binding("DrillingpowerupgCost");
            drillupg.Source = logic.Hero;
            drillupgrade.SetBinding(Button.ContentProperty, drillupg);

            display.InvalidateVisual();
            cdisplay.InvalidateVisual();
            
            }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            display.InvalidateVisual();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double center= (canvas.ActualWidth - timer.ActualWidth) / 2;
            Canvas.SetLeft(metal, dirt.ActualWidth+10);
            Canvas.SetLeft(timer, center);
            Canvas.SetLeft(wpupgrade, canvas.ActualWidth-wpupgrade.ActualWidth);
            Canvas.SetLeft(drillupgrade, canvas.ActualWidth-wpupgrade.ActualWidth-drillupgrade.ActualWidth-15);
            Canvas.SetLeft(vibranium, dirt.ActualWidth+10+metal.ActualWidth+10);
            Canvas.SetLeft(hpbar,5);
            Canvas.SetTop(weapon, dirt.ActualHeight+20);
            Canvas.SetTop(drill, dirt.ActualHeight+20+weapon.ActualHeight+20);
            Canvas.SetTop(hp, dirt.ActualHeight+20+weapon.ActualHeight+20+hp.ActualHeight+50);
            Canvas.SetTop(hpbar, dirt.ActualHeight+20+weapon.ActualHeight+20+hp.ActualHeight+50+hpbar.ActualHeight+10);
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            clogic=new CanvasLogic(canvas.ActualWidth, canvas.ActualHeight);
            clogic.GameOver+=Clogic_GameOver;

            Binding hpbinding = new Binding("Health");
            hpbinding.Source = clogic.Dome;
            hpbar.SetBinding(ProgressBar.ValueProperty, hpbinding);

            Binding attackpower = new Binding("CurrentDMG");
            attackpower.Source = clogic;
            weapon.SetBinding(Label.ContentProperty, attackpower);

            Binding wpupg = new Binding("WeaponUpgradeCost");
            wpupg.Source = clogic;
            wpupgrade.SetBinding(Button.ContentProperty, wpupg);

            Binding domehp = new Binding("Health");
            domehp.Source = clogic.Dome;
            hp.SetBinding(Label.ContentProperty, domehp);

            cdisplay.SetupModel(clogic);
            display.InvalidateVisual();
            cdisplay.InvalidateVisual();
            dt4=new DispatcherTimer();
            dt4.Interval=TimeSpan.FromSeconds(15);
            dt3=new DispatcherTimer();
            dt3.Interval=TimeSpan.FromMilliseconds(10);
            dt4.Tick +=(sender, eargs) =>
            {
                clogic.AddLaser();
                dt3.Tick +=(sender, eargs) =>
                {
                        clogic.Shoot();
                        cdisplay.InvalidateVisual();
                };
                cdisplay.InvalidateVisual();
                if (clogic.Enemies.Count<=0)
                {
                    clogic.Lasers.Clear();
                    dt3.Stop();
                    dt4.Stop();
                    time=TimeSpan.FromSeconds(5);
                    dt.Start();
                }
            };
            dt2 = new DispatcherTimer();
            dt2.Interval=TimeSpan.FromMilliseconds(20);
            dt2.Tick +=(sender, eargs) =>
            {
                
                    clogic.MoveEnemy();
                    cdisplay.InvalidateVisual();
                
            };
            time = TimeSpan.FromSeconds(5);
            dt = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timer.Content = time.ToString("c");
                if (time == TimeSpan.Zero)
                {
                    dt.Stop();
                    dt2.Start();
                    dt3.Start();
                    dt4.Start();
                    clogic.SpawnEnemies();
                };
                time = time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);
        }

        private void Clogic_GameOver(object? sender, EventArgs e)
        {
            var result = MessageBox.Show($"Game Over\n Number of enemies killed {clogic.EnemiesKilled}");
            if (result == MessageBoxResult.OK)
            {
                
                new MainWindow().Show();
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            controller.KeyPressed(e.Key);
           
            display.InvalidateVisual();
            cdisplay.InvalidateVisual();
        }

        private void weaponbutton_Click(object sender, RoutedEventArgs e)
        {
            
            if (logic.Inventory.Metal >= clogic.WeaponUpgradeCost)
            {
                    clogic.CurrentDMG++;
                    logic.Inventory.Metal-= clogic.WeaponUpgradeCost;
                    clogic.WeaponUpgradeCost++;
                    display.InvalidateVisual();
                    cdisplay.InvalidateVisual();
            }
        }

        private void drillbutton_Click(object sender, RoutedEventArgs e)
        {
            if (logic.Inventory.Metal >= logic.Hero.DrillingpowerupgCost)
            {
                logic.Hero.DrillingPower++;
                logic.Inventory.Metal -= logic.Hero.DrillingpowerupgCost;
                logic.Hero.DrillingpowerupgCost++;
                display.InvalidateVisual();
                cdisplay.InvalidateVisual();
            }

        }
    }
}

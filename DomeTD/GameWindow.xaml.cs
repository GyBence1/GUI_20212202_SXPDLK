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
        DispatcherTimer dt5;
        DispatcherTimer dt6;
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



            dt6 = new DispatcherTimer();
            dt6.Interval = TimeSpan.FromMilliseconds(100);
            dt6.Tick += (sender, args) =>
            {
                if (logic.Hero.DrillingpowerupgCost > 5)
                {
                    Binding drillupginvib = new Binding("DrillingpowerupgCostInVib");
                    drillupginvib.Source = logic.Hero;
                    drillupgrade.ContentStringFormat = "Drill Upgrade Cost: {0} vibranium";
                    drillupgrade.SetBinding(Button.ContentProperty, drillupginvib);
                }
                else
                {
                    Binding drillupg = new Binding("DrillingpowerupgCost");
                    drillupg.Source = logic.Hero;
                    drillupgrade.ContentStringFormat = "Drill Upgrade Cost: {0} metal";
                    drillupgrade.SetBinding(Button.ContentProperty, drillupg);
                }
            };
            dt6.Start();
            //dt5.Tick += (sender, args) =>
            //{
            //    if (clogic.WeaponUpgradeCost > 5)
            //    {
            //        Binding wpupgvib = new Binding("WeaponUpgradeCostinVib");
            //        wpupgvib.Source = clogic;
            //        wpupgrade.ContentStringFormat = "Weapon Upgrade Cost: {0} vibranium";
            //        wpupgrade.SetBinding(Button.ContentProperty, wpupgvib);
            //    }
            //    else
            //    {
            //        Binding wpupg = new Binding("WeaponUpgradeCost");
            //        wpupg.Source = clogic;
            //        wpupgrade.ContentStringFormat = "Weapon Upgrade Cost: {0} metal";
            //        wpupgrade.SetBinding(Button.ContentProperty, wpupg);
            //    }
            //};
            //dt5.Start();



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
            display.Resize(new Size(grid.ActualWidth, grid.ActualHeight));
            clogic=new CanvasLogic(canvas.ActualWidth, canvas.ActualHeight);
           
            Binding attackpower = new Binding("CurrentDMG");
            attackpower.Source = clogic;
            weapon.SetBinding(Label.ContentProperty, attackpower);

            dt5 = new DispatcherTimer();
            dt5.Interval = TimeSpan.FromMilliseconds(100);
            dt5.Tick += (sender, args) =>
            {
                if (clogic.WeaponUpgradeCost > 5)
                {
                    Binding wpupgvib = new Binding("WeaponUpgradeCostinVib");
                    wpupgvib.Source = clogic;
                    wpupgrade.ContentStringFormat = "Weapon Upgrade Cost: {0} vibranium";
                    wpupgrade.SetBinding(Button.ContentProperty, wpupgvib);
                }
                else
                {
                    Binding wpupg = new Binding("WeaponUpgradeCost");
                    wpupg.Source = clogic;
                    wpupgrade.ContentStringFormat = "Weapon Upgrade Cost: {0} metal";
                    wpupgrade.SetBinding(Button.ContentProperty, wpupg);
                }
            };
            dt5.Start();
            

            cdisplay.SetupModel(clogic);
            display.InvalidateVisual();
            cdisplay.InvalidateVisual();
            dt4=new DispatcherTimer();
            dt4.Interval=TimeSpan.FromSeconds(3);
            dt3=new DispatcherTimer();
            dt3.Interval=TimeSpan.FromMilliseconds(200);
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
                    clogic.Enemies.Clear();
                    clogic.Lasers.Clear();
                    dt3.Stop();
                    dt4.Stop();
                    time=TimeSpan.FromSeconds(5);
                    dt.Start();
                }
            };
            dt2 = new DispatcherTimer();
            dt2.Interval=TimeSpan.FromMilliseconds(500);
            dt2.Tick +=(sender, eargs) =>
            {
                for (int i = 0; i < clogic.Enemies.Count; i++)
                {
                    clogic.MoveEnemy();
                    cdisplay.InvalidateVisual();
                }
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

       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            controller.KeyPressed(e.Key);
           
            display.InvalidateVisual();
            cdisplay.InvalidateVisual();
        }

        private void weaponbutton_Click(object sender, RoutedEventArgs e)
        { 
            if (clogic.WeaponUpgradeCost > 5)
            {
                if (logic.Inventory.Vibranium >= clogic.WeaponUpgradeCostinVib)
                {
                    clogic.CurrentDMG++;
                    logic.Inventory.Vibranium -= clogic.WeaponUpgradeCostinVib;
                    clogic.WeaponUpgradeCostinVib++;
                    display.InvalidateVisual();
                    cdisplay.InvalidateVisual();
                }
            }
            else
            {
                if (logic.Inventory.Metal >= clogic.WeaponUpgradeCost)
                {
                    clogic.CurrentDMG++;
                    logic.Inventory.Metal -= clogic.WeaponUpgradeCost;
                    clogic.WeaponUpgradeCost++;
                    display.InvalidateVisual();
                    cdisplay.InvalidateVisual();
                }
            }
           
        }

        private void drillbutton_Click(object sender, RoutedEventArgs e)
        {
            if (logic.Hero.DrillingpowerupgCost>5)
            {
                if (logic.Inventory.Vibranium >= logic.Hero.DrillingpowerupgCostInVib)
                {
                    logic.Hero.DrillingPower++;
                    logic.Inventory.Vibranium -= logic.Hero.DrillingpowerupgCostInVib;
                    logic.Hero.DrillingpowerupgCostInVib++;
                    display.InvalidateVisual();
                    cdisplay.InvalidateVisual();
                }
            }
            else
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
}

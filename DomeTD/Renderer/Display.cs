using DomeTD.Logic;
using DomeTD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DomeTD.Renderer
{
    public class Display : FrameworkElement
    {
        IGameModel model;
        Size size;

        public void Resize(Size size)
        {
            this.size = size;
        }

        public void SetupModel(IGameModel model)
        {
            this.model=model;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model!=null)
            {
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                double rectHeight = size.Height / model.GameMatrix.GetLength(0);

                ImageBrush enemybrush = new ImageBrush(new BitmapImage(new Uri("Images/enemy.bmp", UriKind.RelativeOrAbsolute)));
                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();
                        ImageBrush domebrush = new ImageBrush();
                        SolidColorBrush bgbrush = new SolidColorBrush();
                        switch (model.GameMatrix[i, j])
                        {
                            case Dirt:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/dirt.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case Border:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/border.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case Metal:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/metal.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case Vibranium:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/vibranium.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case Floor:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/floor.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case MainCharacter:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/character.bmp", UriKind.RelativeOrAbsolute)));
                                break;

                            case Enemy:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/enemy.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case Laser:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/laser.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case Dome:
                                domebrush = new ImageBrush
                                    (new BitmapImage(new Uri("Images/dome1.bmp", UriKind.RelativeOrAbsolute)));
                                break;
                            case BGround:
                                bgbrush = Brushes.Transparent;
                                break;
                            default:
                                break;
                        }
                        drawingContext.DrawRectangle(brush
                                    , new Pen(Brushes.Black, 0),
                                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight));
                        drawingContext.DrawRectangle(bgbrush
                                   , new Pen(Brushes.Black, 0),
                                   new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight));
                        drawingContext.DrawRectangle(domebrush
                                  , new Pen(Brushes.Black, 0),
                                  new Rect(j * rectWidth, i * rectHeight-200, 300,300));
                       
                    }

                }
            }
        }
    }
}
    


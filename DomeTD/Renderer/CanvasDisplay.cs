using DomeTD.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DomeTD.Renderer
{
    public class CanvasDisplay:FrameworkElement
    {
        ICanvasItem model;

        public void SetupModel(ICanvasItem model)
        {
            this.model=model;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            ImageBrush domebrush = new ImageBrush(new BitmapImage(new Uri("Images/dome1.bmp", UriKind.RelativeOrAbsolute)));
            ImageBrush enemybrush = new ImageBrush(new BitmapImage(new Uri("Images/enemy.bmp", UriKind.RelativeOrAbsolute)));
            ImageBrush laserbrush = new ImageBrush(new BitmapImage(new Uri("Images/laser.bmp", UriKind.RelativeOrAbsolute)));
            if (model!=null)
            {
                drawingContext.DrawGeometry(domebrush, null, model.Dome.Area);
                foreach (var item in model.Lasers)
                {
                    drawingContext.DrawGeometry(laserbrush, null, item.Area);
                }
                foreach (var item in model.Enemies)
                {
                    if (item.Health>0)
                    {
                        drawingContext.DrawGeometry(enemybrush, null, item.Area);
                    }
                }
            }
        }
    }
}

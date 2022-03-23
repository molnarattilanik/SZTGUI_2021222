using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Circles
{
    public class Display : FrameworkElement
    {
        private static Random random = new Random();

        private double areaWidth;
        private double areaHeight;

        public void Resize(double areaWidth, double areaHeight)
        {
            this.areaHeight = areaHeight;
            this.areaWidth = areaWidth;
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.areaWidth > 0 && this.ActualHeight > 0)
            {
                base.OnRender(drawingContext);
                int count = random.Next(20, 40);
                for (int i = 0; i < count; i++)
                {
                    int size = random.Next(10, 50);
                    drawingContext.DrawEllipse(
                        new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))),
                        new Pen(new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))), random.Next(1, 5)),
                        new Point(random.Next(0 + size, (int)areaWidth - size), random.Next(0 + size, (int)areaHeight - size)),
                        size, size
                        );
                }
            }
        }
    }
}

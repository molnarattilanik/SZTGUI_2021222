using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Rectengales
{
    public class Display : FrameworkElement
    {
        private Size size;
        static Random random = new Random();
        public void Resize(Size size)
        {
            this.size = size;
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (size.Width > 0 && size.Height > 0)
            {
                int row = random.Next(1, 30);
                int column = random.Next(1, 30);


                double rectWidth = size.Width / column;
                double rectHeight = size.Height / row;


                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        drawingContext.DrawRectangle(
                            new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))),
                            new Pen(Brushes.Black, 0),
                            new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                            );
                    }
                }
            }
           
        }
    }
}


/*
    int size = random.Next(10, 50);
                    drawingContext.DrawEllipse(
                        new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))),
                        new Pen(new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255))), random.Next(1, 5)),
                        new Point(random.Next(0 + size, (int)areaWidth - size), random.Next(0 + size, (int)areaHeight - size)),
                        size, size
                        );*/
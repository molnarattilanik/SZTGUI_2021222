using System;
using System.Windows;
using System.Windows.Media;

namespace FlappyBird.Logic
{
    public class Column : GameElement
    {
        private static Random rnd = new Random();
        double areaHeight, areaWidth;

        public event EventHandler GetPoint;

        public Column(double areaWidth, double areaHeight, int cx)
        {
            this.areaWidth = areaWidth;
            this.areaHeight = areaHeight;
            this.centerX = cx;
            ColumnGenarator();
        }

        private void ColumnGenarator()
        {
            centerY = rnd.Next(3 * Bird.Radius, (int)areaHeight - 3 * Bird.Radius);

            Geometry rg1 = new RectangleGeometry(new Rect(Bird.Radius, -centerY, 2 * Bird.Radius, centerY - 3 * Bird.Radius));

            Geometry rg2 = new RectangleGeometry(new Rect(Bird.Radius, 10 * Bird.Radius, 2 * Bird.Radius, areaHeight - centerY - 3 * Bird.Radius));

            area = Geometry.Combine(rg1, rg2, GeometryCombineMode.Union, null);
        }

        public void Mozog(double areaWidth)
        {
            if (centerX + Bird.Radius <= 0)
            {
                centerX = (int)areaWidth + Bird.Radius;
                ColumnGenarator();

                GetPoint?.Invoke(this, null);
            }
            centerX--;
        }
    }
}

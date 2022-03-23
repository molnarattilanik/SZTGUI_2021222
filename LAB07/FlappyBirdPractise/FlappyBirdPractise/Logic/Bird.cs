using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace FlappyBird.Logic
{
    public class Bird : GameElement
    {
        public const int Radius = 20;
        private int directionY;

        public Bird()
        {
            centerX = 40;
            centerY = 100;
            directionY = 0;

            Geometry ellipseGeometry = new EllipseGeometry(new System.Windows.Point(0, 0), Radius, Radius);

            PathFigure pathFigure = new PathFigure(new System.Windows.Point(1.5 * Radius, 0), new List<LineSegment>() {
                new LineSegment(new System.Windows.Point(0, Radius), true),
                new LineSegment(new System.Windows.Point(0, -Radius), true),
                new LineSegment(new System.Windows.Point(1.5*Radius, 0), true),
            }, true);

            Geometry pathGeometry = new PathGeometry(new PathFigure[] { pathFigure });

            area = Geometry.Combine(ellipseGeometry, pathGeometry, GeometryCombineMode.Union, null);
        }

        public void Move(double areaHeight)
        {
            centerY += directionY;
            directionY++;

            if (centerY + Radius >= areaHeight)
            {
                directionY = 0;
                centerY = (int)areaHeight - Radius;
            }

            rotation = (Math.Atan2(directionY, Radius / 2) / Math.PI) * 180;
        }

        public void Jump()
        {
            directionY -= 15;
        }
    }
}

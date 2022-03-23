using System.Windows.Media;

namespace FlappyBird.Logic
{
    public abstract class GameElement
    {
        protected int centerX, centerY;
        protected double rotation;
        protected Geometry area;

        public Geometry Area
        {
            get
            {
                TransformGroup transformGroup = new TransformGroup();
                transformGroup.Children.Add(new TranslateTransform(centerX, centerY));
                transformGroup.Children.Add(new RotateTransform(rotation, centerX, centerY));
                area.Transform = transformGroup;
                return area;
            }
        }

        public bool IsCollisions(GameElement otherGameElement)
        {
            return Geometry.Combine(this.Area, otherGameElement.Area, GeometryCombineMode.Intersect, null).GetArea() > 0;
        }
    }
}

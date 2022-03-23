using FlappyBird.Logic;
using System.Windows;
using System.Windows.Media;

namespace FlappyBird
{
    public class Display : FrameworkElement
    {
        public void SetupDisplay(IFlappyModel flappyModel)
        {
            this.flappyModel = flappyModel;
            InvalidateVisual();
        }

        public IFlappyModel flappyModel;

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (flappyModel is not null)
            {
                drawingContext.DrawGeometry(Brushes.Orange, new Pen(Brushes.Black, 1), flappyModel.Bird.Area);
                if (flappyModel.Columns != null)
                    foreach (var column in flappyModel.Columns)
                        drawingContext.DrawGeometry(Brushes.Green, new Pen(Brushes.Black, 1), column.Area);


#pragma warning disable CS0618 // Type or member is obsolete
                FormattedText text = new FormattedText(
                    $"Élet:{flappyModel.Life}, pontok: {flappyModel.Points}",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.ExtraBold, FontStretches.Normal),
                    12,
                    Brushes.Black);
#pragma warning restore CS0618 // Type or member is obsolete

                Geometry textGeometry = text.BuildGeometry(new Point(10, 10));


                drawingContext.DrawGeometry(Brushes.Black, null, textGeometry);
            }
        }
    }
}

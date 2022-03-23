using Laby.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Laby.Renderer
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
            this.model = model;
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (model is not null && size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.GameMatrix.GetLength(1);
                double rectHeight = size.Height / model.GameMatrix.GetLength(0);


                drawingContext.DrawRectangle(
                                   Brushes.Black,
                                   new Pen(Brushes.Black, 0),
                                   new Rect(0, 0, size.Width, size.Height)
                                   );


                for (int i = 0; i < model.GameMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameMatrix.GetLength(1); j++)
                    {
                        ImageBrush brush = new ImageBrush();
                        switch (model.GameMatrix[i,j])
                        {
                            case LabyLogic.LabyItem.player:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "player.bmp"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.wall:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "wall.bmp"), UriKind.RelativeOrAbsolute)));
                                break;
                            case LabyLogic.LabyItem.floor:
                                break;
                            case LabyLogic.LabyItem.door:
                                brush = new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "exit.bmp"), UriKind.RelativeOrAbsolute)));
                                break;
                            default:
                                break;
                        }

                        drawingContext.DrawRectangle(
                                    brush,
                                    new Pen(Brushes.Black, 0),
                                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                    );
                    }
                }

            }
        }
    }
}

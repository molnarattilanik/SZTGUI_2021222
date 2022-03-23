using System;
using System.Collections.Generic;

namespace FlappyBird.Logic
{
    public class FlappyLogic : IFlappyModel
    {
        public Bird Bird { get; set; }
        public List<Column> Columns { get; set; }
        public int Points { get; set; }
        public int Life { get; set; }

        public event EventHandler GameOver;

        bool collided = false;
        public FlappyLogic(double areaWidth, double areaHeight)
        {
            Bird = new Bird();
            Columns = new List<Column>();
            Life = 3;

            int res = (int)((areaWidth - 6 * Bird.Radius) / 4);

            for (int i = 0; i < 4; i++)
            {
                Column column = new Column(areaWidth, areaHeight, res + Bird.Radius + i * (res + 2 * Bird.Radius));
                column.GetPoint += Column_GetPoint; ;
                Columns.Add(column);
            }
        }

        private void Column_GetPoint(object sender, EventArgs e)
        {
            Points++;
        }

        public void TimeStep(double actualWidth, double actualHeight)
        {
            Bird.Move(actualHeight);
            foreach (var column in Columns)
            {
                column.Mozog(actualWidth);
            }
            bool nowcollided = false;
            foreach (var column in Columns)
            {
                if (Bird.IsCollisions(column))
                {
                    if (!collided)
                    {
                        this.Life--;
                        if (Life <= 0)
                        {
                            GameOver?.Invoke(this, null);
                        }
                    }
                    nowcollided = true;
                }
            }
            collided = nowcollided;
        }
    }
}

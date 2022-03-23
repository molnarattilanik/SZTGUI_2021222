using System.Collections.Generic;

namespace FlappyBird.Logic
{
    public interface IFlappyModel
    {
        Bird Bird { get; set; }
        List<Column> Columns { get; set; }
        int Life { get; set; }
        int Points { get; set; }
    }
}
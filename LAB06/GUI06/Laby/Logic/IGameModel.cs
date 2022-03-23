using static Laby.Logic.LabyLogic;

namespace Laby.Logic
{
    public interface IGameModel
    {
        LabyItem[,] GameMatrix { get; set; }
    }
}
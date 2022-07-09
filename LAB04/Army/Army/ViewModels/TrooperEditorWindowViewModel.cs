using Army.Models;

namespace Army.ViewModels
{
    public class TrooperEditorWindowViewModel
    {
        public Trooper Actual { get; set; }

        public void SetUp(Trooper trooper)
        {
            Actual = trooper;
        }

        public TrooperEditorWindowViewModel() {}
    }
}

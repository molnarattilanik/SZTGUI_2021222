using Army.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.ViewModels
{
    public class TrooperEditorWindowViewModel
    {
        public Trooper Actual { get; set; }

        public void SetUp(Trooper trooper)
        {
            Actual = trooper;
        }
        public TrooperEditorWindowViewModel()
        {
        }
    }
}

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiniEditor
{
    public class Person : INotifyPropertyChanged
    {
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public int Age { get => age; set { age = value; OnPropertyChanged(); } }

        private string haveGlasses;
        private int age;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string HaveGlasses
        {
            get { return haveGlasses; }
            set { haveGlasses = value; OnPropertyChanged(); }
        }
    }
}

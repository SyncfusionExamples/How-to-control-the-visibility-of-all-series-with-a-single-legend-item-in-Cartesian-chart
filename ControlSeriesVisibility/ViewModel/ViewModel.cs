using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ControlSeriesVisibility
{
    public class ViewModel : INotifyPropertyChanged
    {
        public List<Model> Data1 { get; set; }

        public List<Model> Data2 { get; set; }

        public List<Model> Data3 { get; set; }

        private bool isSeriesVisible = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsSeriesVisible
        {
            get { return isSeriesVisible; }
            set
            {
                isSeriesVisible = value;
                OnPropertyChanged(nameof(IsSeriesVisible));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModel()
        {
            Data1 = new List<Model>()
            {
                new Model { XValue = 1, YValue = 170 },
                new Model { XValue = 2, YValue = 96 },
                new Model { XValue = 3, YValue = 65 },
                new Model { XValue = 4, YValue = 96 },
                new Model { XValue = 5, YValue = 182 },
                new Model { XValue = 6, YValue = 134 }
            };

            Data2 = new List<Model>()
            {
                new Model { XValue = 1, YValue = 70 },
                new Model { XValue = 2, YValue = 36 },
                new Model { XValue = 3, YValue = 25 },
                new Model { XValue = 4, YValue = 56 },
                new Model { XValue = 5, YValue = 42 },
                new Model { XValue = 6, YValue = 34 }
            };

            Data3 = new List<Model>()
            {
                new Model { XValue = 1, YValue = 270 },
                new Model { XValue = 2, YValue = 196 },
                new Model { XValue = 3, YValue = 165 },
                new Model { XValue = 4, YValue = 196 },
                new Model { XValue = 5, YValue = 282 },
                new Model { XValue = 6, YValue = 234 }
            };
        }
    }

}

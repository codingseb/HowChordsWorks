using ReactiveUI.Fody.Helpers;

namespace HowChordsWorks.ViewModels
{
    public class SectorElement : ViewModelBase
    {
        [Reactive]
        public string Name { get; set; }
        public int Index { get; set; }

        public double Angle => Index * 30;
    }
}

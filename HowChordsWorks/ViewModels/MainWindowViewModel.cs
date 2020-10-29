using DynamicData.Annotations;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace HowChordsWorks.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        [Reactive]
        public bool UseSharpsNotes { get; set; } = true;

        public List<string> SharpsNotes { get; set; } = new List<string>() { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        public List<string> BemolsNotes { get; set; } = new List<string>() { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

        public ObservableCollection<SectorElement> MajorFifths { get; } = new ObservableCollection<SectorElement>();
        public ObservableCollection<SectorElement> MinorFifths { get; } = new ObservableCollection<SectorElement>();

        public MainWindowViewModel()
        {
            List<string> noteList = UseSharpsNotes ? SharpsNotes : BemolsNotes;

            for (int i = 0; i < 12; i++)
            {
                MajorFifths.Add(new SectorElement()
                {
                    Name = noteList[i * 7 % 12],
                    Index = i
                });
                MinorFifths.Add(new SectorElement()
                {
                    Name = noteList[(i + 3) * 7 % 12] + "m",
                    Index = i
                });
            }

            this.WhenAnyValue(x => x.UseSharpsNotes)
                .Subscribe(onNext: _ => this.RefreshChordsNames());
        }

        public void RefreshChordsNames()
        {
            List<string> noteList = UseSharpsNotes ? SharpsNotes : BemolsNotes;

            for (int i = 0; i < 12; i++)
            {
                MajorFifths[i].Name = noteList[i * 7 % 12];
                MinorFifths[i].Name = noteList[(i + 3) * 7 % 12] + "m";
            }
        }
    }
}

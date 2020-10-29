using HowChordsWorks.ViewModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace HowChordsWorks.Models
{
    public class Config : ViewModelBase
    {
        private int colorHueShift;

        [Reactive]
        public int ColorHueShift
        {
            get => colorHueShift;
            set 
            {
                int res = value;
                if(res < 0)
                {
                    res = 359;
                }
                else if(res > 359)
                {
                    res = 0;
                }

                this.RaiseAndSetIfChanged(ref colorHueShift, value); 
            }
        }

        #region Singleton          

        private static Config instance;
        

        public static Config Instance => instance ??= new Config();

        private Config()
        { }

        #endregion
    }
}

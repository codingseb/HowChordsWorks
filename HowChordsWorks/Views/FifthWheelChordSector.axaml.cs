using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace HowChordsWorks.Views
{
    public class FifthWheelChordSector : UserControl
    {
        public static readonly StyledProperty<double> RadiusProperty =
            AvaloniaProperty.Register<FifthWheelChordSector, double>(nameof(Radius));

        public double Radius
        {
            get { return GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly StyledProperty<double> InnerRadiusProperty =
            AvaloniaProperty.Register<FifthWheelChordSector, double>(nameof(InnerRadius));

        public double InnerRadius
        {
            get { return GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        public FifthWheelChordSector()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

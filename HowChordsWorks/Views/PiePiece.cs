using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;

namespace HowChordsWorks.Views
{
    public class PiePiece : Shape
    {
        #region styled properties

        public static readonly StyledProperty<double> AngleProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(Angle));

        public double Angle
        {
            get { return GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly StyledProperty<double> RadiusProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(Radius));

        public double Radius
        {
            get { return GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public static readonly StyledProperty<double> InnerRadiusProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(InnerRadius));

        public double InnerRadius
        {
            get { return GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }
        #endregion

        public PiePiece()
        {
            AffectsGeometry<PiePiece>(RadiusProperty, InnerRadiusProperty, AngleProperty);
        }

        protected override Geometry CreateDefiningGeometry()
        {
            // Create a StreamGeometry for describing the shape
            StreamGeometry geometry = new StreamGeometry();

            using (StreamGeometryContext context = geometry.Open())
            {
                DrawGeometry(context);
            }

            return geometry;
        }

        /// <summary>
        /// Draws the pie piece
        /// </summary>
        private void DrawGeometry(StreamGeometryContext context)
        {
            double halfAngle = Angle / 2;

            double outerWidth = Radius * Math.Sin(ConvertToRadians(halfAngle));
            double innerWidth = InnerRadius * Math.Sin(ConvertToRadians(halfAngle));
            double innerLeft = outerWidth - innerWidth;
            double innerRight = outerWidth + innerWidth;
            double outerH = Radius * Math.Cos(ConvertToRadians(halfAngle));
            double beginY =  Radius - outerH + StrokeThickness;
            double h = outerH - (InnerRadius * Math.Cos(ConvertToRadians(halfAngle))) + beginY;

            context.BeginFigure(new Point(0, beginY), true);
            context.ArcTo(new Point(outerWidth * 2, beginY), new Size(Radius, Radius), 0, false, SweepDirection.Clockwise);
            context.LineTo(new Point(innerRight, h));
            context.ArcTo(new Point(innerLeft, h), new Size(InnerRadius, InnerRadius), 0, false, SweepDirection.CounterClockwise);

            context.EndFigure(true);
        }

        private static double ConvertToRadians(double angle)
        {
            return Math.PI / 180 * angle;
        }
    }
}

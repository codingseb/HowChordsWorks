using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;

namespace HowChordsWorks.Views
{
    public class PiePiece : Shape
    {
        #region styled properties

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
            double outerWidth = (Radius * Math.Sin(ConvertToRadians(15)));
            double innerWidth = (InnerRadius * Math.Sin(ConvertToRadians(15)));
            double innerLeft = outerWidth - innerWidth;
            double innerRight = outerWidth + innerWidth;
            double outerH = (Radius * Math.Cos(ConvertToRadians(15)));
            double beginY =  Radius - outerH + StrokeThickness;
            double h = outerH - (InnerRadius * Math.Cos(ConvertToRadians(15))) + beginY;

            context.BeginFigure(new Point(0, beginY), true);
            context.ArcTo(new Point(outerWidth * 2, beginY), new Size(Radius, Radius), 0, false, SweepDirection.Clockwise);
            context.LineTo(new Point(innerRight, h));
            context.ArcTo(new Point(innerLeft, h), new Size(InnerRadius, InnerRadius), 0, false, SweepDirection.CounterClockwise);

            context.EndFigure(true);
        }

        private static Point ToCartesianPoint(double angle, double radius)
        {
            // convert to radians
            double angleRad = ConvertToRadians((angle + 360) % 360);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }

        private static double ConvertToRadians(double angle)
        {
            return Math.PI / 180 * angle;
        }
    }
}

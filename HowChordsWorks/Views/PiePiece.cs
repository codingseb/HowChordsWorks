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

        public static readonly StyledProperty<double> PushOutProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(PushOut));

        public double PushOut
        {
            get { return GetValue(PushOutProperty); }
            set { SetValue(PushOutProperty, value); }
        }

        public static readonly StyledProperty<double> InnerRadiusProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(InnerRadius));

        public double InnerRadius
        {
            get { return GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        public static readonly StyledProperty<double> WedgeAngleProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(WedgeAngle));

        public double WedgeAngle
        {
            get { return GetValue(WedgeAngleProperty); }
            set { SetValue(WedgeAngleProperty, value); }
        }

        public static readonly StyledProperty<double> RotationAngleProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(RotationAngle));

        public double RotationAngle
        {
            get { return GetValue(RotationAngleProperty); }
            set { SetValue(RotationAngleProperty, value); }
        }

        public static readonly StyledProperty<double> CenterXProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(CenterX));

        public double CenterX
        {
            get { return GetValue(CenterXProperty); }
            set { SetValue(CenterXProperty, value); }
        }

        public static readonly StyledProperty<double> CenterYProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(CenterY));

        public double CenterY
        {
            get { return GetValue(CenterYProperty); }
            set { SetValue(CenterYProperty, value); }
        }

        public static readonly StyledProperty<double> PercentageProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(Percentage));

        public double Percentage
        {
            get { return GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public static readonly StyledProperty<double> PieceValueProperty =
            AvaloniaProperty.Register<PiePiece, double>(nameof(PieceValue));

        public double PieceValue
        {
            get { return GetValue(PieceValueProperty); }
            set { SetValue(PieceValueProperty, value); }
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
            Point startPoint = new Point(CenterX, CenterY);

            Point innerArcStartPoint = ToCartesianPoint(RotationAngle, InnerRadius);

            innerArcStartPoint = new Point(innerArcStartPoint.X + CenterX, innerArcStartPoint.Y + CenterY);

            Point innerArcEndPoint = ToCartesianPoint(RotationAngle + WedgeAngle, InnerRadius);
            innerArcEndPoint = new Point(innerArcEndPoint.X + CenterX, innerArcEndPoint.Y + CenterY);

            Point outerArcStartPoint = ToCartesianPoint(RotationAngle, Radius);
            outerArcStartPoint = new Point(outerArcStartPoint.X + CenterX, outerArcStartPoint.Y + CenterY);

            Point outerArcEndPoint = ToCartesianPoint(RotationAngle + WedgeAngle, Radius);
            outerArcEndPoint = new Point(outerArcStartPoint.X + CenterX, outerArcEndPoint.Y + CenterY);

            bool largeArc = WedgeAngle > 180.0;

            if (PushOut > 0)
            {
                Point offset = ToCartesianPoint(RotationAngle + (WedgeAngle / 2), PushOut);
                innerArcStartPoint = new Point(innerArcStartPoint.X + offset.X, innerArcStartPoint.Y + offset.Y);
                innerArcEndPoint = new Point(innerArcEndPoint.X + offset.X, innerArcEndPoint.Y + offset.Y);
                outerArcStartPoint = new Point(outerArcStartPoint.X + offset.X, outerArcStartPoint.Y + offset.Y);
                outerArcEndPoint = new Point(outerArcEndPoint.X + offset.X, outerArcEndPoint.Y + offset.Y);
            }

            Size outerArcSize = new Size(Radius, Radius);
            Size innerArcSize = new Size(InnerRadius, InnerRadius);
            context.BeginFigure(new Point(0, 10), true);
            context.ArcTo(new Point(50, 10), new Size(50, 50), 0, false, SweepDirection.Clockwise);
            context.LineTo(new Point(40, 50));
            context.ArcTo(new Point(10, 50), new Size(50, 50), 0, false, SweepDirection.CounterClockwise);

            context.EndFigure(true);
            //context.ArcTo(outerArcEndPoint, outerArcSize, 0, largeArc, SweepDirection.Clockwise);
            //context.LineTo(outerArcStartPoint);
            
            //context.LineTo(innerArcEndPoint);
            //context.ArcTo(innerArcStartPoint, innerArcSize, 0, largeArc, SweepDirection.Clockwise);
        }

        private static Point ToCartesianPoint(double angle, double radius)
        {
            // convert to radians
            double angleRad = Math.PI / 180.0 * ((angle + 360) % 360);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }
    }
}

using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace Flexion.Logic.Preview;

public static class PreviewLayer
{
    public static List<Shape> GetPreviewLayer(Layer layer,double width,double height)
    {
        List<Shape> shapes = new()
        {
            GetHourGlass(10, 10, width, height / 3, layer.HeightAtCenter / layer.HeightOnSides),
            GetHourGlass(10, 10 + height / 3, width, height, layer.WidthAtCenter / layer.WidthOnSides)
        };
        return shapes;
    }

    private static Path GetHourGlass(double x,double y,double width,double height,double proportionCenterOverSides)
    {
        int minusCenter = 0;
        int minusSides = 0;
        if (proportionCenterOverSides < 1)
        {
            minusSides = (int)((height-height * proportionCenterOverSides)/2);
        }
        else
        {
            minusCenter = (int)((height-height / proportionCenterOverSides)/2);
        }
        Path path = new()
        {
            Fill = Brushes.Gray,
            Data = new PathGeometry()
            {
                Figures = new PathFigures
                {
                    new()
                    {
                        StartPoint = new Point(x,y+minusSides),
                        IsClosed = true,
                        IsFilled = true,
                        Segments = new PathSegments()
                        {
                            new QuadraticBezierSegment()
                            {
                                Point1 = new Point(width/2,y+minusCenter),
                                Point2 = new Point(width,y+minusSides)
                            },
                            new LineSegment()
                            {
                                Point = new Point(width,height-minusSides)
                            },
                            new QuadraticBezierSegment()
                            {
                                Point1 = new Point(width/2,height-minusCenter),
                                Point2 = new Point(x,height-minusSides)
                            },
                            new LineSegment()
                            {
                                Point = new Point(x,y+minusSides)
                            },
                        }
                    }
                }
            }
        };
        return path;
    }
}
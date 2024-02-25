using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;

namespace Flexion.Logic.Preview;

public class LayerPreview:Grid
{
    private readonly TextBlock _tbxAbove;
    private readonly TextBlock _tbxSide;
    private readonly Canvas _preview;
    private const double PreviewMargin = 10;

    public LayerPreview(Layer? layer)
    {
        ColumnDefinitions = new ColumnDefinitions("Auto,*");
        RowDefinitions = new RowDefinitions("*,10,*");
        _tbxSide = new TextBlock
        {
            VerticalAlignment = VerticalAlignment.Center,
            Text = "Coté:"
        };
        SetRow(_tbxSide,0);
        SetColumn(_tbxSide,0);
        Children.Add(_tbxSide);
        
        _tbxAbove = new TextBlock
        {
            VerticalAlignment = VerticalAlignment.Center,
            Text = "Dessus:"
        };
        SetRow(_tbxAbove,2);
        SetColumn(_tbxAbove,0);
        Children.Add(_tbxAbove);
        

        _preview = new Canvas
        {
            Background = new SolidColorBrush(Color.Parse("#292929"))
        };
        SetRow(_preview,0);
        SetRowSpan(_preview,3);
        SetColumn(_preview,2);
        Children.Add(_preview);
        UpdatePreview(layer);
    }

    public void UpdatePreview(Layer? layer)
    {
        _preview.Children.Clear();
        if(layer == null) { Clear();return;}
        _tbxAbove.Text = "Dessus:";
        _tbxSide.Text = "Coté:";
        double width = ColumnDefinitions[1].ActualWidth - 2*PreviewMargin;
        double height = GetFullGridHeight(this) - 3*PreviewMargin;
        List<Shape> shapes = new()
        {
            GetHourGlass(PreviewMargin, PreviewMargin, width, height / 2, layer.HeightAtCenter / layer.HeightOnSides),
            GetHourGlass(PreviewMargin, 2*PreviewMargin + height / 2, width, height/2, layer.WidthAtCenter / layer.WidthOnSides)
        };
        foreach (Shape shape in shapes)
        {
            _preview.Children.Add(shape);
        }
    }

    private void Clear()
    {
        _preview.Children.Clear();
        _tbxAbove.Text = string.Empty;
        _tbxSide.Text = string.Empty;
    }
    
    private static double GetFullGridHeight(Grid grid)
    {
        double height = 0;
        int i = 0;
        while (i < 100)
        {
            try
            {
                height += grid.RowDefinitions[i].ActualHeight;
                i++;
            }
            catch
            {
                return height;
            }
        }
        return height;
    }
    
    private static Path GetHourGlass(double x,double y,double width,double height,double proportionCenterOverSides)
    {
        int minusCenter = 0;
        int minusSides = 0;
        if (proportionCenterOverSides > 1)
        {
            minusSides = (int)((height - height/proportionCenterOverSides)/2);
        }
        else
        {
            minusCenter = (int)((height - height*proportionCenterOverSides)/2);
        }
        Path path = new()
        {
            Fill = Brushes.LightBlue,
            Data = new PathGeometry
            {
                Figures = new PathFigures
                {
                    new()
                    {
                        StartPoint = new Point(x,y+minusSides),
                        IsClosed = true,
                        IsFilled = true,
                        Segments = new PathSegments
                        {
                            CreateArcSegment(new Point(x,y+minusSides),new Point(x+width/2,y+minusCenter),new Point(x+width,y+minusSides)),
                            new LineSegment
                            {
                                Point = new Point(x+width,y+height-minusSides)
                            },
                            CreateArcSegment(new Point(x+width,y+height-minusSides),new Point(x+width/2,y+height-minusCenter),new Point(x,y+height-minusSides)),
                            new LineSegment
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
    
    private static PathSegment CreateArcSegment(Point point1, Point point2, Point point3)
    {
        if (Math.Abs(point1.Y - point2.Y) < 0.01)
        {
            return new LineSegment
            {
                Point = point3
            };
        }
        // Calculate the center and radius of the circle passing through the three points
        Point center = CalculateCenter(point1,point2,point3);
        Point dif = new(point1.X - center.X, point1.Y - center.Y);
        double radius = Math.Sqrt(dif.X * dif.X + dif.Y * dif.Y);
        
        return new ArcSegment
        {
            Point = point3,
            Size = new Size(radius, radius),
            RotationAngle = 0,
            IsLargeArc = IsLargeArc(point1, point2, point3, center),
            SweepDirection = CalculateSweepDirection(point1, point2, point3)
        };
    }

    private static Point CalculateCenter(Point a, Point b, Point c)
    {
        double ma = (b.Y - a.Y) / (b.X - a.X);
        double mb = (c.Y - b.Y) / (c.X - b.X);
        double centerX = (ma * mb * (a.Y - c.Y) + mb * (a.X + b.X) - ma * (b.X + c.X)) / (2 * (mb - ma));
        double centerY = (-1 / ma) * (centerX - (a.X + b.X) / 2) + (a.Y + b.Y) / 2;
        Point center = new(centerX, centerY);
        return center;
    }

    private static bool IsLargeArc(Point point1, Point point2, Point point3, Point center)
    {
        // Calculate the angle formed by the three points and the center
        double angle1 = Math.Atan2(point2.Y - center.Y, point2.X - center.X);
        double angle2 = Math.Atan2(point3.Y - center.Y, point3.X - center.X);
        double angle3 = Math.Atan2(point1.Y - center.Y, point1.X - center.X);

        // Determine if the total angle exceeds 180 degrees
        double totalAngle = Math.Abs(angle1 - angle2) + Math.Abs(angle2 - angle3) + Math.Abs(angle3 - angle1);
        return totalAngle > Math.PI;
    }

    private static SweepDirection CalculateSweepDirection(Point point1, Point point2, Point point3)
    {
        // Check if the points form a clockwise or counter-clockwise turn
        double crossProduct = (point2.X - point1.X) * (point3.Y - point2.Y) - (point2.Y - point1.Y) * (point3.X - point2.X);
        return crossProduct > 0 ? SweepDirection.Clockwise : SweepDirection.CounterClockwise;
    }
}
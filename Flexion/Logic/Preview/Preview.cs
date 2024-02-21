using System;
using System.Collections.Generic;
using System.Numerics;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using PathGeometry = Avalonia.Media.PathGeometry;

namespace Flexion.Logic.Preview;

public static class Preview
{
    private const double Margin = 10;

    public static List<Shape> GetPreviewLayer(Layer layer,double width,double height)
    {
        width -= 2*Margin;
        height -= 3*Margin;
        List<Shape> shapes = new()
        {
            GetHourGlass(Margin, Margin, width, height / 2, layer.HeightAtCenter / layer.HeightOnSides),
            GetHourGlass(Margin, 2*Margin + height / 2, width, height/2, layer.WidthAtCenter / layer.WidthOnSides)
        };
        return shapes;
    }

    public static List<Shape> GetPreviewPiece(Piece piece,double width,double height)
    {
        width -= 20;
        height -= 20;
        double maxWidth = 0;
        double totalHeight = 0;
        foreach (Layer layer in piece.Layers)
        {
            totalHeight += layer.HeightOnSides;
            if (layer.WidthOnSides > maxWidth)
            {
                maxWidth = layer.WidthOnSides;
            }
        }

        List<Shape> shapes = new();
        double heightOfPiecesBefore = 0;
        for (int i = 1; i <= piece.Layers.Count; i++)
        {
            double pieceWidth = width * (piece.Layers[i - 1].WidthOnSides / maxWidth);
            double horizontalMargin = (width - pieceWidth) / 2;
            double pieceHeight = (height - Margin*(piece.Layers.Count-1)) * (piece.Layers[i-1].HeightOnSides/totalHeight) ;
            shapes.Add(GetRectangle(
                Margin+horizontalMargin,
                Margin*i+heightOfPiecesBefore,
                pieceWidth,
                pieceHeight));
            heightOfPiecesBefore += pieceHeight;
        }
        return shapes;
    }

    private static Path GetRectangle(double x,double y,double width,double height)
    {
        Path path = new()
        {
            Fill = Brushes.Red,
            Data = new PathGeometry
            {
                Figures = new PathFigures
                {
                    new()
                    {
                        StartPoint = new Point(x,y),
                        IsClosed = true,
                        IsFilled = true,
                        Segments = new PathSegments
                        {
                            new LineSegment
                            {
                                Point = new Point(x+width,y)
                            },
                            new LineSegment
                            {
                                Point = new Point(x+width,y+height)
                            },
                            new LineSegment
                            {
                                Point = new Point(x,y+height)
                            },
                            new LineSegment
                            {
                                Point = new Point(x,y)
                            },
                        }
                    }
                }
            }
        };
        return path;
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
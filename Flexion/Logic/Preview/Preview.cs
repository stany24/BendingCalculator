using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

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
            Fill = Brushes.Gray,
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
                            new QuadraticBezierSegment
                            {
                                Point1 = new Point(x+width/2,y+minusCenter),
                                Point2 = new Point(x+width,y+minusSides)
                            },
                            new LineSegment
                            {
                                Point = new Point(x+width,y+height-minusSides)
                            },
                            new QuadraticBezierSegment
                            {
                                Point1 = new Point(x+width/2,y+height-minusCenter),
                                Point2 = new Point(x,y+height-minusSides)
                            },
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
}
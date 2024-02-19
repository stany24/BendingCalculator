using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;

namespace Flexion.Logic.Preview;

public static class Preview
{
    private static double margin = 10;
    public static List<Shape> GetPreviewLayer(Layer layer,double width,double height)
    {
        width -= 2*margin;
        height -= 2*margin;
        List<Shape> shapes = new()
        {
            GetHourGlass(margin, margin, width, height / 3, layer.HeightAtCenter / layer.HeightOnSides),
            GetHourGlass(margin, margin + height / 3, width, height, layer.WidthAtCenter / layer.WidthOnSides)
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
            double pieceHeight = (height - margin*(piece.Layers.Count-1)) * (piece.Layers[i-1].HeightOnSides/totalHeight) ;
            shapes.Add(GetRectangle(
                margin+horizontalMargin,
                margin*i+heightOfPiecesBefore,
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
                                Point1 = new Point(width/2,y+minusCenter),
                                Point2 = new Point(width,y+minusSides)
                            },
                            new LineSegment
                            {
                                Point = new Point(width,height-minusSides)
                            },
                            new QuadraticBezierSegment
                            {
                                Point1 = new Point(width/2,height-minusCenter),
                                Point2 = new Point(x,height-minusSides)
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
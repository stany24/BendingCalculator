using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using PathGeometry = Avalonia.Media.PathGeometry;

namespace Flexion.Logic.Preview;

public static class Preview
{
    private const double Margin = 10;

    
    
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
            catch (Exception e)
            {
                return height;
            }
        }
        return height;
    }

    public static void GetPreviewPiece(ref Grid grid,Piece piece)
    {
        grid.ColumnDefinitions = new ColumnDefinitions("Auto,10,*");
        Canvas canvas = new()
        {
            Background = new SolidColorBrush(Color.Parse("#292929"))
        };
        CreateNewTextBlocks(ref grid,canvas,piece);
        Grid.SetRow(canvas,0);
        Grid.SetColumn(canvas,2);
        grid.Children.Add(canvas);
        grid.UpdateLayout();
        
        double width = grid.ColumnDefinitions[2].ActualWidth - 2*Margin;
        double height = GetFullGridHeight(grid) - 2*Margin;
        
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
        foreach (Shape shape in shapes)
        {
            canvas.Children.Add(shape);
        }
    }
    
    private static void CreateNewTextBlocks(ref Grid grid,Canvas canvas,Piece piece)
    {
        StringBuilder builder = new();
        builder.Append('*');
        for (int i = 0; i < piece.Layers.Count-1; i++)
        {
            builder.Append(",10,*");
        }
        grid.RowDefinitions = new RowDefinitions(builder.ToString());
        for (int i = 0; i < piece.Layers.Count; i++)
        {
            TextBlock block = new()
            {
                Text = piece.Layers[i].Material.Display,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(block,0);
            Grid.SetRow(block,2*i);
            grid.Children.Add(block);
        }
        Grid.SetRowSpan(canvas,piece.Layers.Count*2-1);
        grid.UpdateLayout();
    }

    private static Path GetRectangle(double x,double y,double width,double height)
    {
        Path path = new()
        {
            Fill = Brushes.LightBlue,
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

    

    
}
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.Logic.Preview;

public class PiecePreview:Grid
{
    #region Variables

    private readonly Canvas _preview;
    private readonly List<TextBlock> _infos = new();
    private const double PreviewMargin = 10;
    private Piece? _oldPiece;

    #endregion

    #region Constructor / Destructor

    public PiecePreview()
    {
        ColumnDefinitions = new ColumnDefinitions("10,Auto,*");
        RowDefinitions = new RowDefinitions("*");
        _preview = new Canvas
        {
            Background = new SolidColorBrush(Color.Parse("#292929"))
        };
        SetColumn(_preview,2);
        SetRow(_preview,0);
        Children.Add(_preview);
        SizeChanged += (_, _) => UpdatePreview(_oldPiece);
    }

    #endregion

    #region Preview Math

    public void UpdatePreview(Piece? piece)
    {
        _oldPiece = piece;
        _preview.Children.Clear();
        if (piece == null) { Clear(); return;}
        CreateNewTextBlocks(piece);
        double width = ColumnDefinitions[2].ActualWidth - 2*PreviewMargin;
        double height = Bounds.Size.Height - 2*PreviewMargin;
        
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
            double pieceHeight = (height - PreviewMargin*(piece.Layers.Count-1)) * (piece.Layers[i-1].HeightOnSides/totalHeight) ;
            shapes.Add(GetRectangle(
                PreviewMargin+horizontalMargin,
                PreviewMargin*i+heightOfPiecesBefore,
                pieceWidth,
                pieceHeight));
            heightOfPiecesBefore += pieceHeight;
        }
        _preview.Children.AddRange(shapes);
    }

    private static Path GetRectangle(double x,double y,double width,double height)
    {
        return new Path
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
                            }
                        }
                    }
                }
            }
        };
    }
    
    private void CreateNewTextBlocks(Piece piece)
    {
        while(_infos.Count > 0)
        {
            Children.Remove(_infos[0]);
            _infos.RemoveAt(0);
        }
        StringBuilder builder = new();
        builder.Append('*');
        for (int i = 0; i < piece.Layers.Count-1; i++)
        {
            builder.Append(",10,*");
        }
        RowDefinitions = new RowDefinitions(builder.ToString());
        for (int i = 0; i < piece.Layers.Count; i++)
        {
            TextBlock block = new()
            {
                Text = piece.Layers[i].Material?.Display,
                VerticalAlignment = VerticalAlignment.Center
            };
            SetColumn(block,1);
            SetRow(block,2*i);
            Children.Add(block);
            _infos.Add(block);
        }
        SetRowSpan(_preview,piece.Layers.Count*2-1);
        UpdateLayout();
    }
    
    #endregion

    #region Tools

    private void Clear()
    {
        foreach (TextBlock textBlock in _infos)
        {
            textBlock.Text = string.Empty;
        }
    }

    #endregion
}
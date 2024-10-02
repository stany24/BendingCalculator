using System;
using System.Collections.Generic;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using BendingCalculator.Database.Actions;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.Logic.Preview;

public class PiecePreview : Border
{
    #region Constructor / Destructor

    public PiecePreview()
    {
        Child = _grid;
        _grid.ColumnDefinitions = new ColumnDefinitions("10,Auto,*");
        _grid.RowDefinitions = new RowDefinitions("*");
        _preview = new Canvas
        {
            Background = new SolidColorBrush(Color.Parse("#292929"))
        };
        Grid.SetColumn(_preview, 2);
        Grid.SetRow(_preview, 0);
        _grid.Children.Add(_preview);
        SizeChanged += (_, _) => UpdatePreview();
        this.GetObservable(DisplayedPieceProperty).Subscribe(_ => UpdatePreview());
        DataBaseEvents.PiecesChanged += (_, _) => UpdatePreview();
    }

    #endregion

    #region Tools

    private void Clear()
    {
        foreach (TextBlock textBlock in _infos) textBlock.Text = string.Empty;
    }

    #endregion

    #region Variables

    private readonly Grid _grid = new();
    private readonly Canvas _preview;
    private readonly List<TextBlock> _infos = new();
    private const double PreviewMargin = 10;

    public static readonly StyledProperty<Piece?> DisplayedPieceProperty =
        AvaloniaProperty.Register<PiecePreview, Piece?>(nameof(DisplayedPiece));

    public Piece? DisplayedPiece
    {
        get => GetValue(DisplayedPieceProperty);
        set => SetValue(DisplayedPieceProperty, value);
    }

    #endregion

    #region Preview Math

    private void UpdatePreview()
    {
        _preview.Children.Clear();
        if (DisplayedPiece == null)
        {
            Clear();
            return;
        }

        if (DisplayedPiece.Layers.Count == 0)
        {
            Clear();
            return;
        }

        CreateNewTextBlocks(DisplayedPiece);
        double width = _grid.ColumnDefinitions[2].ActualWidth - 2 * PreviewMargin;
        double height = Bounds.Size.Height - 2 * PreviewMargin;

        double maxWidth = 0;
        double totalHeight = 0;
        foreach (Layer layer in DisplayedPiece.Layers)
        {
            totalHeight += layer.HeightOnSides;
            if (layer.WidthOnSides > maxWidth) maxWidth = layer.WidthOnSides;
        }

        List<Shape> shapes = new();
        double heightOfPiecesBefore = 0;
        for (int i = 1; i <= DisplayedPiece.Layers.Count; i++)
        {
            double pieceWidth = width * (DisplayedPiece.Layers[i - 1].WidthOnSides / maxWidth);
            double horizontalMargin = (width - pieceWidth) / 2;
            double pieceHeight = (height - PreviewMargin * (DisplayedPiece.Layers.Count - 1)) *
                                 (DisplayedPiece.Layers[i - 1].HeightOnSides / totalHeight);
            Color color = (DisplayedPiece.Layers[i - 1].Material ?? new Material()).Color;
            shapes.Add(GetRectangle(
                PreviewMargin + horizontalMargin,
                PreviewMargin * i + heightOfPiecesBefore,
                pieceWidth,
                pieceHeight,
                color));
            heightOfPiecesBefore += pieceHeight;
        }

        _preview.Children.AddRange(shapes);
    }

    private static Path GetRectangle(double x, double y, double width, double height, Color color)
    {
        return new Path
        {
            Fill = new SolidColorBrush(color),
            Data = new PathGeometry
            {
                Figures = new PathFigures
                {
                    new PathFigure
                    {
                        StartPoint = new Point(x, y),
                        IsClosed = true,
                        IsFilled = true,
                        Segments = new PathSegments
                        {
                            new LineSegment
                            {
                                Point = new Point(x + width, y)
                            },
                            new LineSegment
                            {
                                Point = new Point(x + width, y + height)
                            },
                            new LineSegment
                            {
                                Point = new Point(x, y + height)
                            },
                            new LineSegment
                            {
                                Point = new Point(x, y)
                            }
                        }
                    }
                }
            }
        };
    }

    private void CreateNewTextBlocks(Piece piece)
    {
        while (_infos.Count > 0)
        {
            _grid.Children.Remove(_infos[0]);
            _infos.RemoveAt(0);
        }

        StringBuilder builder = new();
        builder.Append('*');
        for (int i = 0; i < piece.Layers.Count - 1; i++) builder.Append(",10,*");
        _grid.RowDefinitions = new RowDefinitions(builder.ToString());
        for (int i = 0; i < piece.Layers.Count; i++)
        {
            TextBlock block = new()
            {
                Text = piece.Layers[i].Material?.Display,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(block, 1);
            Grid.SetRow(block, 2 * i);
            _grid.Children.Add(block);
            _infos.Add(block);
        }

        Grid.SetRowSpan(_preview, piece.Layers.Count * 2 - 1);
        UpdateLayout();
    }

    #endregion
}
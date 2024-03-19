using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Layout;
using Avalonia.Media;
using BendingCalculator.Logic.Math;

namespace BendingCalculator.Logic.Preview;

public class LayerPreview:Grid
{
    #region Variables

    private readonly TextBlock _tbxAbove;
    private readonly TextBlock _tbxSide;
    private readonly Canvas _preview;
    private const double PreviewMargin = 10;

    //Needs to be public
    public static readonly StyledProperty<Layer?> DisplayedLayerProperty =
        AvaloniaProperty.Register<LayerPreview,Layer?>(nameof(DisplayedLayer), defaultValue: null);
    public Layer? DisplayedLayer
    {
        get => GetValue(DisplayedLayerProperty);
        set => SetValue(DisplayedLayerProperty, value);
    }

    #endregion

    #region Constructor / Destructor

    public LayerPreview()
    {
        ColumnDefinitions = new ColumnDefinitions("10,Auto,*");
        RowDefinitions = new RowDefinitions("*,10,*");
        _tbxSide = new TextBlock
        {
            VerticalAlignment = VerticalAlignment.Center,
            Text = "Coté:"
        };
        SetRow(_tbxSide,0);
        SetColumn(_tbxSide,1);
        Children.Add(_tbxSide);
        
        _tbxAbove = new TextBlock
        {
            VerticalAlignment = VerticalAlignment.Center,
            Text = "Dessus:"
        };
        SetRow(_tbxAbove,2);
        SetColumn(_tbxAbove,1);
        Children.Add(_tbxAbove);
        
        _preview = new Canvas
        {
            Background = new SolidColorBrush(Color.Parse("#292929"))
        };
        SetRow(_preview,0);
        SetRowSpan(_preview,3);
        SetColumn(_preview,2);
        Children.Add(_preview);
        SizeChanged += (_, _) => UpdatePreview();
        LanguageEvents.LanguageChanged += UpdateLanguage;
        this.GetObservable(DisplayedLayerProperty).Subscribe(_ =>UpdatePreview());
    }

    ~LayerPreview()
    {
        LanguageEvents.LanguageChanged -= UpdateLanguage;
    }

    #endregion
    
    #region Preview Math

    private void UpdatePreview()
    {
        _preview.Children.Clear();
        if(DisplayedLayer == null) { Clear();return;}
        _tbxAbove.Text = Assets.Localization.Logic.LogicLocalization.TopViewWithColon;
        _tbxSide.Text = Assets.Localization.Logic.LogicLocalization.SideViewWithColon;
        UpdateLayout();
        double width = ColumnDefinitions[2].ActualWidth - 2*PreviewMargin;
        double height = Bounds.Size.Height - 3*PreviewMargin;
        List<Shape> shapes = new()
        {
            GetLayerShape(PreviewMargin, PreviewMargin, width, height / 2, DisplayedLayer.HeightAtCenter / DisplayedLayer.HeightOnSides),
            GetLayerShape(PreviewMargin, 2*PreviewMargin + height / 2, width, height/2, DisplayedLayer.WidthAtCenter / DisplayedLayer.WidthOnSides)
        };
        _preview.Children.AddRange(shapes);
    }
    
    private static Path GetLayerShape(double x,double y,double width,double height,double proportionCenterOverSides)
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
        return new Path()
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
                            }
                        }
                    }
                }
            }
        };
    }
    
    private static PathSegment CreateArcSegment(Point point1, Point point2, Point point3)
    {
        if (System.Math.Abs(point1.Y - point2.Y) < 0.01)
        {
            return new LineSegment
            {
                Point = point3
            };
        }
        Point center = CalculateCenter(point1,point2,point3);
        Point dif = new(point1.X - center.X, point1.Y - center.Y);
        double radius = System.Math.Sqrt(dif.X * dif.X + dif.Y * dif.Y);
        
        return new ArcSegment
        {
            Point = point3,
            Size = new Size(radius, radius),
            RotationAngle = 0,
            IsLargeArc = false,
            SweepDirection = CalculateSweepDirection(point1, point2, point3)
        };
    }

    private static Point CalculateCenter(Point a, Point b, Point c)
    {
        double ma = (b.Y - a.Y) / (b.X - a.X);
        double mb = (c.Y - b.Y) / (c.X - b.X);
        double centerX = (ma * mb * (a.Y - c.Y) + mb * (a.X + b.X) - ma * (b.X + c.X)) / (2 * (mb - ma));
        double centerY = -1 / ma * (centerX - (a.X + b.X) / 2) + (a.Y + b.Y) / 2;
        Point center = new(centerX, centerY);
        return center;
    }

    private static SweepDirection CalculateSweepDirection(Point point1, Point point2, Point point3)
    {
        double crossProduct = (point2.X - point1.X) * (point3.Y - point2.Y) - (point2.Y - point1.Y) * (point3.X - point2.X);
        return crossProduct > 0 ? SweepDirection.Clockwise : SweepDirection.CounterClockwise;
    }

    #endregion

    #region Tools

    private void Clear()
    {
        _preview.Children.Clear();
        _tbxAbove.Text = string.Empty;
        _tbxSide.Text = string.Empty;
    }

    #endregion
    
    private void UpdateLanguage(object? sender, EventArgs eventArgs)
    {
        UpdatePreview();
    }
}
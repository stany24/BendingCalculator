using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace BendingCalculator.Logic.Helper;

public class HelperImage : IHelperControl
{
    private readonly string _source;

    public HelperImage(string uri)
    {
        _source = "avares://BendingCalculator/Assets/Help/" + uri;
    }

    public Control GetControl()
    {
        return new Image
        {
            Source = new Bitmap(AssetLoader.Open(new Uri(_source)))
        };
    }
}
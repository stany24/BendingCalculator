using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Flexion.Logic.Helper;

public class HelperImage:IHelperModule
{
    public string Source { get; set; }
    public HelperImage(string uri)
    {
        Source = uri;
    }
}
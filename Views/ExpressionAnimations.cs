using _06CorePlayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using WinUI = Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Graphics.Imaging;
using EF = Microsoft.Toolkit.Uwp.UI.Animations.Expressions.ExpressionFunctions;
using EN = Microsoft.Toolkit.Uwp.UI.Animations.Expressions.ExpressionNode;
using Windows.UI.Composition;
using Microsoft.Toolkit.Uwp.UI.Animations.Expressions;
using Microsoft.Toolkit.Uwp.UI;
using Windows.UI.Xaml.Hosting;
using static System.Net.Mime.MediaTypeNames;
using Windows.ApplicationModel.Core;
using System.Reflection;
using Windows.UI.Core;
using Windows.UI;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Windows.Devices.Bluetooth;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using System.Threading;
using System.Runtime.CompilerServices;
using Windows.System.Threading;
using Windows.System;

namespace _06CorePlayer.Views
{
    public static class ExpressionAnimations
    {
        
        public static EN Gravity(Window w, Visual v)
        {
            //var vNode = v.GetReference();
            var vNode = v;
            var gravityNode = vNode.Offset.Y + 0.8f * EF.Distance((float)w.Bounds.Bottom, vNode.Offset.Y);
            return gravityNode;
        }
    }
}

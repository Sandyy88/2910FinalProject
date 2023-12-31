﻿using System;
using System.Runtime.InteropServices;

using Windows.ApplicationModel.Resources;

namespace Demo5.Helpers
{
    internal static class ResourceExtensions
    {
        private static ResourceLoader _resLoader = new ResourceLoader();

        public static string GetLocalized(this string resourceKey)
        {
            return _resLoader.GetString(resourceKey);
        }
    }
}

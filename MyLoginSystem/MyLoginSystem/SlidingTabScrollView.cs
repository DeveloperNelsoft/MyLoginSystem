﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyLoginSystem
{
    public class SlidingTabScrollView
    {
        public interface TabColorizer
        {
            int GetIndicatorColor(int position);
            int GetDividerColors(int position);
            

        }
    }
}
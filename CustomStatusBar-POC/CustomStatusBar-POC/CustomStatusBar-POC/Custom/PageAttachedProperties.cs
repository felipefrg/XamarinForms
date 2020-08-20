using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomStatusBar_POC.Custom
{
    public sealed class PageAttachedProperties : Page
    {

        public enum EffectStyle
        {
            NONE,
            LIGHT,
            DARK,
            TRANSLUCID
        }

        //BlurEffect
        public static readonly BindableProperty StatusBarEffectProperty = BindableProperty.CreateAttached("StatusBarEffect", typeof(EffectStyle), typeof(Page), EffectStyle.NONE);

        public static void SetStatusBarEffect(BindableObject view, EffectStyle value)
        {
            view.SetValue(StatusBarEffectProperty, value);
        }

        public static EffectStyle GetStatusBarEffect(BindableObject view)
        {
            return (EffectStyle)view.GetValue(StatusBarEffectProperty);
        }
        //BlurEffect

        //StatuBarColor
        public static readonly BindableProperty StatusBarColorProperty = BindableProperty.CreateAttached("StatusBarColor", typeof(Color), typeof(Page), Color.White);//(Color)App.Current.Resources["AccentColor"]);

        public static void SetStatusBarColor(BindableObject view, Color value)
        {
            view.SetValue(StatusBarColorProperty, value);
        }

        public static Color GetStatusBarColor(BindableObject view)
        {
            return (Color)view.GetValue(StatusBarColorProperty);
        }
        //StatuBarColor
    }
}

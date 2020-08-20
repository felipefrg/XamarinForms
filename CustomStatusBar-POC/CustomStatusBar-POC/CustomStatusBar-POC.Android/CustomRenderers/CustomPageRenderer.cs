using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using CustomStatusBar_POC.Custom;
using CustomStatusBar_POC.Droid.CustomRenderers;

using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomPage), typeof(CustomPageRenderer))]
namespace CustomStatusBar_POC.Droid.CustomRenderers
{
    class CustomPageRenderer : PageRenderer
    {
        public CustomPageRenderer(Context context) : base(context)
        {           

        }        

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);            

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                HandleStatusBar(Element);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"            ERROR: ", ex.Message);
            }
        }     

        void HandleStatusBar(Page page)
        {
            var statusBarEffect = PageAttachedProperties.GetStatusBarEffect(page);
            var statusBarColor = PageAttachedProperties.GetStatusBarColor(page);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                MainActivity.WindowActivity.ClearFlags(WindowManagerFlags.TranslucentStatus);
                MainActivity.WindowActivity.ClearFlags(WindowManagerFlags.LayoutNoLimits);
                MainActivity.WindowActivity.ClearFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

                if (statusBarEffect == PageAttachedProperties.EffectStyle.NONE)
                {   
                    MainActivity.WindowActivity.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                    MainActivity.WindowActivity.SetStatusBarColor(statusBarColor.ToAndroid());
                }
                else if (statusBarEffect == PageAttachedProperties.EffectStyle.TRANSLUCID)
                {
                    MainActivity.WindowActivity.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);                  
                    MainActivity.WindowActivity.SetStatusBarColor(Android.Graphics.Color.Transparent);
                }
                else if (statusBarEffect == PageAttachedProperties.EffectStyle.DARK)
                {
                    MainActivity.WindowActivity.ClearFlags(WindowManagerFlags.LayoutNoLimits);
                    MainActivity.WindowActivity.AddFlags(WindowManagerFlags.TranslucentStatus);                    
                }
            }            
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}
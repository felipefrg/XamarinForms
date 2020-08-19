using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using AndroidX.Biometric;


namespace AppFingerPrint_POC.Droid
{
    public class CustomDialogFragment : FingerprintDialogFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            view.Background = new ColorDrawable(Color.Magenta);
            return view;
        }
    }
}
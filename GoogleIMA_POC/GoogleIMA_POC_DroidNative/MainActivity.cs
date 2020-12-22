using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Ext.Ima;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Source.Ads;
using Com.Google.Android.Exoplayer2.UI;
using Com.Google.Android.Exoplayer2.Upstream;
using Com.Google.Android.Exoplayer2.Util;

namespace GoogleIMA_POC_DroidNative
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        PlayerView playerView;
        SimpleExoPlayer player;
         ImaAdsLoader adsLoader;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            playerView = FindViewById(Resource.Id.player_view) as PlayerView;

            adsLoader = new ImaAdsLoader(this, Android.Net.Uri.Parse(GetString(Resource.String.ad_tag_url)));

            //Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);                        
        }

        private void releasePlayer()
        {
            adsLoader.SetPlayer(null);
            playerView.Player = null;
            player.Release();
            player = null;
        }

        private void initializePlayer()
        {
            player = new SimpleExoPlayer
                .Builder(this)
                .Build();
            playerView.Player = player;
            adsLoader.SetPlayer(player);

            DefaultDataSourceFactory  defaultDataSourceFactory = 
                new DefaultDataSourceFactory(this,
                                             Util.GetUserAgent(this, GetString(Resource.String.app_name)));

            ProgressiveMediaSource.Factory mediaSourceFactory =
                new ProgressiveMediaSource.Factory(defaultDataSourceFactory);

            IMediaSource mediaSource = mediaSourceFactory
                .CreateMediaSource(Android.Net.Uri.Parse(GetString(Resource.String.content_url)));

            AdsMediaSource adsMediaSource =
                new AdsMediaSource(mediaSource, defaultDataSourceFactory, adsLoader, playerView);

            player.Prepare(adsMediaSource);

            player.PlayWhenReady = false;
        }

        protected override void OnStart()
        {
            base.OnStart();

            if (Util.SdkInt > 23)
            {
                initializePlayer();
                if(playerView != null)
                {
                    playerView.OnResume();
                }
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (Util.SdkInt <= 23 || player == null)
            {
                initializePlayer();
                if (playerView != null)
                {
                    playerView.OnResume();
                }
            }
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (Util.SdkInt > 23)
            {                
                if (playerView != null)
                {
                    playerView.OnPause();
                }
                releasePlayer();
            }
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (Util.SdkInt > 23)
            {
                if (playerView != null)
                {
                    playerView.OnPause();
                }
                releasePlayer();
            }

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            adsLoader.Release();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

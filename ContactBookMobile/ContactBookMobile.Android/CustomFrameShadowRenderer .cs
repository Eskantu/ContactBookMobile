using System;
using ContactBookMobile.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ContactBookMobile.Helpers;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameShadowRenderer))]
namespace ContactBookMobile.Droid
{
    [Obsolete]
    public class CustomFrameShadowRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            var element = e.NewElement as CustomFrame;
            if (element == null) return;
            if (element.HasShadow)
            {
                Elevation = 30.0f;
                TranslationZ = 0.0f;
                SetZ(30f);
            }
        }
    }
}
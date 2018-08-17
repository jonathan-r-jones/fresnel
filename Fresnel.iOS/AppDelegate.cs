using ObjCRuntime;
using System.Diagnostics;
using AirWatchSDK;

using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Fresnel.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
            LoadApplication(new App());

            if (Runtime.Arch == Arch.SIMULATOR)
            {
                Debug.WriteLine("Running in Simulator, skipping initialization of the AirWatch SDK!");
                return base.FinishedLaunching(app, options);
            }
            else
            {
                Debug.WriteLine("Running on Device, beginning initialization of the AirWatch SDK.");

                // Configure the Controller by:
                var sdkController = AWController.ClientInstance();
                // 1) defining the callback scheme so the app can get called back,
                sdkController.CallbackScheme = "fresneldoj"; // defined in Info.plist
                                                             // 2) set the delegate to know when the initialization has been completed.
                sdkController.Delegate = AirWatchSDKManager.Instance;
                return base.FinishedLaunching(app, options);
            }
        }

        public override void OnActivated(UIApplication application)
        {
            AWController.ClientInstance().Start();
        }

        public override bool HandleOpenURL(UIApplication application, NSUrl url)
        {
            return AWController.ClientInstance().HandleOpenURL(url, "");
        }

        [Export("window")]
        public UIWindow GetWindow()
        {
            return UIApplication.SharedApplication.Windows[0];
        }

    }
}

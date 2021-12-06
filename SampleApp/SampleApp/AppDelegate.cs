using CustomPopOverView_Api;
using Foundation;
using UIKit;

namespace SampleApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        private CustomPopOverView popView;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new UIViewController();

            // make the window visible
            Window.MakeKeyAndVisible();

            popView = new CustomPopOverView();

            var rootView = Window.RootViewController.View;

            var btn1 = new UIButton(new CoreGraphics.CGRect(100, 100, 200, 50));
            btn1.SetTitle("点我", UIControlState.Normal);
            btn1.TouchUpInside += Btn_TouchUpOutside;

            var btn2 = new UIButton(new CoreGraphics.CGRect(100, 300, 200, 50));
            btn2.SetTitle("点我", UIControlState.Normal);
            btn2.TouchUpInside += Btn_TouchUpOutside;

            rootView.AddSubviews(btn1, btn2);

            return true;
        }

        private void Btn_TouchUpOutside(object sender, System.EventArgs e)
        {
            var btn = sender as UIButton;
            popView.Content = new UIView(new CoreGraphics.CGRect(0, 0, 50, 50)) { BackgroundColor = UIColor.Blue };
            popView.ShowFrom(btn, CustomPopOverView_Structs.CPAlignStyle.Center);
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background execution this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transition from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Data.Repositories;
using Foundation;
using UIKit;

namespace EventsApp.iOS
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
#pragma warning disable CS0433 // The type 'Batteries' exists in both 'SQLitePCLRaw.batteries_green, Version=1.1.13.388, Culture=neutral, PublicKeyToken=a84b7dcfb1391f7f' and 'SQLitePCLRaw.batteries_v2, Version=2.0.2.669, Culture=neutral, PublicKeyToken=8226ea5df37bcae9'
            SQLitePCL.Batteries.Init();
#pragma warning restore CS0433 // The type 'Batteries' exists in both 'SQLitePCLRaw.batteries_green, Version=1.1.13.388, Culture=neutral, PublicKeyToken=a84b7dcfb1391f7f' and 'SQLitePCLRaw.batteries_v2, Version=2.0.2.669, Culture=neutral, PublicKeyToken=8226ea5df37bcae9'
            var dbPath =
               Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.MyDocuments),"..", "Library", "eventsDB.db");

            var eventsRepository = new EventsRepository(dbPath);
            var organisationRepository = new OrganisationRepository(dbPath);
                
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(eventsRepository, organisationRepository));

            return base.FinishedLaunching(app, options);
        }
    }
}

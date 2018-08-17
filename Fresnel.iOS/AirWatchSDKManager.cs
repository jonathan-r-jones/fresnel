using Foundation;
using System.Diagnostics;
using System;
using AirWatchSDK;

namespace Fresnel.iOS
{
    public class AirWatchSDKManager : AWSDKDelegate
    {
        private static AirWatchSDKManager instance;
        private static string LogCategory = "AirWatchSDK";

        // private, use the Instance below
        private AirWatchSDKManager()
        {
        }

        // singleton
        public static AirWatchSDKManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AirWatchSDKManager();
                }
                return instance;
            }
        }

        // Below are all the protocol methods defined in AWSDKDelegate
        // Add customization here for SDK results

        override public void InitialCheckDoneWithError(NSError error)
        {
            // Add any SDK Customization here
            string message = String.Format("InitialCheckDoneWithError received {0}, SDK initialized if no error", error);
            Debug.WriteLine(message, LogCategory);
        }

        override public void ReceivedProfiles(AWProfile[] profiles)
        {
            // Add any SDK Customization here
            string message = String.Format("ReceivedProfiles received {0}", profiles);
            Debug.WriteLine(message, LogCategory);
        }

        override public void Wipe()
        {
            // Add any SDK Customization here
            Debug.WriteLine("Wipe command received", LogCategory);
        }

        override public void Lock()
        {
            // Add any SDK Customization here
            Debug.WriteLine("Lock command received", LogCategory);
        }

        override public void Unlock()
        {
            // Add any SDK Customization here
            Debug.WriteLine("Unlock command received", LogCategory);
        }

        public override void StopNetworkActivity(AWNetworkActivityStatus status)
        {
            // Add any SDK Customization here
            Debug.WriteLine("StopNetworkActivity received", LogCategory);
        }

        override public void ResumeNetworkActivity()
        {
            // Add any SDK Customization here
            Debug.WriteLine("ResumeNetworkActivity received", LogCategory);
        }
    }
}
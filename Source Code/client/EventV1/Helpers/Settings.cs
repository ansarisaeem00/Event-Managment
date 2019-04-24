using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace EventV1.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }



        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string AccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessToken", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessToken", value);
            }
        }
        public static string User
        {
            get
            {
                return AppSettings.GetValueOrDefault("User", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("User", value);
            }

        }

        public static string Eid
        {
            get
            {
                return AppSettings.GetValueOrDefault("Eid", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Eid", value);
            }

        }
    }
}

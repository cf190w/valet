using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valet_UI
{
    public static class GlobalSettings
    {
        /// <summary>
        /// Gets and sets the keyword
        /// saves to settings
        /// </summary>
        public static string Keyword
        {
            get
            {
                return Properties.Settings.Default.Keyword;
            }
            set
            {
                Properties.Settings.Default.Keyword = value;
                Properties.Settings.Default.Save();
            }
        }

        public static string Notification
        {
            get
            {
                return Properties.Settings.Default.Notification;
            }
            set
            {
                Properties.Settings.Default.Notification = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool NotificationSetting
        {
            get
            {
               return Properties.Settings.Default.NotificationSetting;
            }
            set
            {
                Properties.Settings.Default.NotificationSetting = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}

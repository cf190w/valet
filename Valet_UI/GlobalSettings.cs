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
    }
}

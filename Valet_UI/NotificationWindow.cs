using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valet_UI
{
    /// <summary>
    /// Spawns a notification window in the bottom Left hand of the screen that lasts for 10 seconds
    /// </summary>
    public partial class NotificationWindow : Form
    {
        
        private System.Windows.Forms.Timer timerNotification;

        public NotificationWindow()
        {
            InitializeComponent();            
            
            string Notification = GlobalSettings.Notification;

            //sets the label text to the string saved in settings
            label_Notification.Text = Notification;

            //sets timer for 10 seconds
            timerNotification = new System.Windows.Forms.Timer();
            timerNotification.Interval = 10000;
            timerNotification.Tick += timerNotification_Tick;

            timerNotification.Start();
        }

        //Closes form
        private void timerNotification_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

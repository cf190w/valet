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
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            InitializeButtonAppearance();            
            
            button_ConfirmChange.Focus();
        }


        private void InitializeButtonAppearance()
        {
            if (GlobalSettings.NotificationSetting)
            {
                button_ConfirmChange.ForeColor = Color.Red;
                button_ConfirmChange.Text = "Turn Off";
            }
            else
            {
                button_ConfirmChange.ForeColor = Color.Green;
                button_ConfirmChange.Text = "Turn On";
            }
        }

        private void button_ConfirmChange_Click(object sender, EventArgs e)
        {
            if (GlobalSettings.NotificationSetting == true)
            {
                GlobalSettings.NotificationSetting = false;
                buttonUpdate();
            }
            else if (GlobalSettings.NotificationSetting == false) 
            {
                GlobalSettings.NotificationSetting = true;
                buttonUpdate();
            }
        }

        private void buttonUpdate()
        {
            if (GlobalSettings.NotificationSetting == true)
            {
                button_ConfirmChange.ForeColor = Color.Red;

                button_ConfirmChange.Text = "Turn Off";                
            }

            else if (GlobalSettings.NotificationSetting == false)
            {
                button_ConfirmChange.ForeColor = Color.Green;

                button_ConfirmChange.Text = "Turn On";                
            }
        }
    }
}

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
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();

            // Load the saved keyword
            label_Keyword.Text = GlobalSettings.Keyword;

            panel_KeywordActivation.Visible = true;
            panel_ChangeKeyword.Visible = false;
            panel_ErrorMessage.Visible = false;
        }

        /// <summary>
        /// Click event method for the change keyword button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ChangeActivationName_Click(object sender, EventArgs e)
        {
            //hides keywordActivation panel and displays the changekeyword panel
            panel_KeywordActivation.Visible = false;
            panel_ChangeKeyword.Visible = true;

            textBox_Keyword.Focus();
        }

        /// <summary>
        /// Click event method for the Confirm change button
        /// Checks if user input is valid then saves keyword to gloabal settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ConfirmChange_Click(object sender, EventArgs e)
        {
            //stores the users input
            string newKeyword = textBox_Keyword.Text.Trim();

            //if string is valid
            if (IsValid(newKeyword) ) 
            {
                //saves the keyword setting to the users new keyword
                GlobalSettings.Keyword = newKeyword;

                //Sets the keyword label to the saved keywrd
                label_Keyword.Text = GlobalSettings.Keyword;
                
                //Hides panels and clears textbox
                panel_ChangeKeyword.Visible = false;
                panel_ErrorMessage.Visible = false;
                panel_KeywordActivation.Visible = true;
                textBox_Keyword.Clear();
            }
            else
            {
                //displays error message
                panel_ErrorMessage.Visible = true;
                textBox_Keyword.Clear();
                textBox_Keyword.Focus();
            }
        }

        /// <summary>
        /// Click event method for the discard button
        /// Clears textbox and makes only the keywordActivation panel visable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Discard_Click(object sender, EventArgs e)
        {
            textBox_Keyword.Clear();

            panel_ChangeKeyword.Visible = false;
            panel_ErrorMessage.Visible = false;
            panel_KeywordActivation.Visible = true;

        }

        /// <summary>
        /// Checks if the user input is valie i.e only letters (upper and lower case)
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>returns true if keyword only contains upper and lower case characters</returns>
        private bool IsValid(string keyword)
        {
            //if null return false
            if (keyword == null)
            {
                return false;
            }

            string pattern = @"^[a-zA-Z]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(keyword, pattern);
        }
    }
}

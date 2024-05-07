namespace Valet_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //displays the dashboard panel when intialized
            dashboard1.Visible = true;
            dictionary1.Visible = false;
            settings1.Visible = false;
        }

        /// <summary>
        /// When clicked will hide all panels except the dashboard panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Dashboard_Click(object sender, EventArgs e)
        {
            dictionary1.Visible = false;
            settings1.Visible = false;
            dashboard1.Visible = true;

        }

        /// <summary>
        /// When clicked will hide all panels except the dictionary panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Dictionary_Click(object sender, EventArgs e)
        {
            dictionary1.Visible = true;
            dashboard1.Visible = false;
            settings1.Visible = false;
        }

        /// <summary>
        /// When clicked will hide all panels except the settings panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Settings_Click(object sender, EventArgs e)
        {
            settings1.Visible = true;
            dashboard1.Visible = false;
            dictionary1.Visible = false;
        }

        /// <summary>
        /// Minimizes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// When clicked will hide the dsahboard form and display the floating menu in the right hand corner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();

            FloatingWindow floatingWindow = new FloatingWindow();
            //gets the working area of the users screen
            System.Drawing.Rectangle workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            //calculates the x and y postion at the bottom right screen
            int xPosition = workingArea.Right - floatingWindow.Width - 30;
            int yPosition = workingArea.Bottom - floatingWindow.Height - 30;

            //sets the forms loaction
            floatingWindow.Location = new System.Drawing.Point(xPosition, yPosition);

            floatingWindow.Show();
        }
    }
}

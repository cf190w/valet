using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic.Devices;

public static class ShortCuts
{

    //instance
    private static String lastminimized = "";

    //creates a timer with a 5 second interval
    private static System.Timers.Timer timer = new System.Timers.Timer { Interval = 5000,
        Enabled = false,
        AutoReset = true,
        };

    //enums and structs
     private enum mouse_eventFlags
    {
        MOUSEEVENTF_LEFTDOWN = 0x02,
        MOUSEEVENTF_LEFTUP = 0x04,
        MOUSEEVENTF_RIGHTDOWN = 0x08,
        MOUSEEVENTF_RIGHTUP = 0x10
    }
    
    private enum Key : byte
    {
        VK_LWIN = 0x5B,
        VK_RWIN = 0x5C,
        VK_LSHIFT = 0xA0,
        VK_RSHIFT = 0xA1,
        VK_LCONTROL = 0xA2,
        VK_RCONTROL = 0xA3,
        VK_LMENU = 0xA4,
        VK_RMENU = 0xA5,
        VK_TAB = 0x09,
        VK_MENU = 0x12,
        VK_CAPITAL = 0x14,
        VK_ESCAPE = 0x1B,
        VK_RETURN = 0x0D,
        VK_BACK = 0x08,
        VK_DELETE = 0x2E,
        VK_INSERT = 0x2D,
        VK_HOME = 0x24,
        VK_END = 0x23,
        VK_PRIOR = 0x21,
        VK_NEXT = 0x22,
        VK_UP = 0x26,
        VK_DOWN = 0x28,
        VK_LEFT = 0x25,
        VK_RIGHT = 0x27,
        VK_F1 = 0x70,
        VK_F2 = 0x71,
        VK_F3 = 0x72,
        VK_F4 = 0x73,
        VK_F5 = 0x74,
        VK_F6 = 0x75,
        VK_F7 = 0x76,
        VK_F8 = 0x77,
        VK_F9 = 0x78,
        VK_F10 = 0x79,
        VK_F11 = 0x7A,
        VK_F12 = 0x7B,
        VK_F13 = 0x7C,
        VK_F14 = 0x7D,
        VK_F15 = 0x7E,
        VK_F16 = 0x7F,
        VK_F17 = 0x80,
        VK_F18 = 0x81,
        VK_F19 = 0x82,
        VK_F20 = 0x83,
        VK_F21 = 0x84,
        VK_F22 = 0x85,
        VK_F23 = 0x86,
        VK_F24 = 0x87,
        VK_NUMLOCK = 0x90,
        VK_SCROLL = 0
    }

    private struct Rect {
    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
    }
    
    
    //dll imports
    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint pdwProcessId);

    [DllImport("user32.dll")]
    private static extern int SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    /// <summary>
    /// https://stackoverflow.com/questions/9668872/how-to-get-windows-position
    /// </summary>
    /// <param name="strClassName"></param>
    /// <param name="strWindowName"></param>
    /// <returns></returns>

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr FindWindow(string strClassName, string strWindowName);

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle); 

    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

   
    //private const int WM_NCHITTEST =  0x0084; //incase i can use it to find close button

    [DllImport("user32.dll")]
    private static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, UIntPtr wParam, IntPtr lParam);
    
    ///METHODS
    private static void CancelClose()
    {
        Process fgproc = GetForegroundProcess();
        Process[] processes = Process.GetProcessesByName(fgproc.ProcessName);
        Process lol = processes[0];
        IntPtr ptr = lol.MainWindowHandle;
        Rect Rect = new Rect();
        GetWindowRect(ptr, ref Rect);
        Console.WriteLine(RectToString(Rect));

        Point point = new Point(Cursor.Position.X, Cursor.Position.Y);

        //checks if the mouse is in the top right corner of the window
        if(point.X > (Rect.Right - 55) && point.X < Rect.Right && point.Y < Rect.Top + 50 && point.Y > Rect.Top)
        {
            Console.WriteLine("X: " + point.X + " Y: " + point.Y);
            if ((Control.MouseButtons & MouseButtons.Left) != 0)
            {
               MoveCursor(50, 0);
               mouse_event((uint)mouse_eventFlags.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
               WindowMinimize();
               MoveCursor(-50, 0);       
               Console.WriteLine("minimized");
               timer.Elapsed += timer_Elapsed;
               timer.Enabled = true; 
            }
            
        }    
    } 
    private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        timer.Enabled = false;
        StopExact(lastminimized);       
        
    }

    private static void MoveCursor(int x, int y)
    {
        // Set the Current cursor, move the cursor's Position,
        // and set its clipping rectangle to the form. 

            Cursor.Current = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
    }

    /// <summary>
    /// starts any given process using the name of the name of the process
    /// </summary>
    /// <param name="processName"></param>
    public static void Start(String processName){
        Process.Start(processName);
        return;
    } 
    
    /// <summary>
    /// stops all process with this name
    /// e.g if you had 5 instances of chrome open it would delete them all
    /// </summary>
    /// <param name="processName"></param>
    public static void StopExact(String processName){
        Process[] process = Process.GetProcessesByName(processName);
        foreach(Process aProcess in process){
            aProcess.Kill();
        }
    }
    
    /// <summary>
    /// gets the active process name 
    /// stops all process with this name
    /// e.g if you had 5 instances of chrome open it would delete them all
    /// </summary>
    public static void StopActive(){
        Process fgproc = GetForegroundProcess();
        Process[] process = Process.GetProcessesByName(fgproc.ProcessName);
        foreach(Process aProcess in process){
            aProcess.Kill();
        }
    }
        
    /// <summary>
    /// refreshes the active window
    /// </summary>
    public static void refresh(){
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            SendKeys.SendWait("{f5}");
        }

    }

    /// <summary>
    /// finds active tab and refreshes it
    /// </summary>
    public static void refreshBrowserTab(){
        Default("{f5}");
    }

    /// <summary>
    /// closes the active tab in a browser
    /// </summary>
    public static void closeTab()
    {
        Default("^w");
    }


    /// <summary>
    /// copys the current text highlighted
    /// </summary>
    public static void copy(){
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            
        }
        if(fgproc.ProcessName.Contains("Terminal") || fgproc.ProcessName == "cmd" || fgproc.ProcessName == "powershell"){
            Console.WriteLine("copying");
        }
        else if (fgproc.ProcessName == Process.GetCurrentProcess().ProcessName) {
            Debug.WriteLine("Current process is the windows form app itself");
        }
        else {
            SendKeys.SendWait("^c");
        }
        }
    
    /// <summary>
    /// pastes text from clipboard
    /// </summary>
    public static void paste(){
        Default("^v");
    }
    
    /// <summary>
    /// undoes the last changes to text
    /// </summary>
    public static void undo(){
        Default("^z");
    }

    /// <summary>
    /// redoes the last changes to text
    /// </summary>
    public static void redo(){
        Default("^y");
    }

    public static void cut(){
        Default("^x");
    }

    public static void selectAll(){
        Default("^a");
    }
    public static void save(){
        Default("^s");
    }
    public static void WindowMinimize()
    {
        lastminimized = GetForegroundProcess().ProcessName;
        keybd_event((byte)Key.VK_LWIN, 0, 0, 0);
        keybd_event((byte)Key.VK_DOWN, 0, 0, 0);
        keybd_event((byte)Key.VK_LWIN, 0, 0x0002, 0);
        keybd_event((byte)Key.VK_DOWN, 0, 0x0002, 0);
        //repeats
        keybd_event((byte)Key.VK_LWIN, 0, 0, 0);
        keybd_event((byte)Key.VK_DOWN, 0, 0, 0);
        keybd_event((byte)Key.VK_LWIN, 0, 0x0002, 0);
        keybd_event((byte)Key.VK_DOWN, 0, 0x0002, 0);
        
    }
    public static void WindowReopen()
    {
        Process[] processes = Process.GetProcessesByName(lastminimized);
        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
        }
        WindowMaximizeCurrent();
    }
    
    public static void WindowMaximizeCurrent()
    {
        keybd_event((byte)Key.VK_LWIN, 0, 0, 0);
        keybd_event((byte)Key.VK_UP, 0, 0, 0);
        keybd_event((byte)Key.VK_LWIN, 0, 0x0002, 0);
        keybd_event((byte)Key.VK_UP, 0, 0x0002, 0);
        //repeats
        keybd_event((byte)Key.VK_LWIN, 0, 0, 0);
        keybd_event((byte)Key.VK_UP, 0, 0, 0);
        keybd_event((byte)Key.VK_LWIN, 0, 0x0002, 0);
        keybd_event((byte)Key.VK_UP, 0, 0x0002, 0);
    }

    public static void WindowLeft()
    {
        keybd_event((byte)Key.VK_LWIN, 0, 0, 0);
        keybd_event((byte)Key.VK_LEFT, 0, 0, 0);
        keybd_event((byte)Key.VK_LWIN, 0, 0x0002, 0);
        keybd_event((byte)Key.VK_LEFT, 0, 0x0002, 0);
    }
    
    public static void WindowRight()
    {
        keybd_event((byte)Key.VK_LWIN, 0, 0, 0);
        keybd_event((byte)Key.VK_RIGHT, 0, 0, 0);
        keybd_event((byte)Key.VK_LWIN, 0, 0x0002, 0);
        keybd_event((byte)Key.VK_RIGHT, 0, 0x0002, 0);
    }

    public static void ToDesktop()
    {
        byte D = DecToHex((byte)Keys.D);
        keybd_event((byte)Key.VK_LWIN, 0, 0, 0);
        keybd_event(D, 0, 0, 0);
        keybd_event((byte)Key.VK_LWIN, 0, 0x0002, 0);
        keybd_event(D, 0, 0x0002, 0);
    }
    

    private static void Default(String key)
    {
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            
        }
        SendKeys.SendWait(key);
    }

    private static String RectToString(Rect rect){
        return "Left: " + rect.Left + " Top: " + rect.Top + " Right: " + rect.Right + " Bottom: " + rect.Bottom;
    }

    private static Process GetForegroundProcess(){
        uint pid = 0;
        IntPtr hWnd = GetForegroundWindow();
        uint threadID = GetWindowThreadProcessId(hWnd, out pid);
        Process fgProc = Process.GetProcessById(Convert.ToInt32(pid));
        return fgProc;
    }
    private static Byte DecToHex(byte decValue) 
    {
        String s =  decValue.ToString("X");
        return Convert.ToByte(s, 16);
    }


}


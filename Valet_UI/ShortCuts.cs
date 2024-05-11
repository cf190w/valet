using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class ShortCuts
{
    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(Point point);

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point point);

    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint pdwProcessId);

    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    public static String GetActiveProcessFileName()
    {
        IntPtr hwnd = GetForegroundWindow();
        uint pid;
        GetWindowThreadProcessId(hwnd, out pid);
        Process p = Process.GetProcessById((int)pid);
        if(p.MainModule != null){
            return p.MainModule.FileName;
        }
        return "";
    }

    public static Process GetForegroundProcess(){
        uint pid = 0;
        IntPtr hWnd = GetForegroundWindow();
        uint threadID = GetWindowThreadProcessId(hWnd, out pid);
        Process fgProc = Process.GetProcessById(Convert.ToInt32(pid));
        return fgProc;
    }
    public static IntPtr GetWindowUnderCursor()
    {
        Point ptCursor = new Point();
        GetCursorPos(out ptCursor);
        Console.WriteLine(ptCursor);
        return WindowFromPoint(ptCursor);
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
        if(fgproc.ProcessName.Contains("Terminal") || fgproc.ProcessName == "cmd" || fgproc.ProcessName == "powershell"){
            Console.WriteLine("copying");
        }
	    else if (fgproc.ProcessName == Process.GetCurrentProcess().ProcessName) {
	        Debug.WriteLine("Current process is the windows form app itself");
	    }
        else {
            foreach(Process aProcess in process){
            aProcess.Kill();
        }
        }
        
    }
        
    /// <summary>
    /// refreshes the active window
    /// </summary>
    public static void refresh(){
        Process [] processes = Process.GetProcessesByName("iexplore");

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
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            
        }
        SendKeys.SendWait("{f5}");
    }

    /// <summary>
    /// closes the active tab in a browser
    /// </summary>
    public static void closeTab()
    {
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            
        }
        SendKeys.SendWait("^w");
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
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            
        }
        SendKeys.SendWait("^v");
    }
    
    /// <summary>
    /// undoes the last changes to text
    /// </summary>
    public static void undo(){
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            
        }
        SendKeys.SendWait("^z");
    }

    /// <summary>
    /// redoes the last changes to text
    /// </summary>
    public static void redo(){
        Process fgproc = GetForegroundProcess();
        Process [] processes = Process.GetProcessesByName(fgproc.ProcessName);

        foreach(Process proc in processes)
        {
            SetForegroundWindow(proc.MainWindowHandle);
            
        }
        SendKeys.SendWait("^y");
    }
}


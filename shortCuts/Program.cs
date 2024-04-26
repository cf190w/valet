using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

static class Program
{
    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(Point point);

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point point);

    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint pdwProcessId);

    [DllImport("user32.dll", EntryPoint = "SendMessageW")]  
    public static extern int SendMessageW([InAttribute] System.IntPtr hWnd, int Msg, int wParam, IntPtr lParam);  
    public const int WM_GETTEXT = 13;  
    
    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]  
    internal static extern IntPtr GetFocus();
    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]  
    internal static extern int AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);  
    [DllImport("kernel32.dll")]  
    internal static extern int GetCurrentThreadId();  

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
        return null;
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

    public static void Main(string[] args)
    {
        try{
            uint pointer;
            IntPtr processId;
            String processName = "";


            while(true){
                Thread.Sleep(1000);
                processId = GetWindowUnderCursor();
                pointer = GetWindowThreadProcessId(processId, out pointer);
                Process check = Process.GetCurrentProcess();
                Process fgproc = GetForegroundProcess();
                Console.WriteLine(fgproc.ProcessName);
                //Process process = Process.GetProcessById(pointer);
                //processName = process.ProcessName;
                processName = GetActiveProcessFileName();
                Console.WriteLine(processId);
                Console.WriteLine(processName);
                
                //Console.WriteLine(GetTextFromFocusedControl());

                Console.WriteLine("process.getWindow: "+pointer);
                Console.WriteLine("process.getProcess: "+check.Id);
                
                
                //Console.WriteLine(GetProcessesFileName(processId, out processName));
                //Stop(fgproc.ProcessName);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            String[] redo = new string[0];    
            Main(redo);
        }
        
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
    public static void Stop(String processName){
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
        SendKeys.SendWait("^c");
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

    /* private static string GetTextFromFocusedControl()  
    {  
      try  
      {  
        int activeWinPtr = GetForegroundWindow().ToInt32();  
        uint activeThreadId = 0, processId;  
        activeThreadId = GetWindowThreadProcessId(activeWinPtr, out processId);  
        int currentThreadId = GetCurrentThreadId();  
        if (activeThreadId != currentThreadId)  
        AttachThreadInput((int)activeThreadId, currentThreadId, true);  
        IntPtr activeCtrlId = GetFocus();  
  
        return GetText(activeCtrlId);  
      }  
      catch (Exception exp)  
      {  
        return exp.Message;  
      }  
    }  
    private static string GetText(IntPtr handle)  
    {  
      int maxLength = 100;  
      IntPtr buffer = Marshal.AllocHGlobal((maxLength + 1) * 2);  
      SendMessageW(handle, WM_GETTEXT, maxLength, buffer);  
      String w = Marshal.PtrToStringUni(buffer);  
      Marshal.FreeHGlobal(buffer);  
      return w;  
    }  */
     
}


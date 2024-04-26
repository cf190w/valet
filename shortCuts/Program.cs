using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms.Keys;

static class Program
{
    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(Point point);

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out Point point);

    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint pdwProcessId);

    [DllImport("user32.dll")]
    public static extern int GetProcessId(IntPtr handle);

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

   // private IKeyboardMouseEvents globalMouseHook
    
   // [DllImport("user32.dll")]
   // public static extern int GetForegroundWindow();
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
                
                Console.WriteLine(GetTextFromFocusedControl());
                refresh();
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
    public static Process FindProcess(IntPtr handle){
        foreach(Process process in Process.GetProcesses()){
            if(process.Handle == handle){
                return process;
            }
        }
        return null;
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
    public static void StopActive(){
        Process fgproc = GetForegroundProcess();
        Process[] process = Process.GetProcessesByName(fgproc.ProcessName);
        foreach(Process aProcess in process){
            aProcess.Kill();
        }
    }
    public static void refresh(){
        Process [] processes = Process.GetProcessesByName("iexplore");

            foreach(Process proc in processes)
            {
                SetForegroundWindow(proc.MainWindowHandle);
                SendKeys.SendWait("{F5}");
            }

    }

[DllImport("user32.dll", SetLastError = true)]
static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
public static void PressKey(Keys key, bool up) {
    const int KEYEVENTF_EXTENDEDKEY = 0x1;
    const int KEYEVENTF_KEYUP = 0x2;
    if (up) {
        keybd_event((byte) key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr) 0);
    }
    else {
        keybd_event((byte) key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr) 0);
    }
}

void TestProc() {
    PressKey(Keys.ControlKey, false);
    PressKey(Keys.P, false);
    PressKey(Keys.P, true);
    PressKey(Keys.ControlKey, true);
}
    public static void copy(){
        Process [] processes = Process.GetProcessesByName("iexplore");

            foreach(Process proc in processes)
            {
                SetForegroundWindow(proc.MainWindowHandle);
                SendKeys.SendWait("{F5}");
            }
    }
    public static void CopyFromEditor(){
       
    }   
    private static IntPtr GetFocusedControl()  
    {  
 
        int activeWinPtr = GetForegroundWindow().ToInt32();  
        uint activeThreadId = 0, processId;  
        activeThreadId = GetWindowThreadProcessId(activeWinPtr, out processId);  
        int currentThreadId = GetCurrentThreadId();  
        if (activeThreadId != currentThreadId)  
        AttachThreadInput((int)activeThreadId, currentThreadId, true);  
        IntPtr activeCtrlId = GetFocus();  
  
        return activeCtrlId;  
       
    }  
     private static string GetTextFromFocusedControl()  
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
    }  
     
}


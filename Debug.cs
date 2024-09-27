namespace AdminPanel;

public class Debug
{
    public static void OutputDebugString(string text)
    {
        try
        {
            Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | : " + text);
        }
        catch { }
    }
    public static void CatchExceptions(string functionName, Exception ex)
    {
        try
        {
            Console.WriteLine("[EXCEPTION " + functionName + "] " + ex.Message);
            Console.WriteLine("[EXCEPTION " + functionName + "] " + ex.StackTrace);
        }
        catch { }
    }
}
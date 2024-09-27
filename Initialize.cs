using AltV.Net;

namespace AdminPanel;

public class Initialize : Resource
{
    public override void OnStart()
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Debug.OutputDebugString("Alt:V Admin Panel started...");
        Console.ResetColor();
    }

    public override void OnStop()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Debug.OutputDebugString("Alt:V Voice - Admin Panel stopped...");
        Console.ResetColor();
    }
}
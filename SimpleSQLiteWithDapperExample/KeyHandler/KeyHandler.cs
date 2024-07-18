namespace SimpleSQLiteExample.KeyHandler;

internal static class KeyHandler
{
    internal static void WaitForAnyKey()
    {
        Console.WriteLine("\n\nPress any key to exit...");
        Console.ReadKey();
    }
}

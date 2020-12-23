public static class MenuManager 
{
    public static bool Active { get; set; } 

    public static void ActivateMenu()
    {
        Active = true;
        CursorManager.Instance.ResetCursor();
    }
}
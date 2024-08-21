namespace OGRIT_Database_Custom_App.Generics
{
    public static class ScreenDestroyer
    {
        public static void DestroyScreen<T>(ref T? screen) where T : UserControl
        {
            if (screen == null) { return; }
            screen.Dispose();
            screen = null;
        }
    }
}

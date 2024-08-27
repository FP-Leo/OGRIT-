namespace OGRIT_Database_Custom_App.Generics
{
    /// <summary>
    /// A utility class for safely destroying user control screens.
    /// </summary>
    public static class ScreenDestroyer
    {
        /// <summary>
        /// Disposes of the given screen and sets the reference to null.
        /// </summary>
        /// <typeparam name="T">The type of the screen, which must be a UserControl.</typeparam>
        /// <param name="screen">The screen to be destroyed, passed by reference.</param>
        public static void DestroyScreen<T>(ref T? screen) where T : UserControl
        {
            if (screen == null) { return; }
            screen.Dispose();
            screen = null;
        }
    }
}

namespace OGRIT_Database_Custom_App.Generics
{
    public static class ScreenEnums
    {
        public enum Screens
        {
            StartingScreen,
            LogInScreen,
            MenuScreen,
            // Menu options, added here to avoid using two switch statements
            ManageConnectionsScreen,
            ViewProceduresScreen,
            ExecuteProceduresScreen,
            Quit
        }
        public enum ConnectionMenuOptions
        {
            ShowConnections,
            Insert,
            Update,
            Delete,
            Menu
        }
    }
}

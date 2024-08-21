namespace OGRIT_Database_Custom_App.Generics
{
    public static class ScreenInitializer
    {
        // 
        // LogInScreen
        // 
        public static LogInScreen InitializeLogInScreen()
        {
            return new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "LogInScreen",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };
        }
        // 
        // StartingScreen
        // 
        public static StartingScreen InitializeStartingScreen()
        {
            return new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                MinimumSize = new Size(825, 450),
                Name = "StartingScreen",
                Size = new Size(825, 450),
                TabIndex = 0,
                Visible = true
            };
        }
        // 
        // MenuScreen
        //
        public static MenuScreen InitializeMenuScreen()
        { 
            return new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "MenuScreen",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };
        }
        // 
        // ConnectionsScreen
        // 
        public static ManageConnectionsScreen InitializeConnectionsScreen()
        {
            return new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "ConnectionScreen",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };
        }
        // 
        // ProcedureListScreen
        // 
        public static void InitializeProcedureList()
        {
            // To be implemented
        }
        // 
        // ExecutionScreen
        //
        public static void InitializeExecutionScreen()
        {
            // To be implemented
        }

    }
}

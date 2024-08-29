using OGRIT_Database_Custom_App.Views.Screens;

namespace OGRIT_Database_Custom_App.Generics
{
    /// <summary>
    /// A utility class for initializing various screens within the OGRIT Database Custom Application.
    /// </summary>
    public static class ScreenInitializer
    {
        /// <summary>
        /// Initializes and returns a new instance of the <see cref="LogInScreen"/> class.
        /// </summary>
        /// <returns>A fully configured instance of <see cref="LogInScreen"/>.</returns>
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

        /// <summary>
        /// Initializes and returns a new instance of the <see cref="StartingScreen"/> class.
        /// </summary>
        /// <returns>A fully configured instance of <see cref="StartingScreen"/>.</returns>
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

        /// <summary>
        /// Initializes and returns a new instance of the <see cref="MenuScreen"/> class.
        /// </summary>
        /// <returns>A fully configured instance of <see cref="MenuScreen"/>.</returns>
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

        /// <summary>
        /// Initializes and returns a new instance of the <see cref="ManageConnectionsScreen"/> class.
        /// </summary>
        /// <returns>A fully configured instance of <see cref="ManageConnectionsScreen"/>.</returns>
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

        /// <summary>
        /// Initializes and returns a new instance of the <see cref="ProcedureListScreen"/> class.
        /// </summary>
        /// <returns>A fully configured instance of <see cref="ProcedureListScreen"/>.</returns>
        public static ProcedureListScreen InitializeProcedureList()
        {
            return new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "ViewProcedureListScreen",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };
        }

        /// <summary>
        /// Initializes and returns a new instance of the <see cref="ExecuteProceduresScreen"/> class.
        /// </summary>
        /// <returns>A fully configured instance of <see cref="ExecuteProceduresScreen"/>.</returns>
        public static ExecuteProceduresScreen InitializeExecutionScreen()
        {
            return new()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "ExecuteProceduresList",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };
        }
    }
}

using OGRIT_Database_Custom_App.Models;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Generics
{
    public class DelegateContainer
    {
        public delegate void ScreenChanger();
        public delegate void MenuScreenChanger(SubScreens selected);
        public delegate void LogInScreenChanger(ConnectionString connection);
        public delegate void ConnectionScreenChanger(ConnectionMenuOptions selected);
        public delegate void FillSignal();
        public delegate void Refresher();
    }
}

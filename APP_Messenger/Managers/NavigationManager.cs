using APP_Messenger.Tools;

namespace APP_Messenger.Managers
{
    /// <summary>
    /// Singleton manager used to help with navigation between controls
    /// </summary>
    internal class NavigationManager
    {
        private static readonly object Lock = new object();

        private static NavigationManager _instance;

        public static NavigationManager Instance
        {
            get
            {
                //If object is already initialized, then return it
                if (_instance != null)
                    return _instance;
                //Lock operator for threads synchronization, in case few threads 
                //will try to initialize Instance at the same time
                lock (Lock)
                {
                    //Initialize Singleton instance and return its object
                    return _instance = new NavigationManager();
                }
            }
        }

        private NavigationModel _navigationModel;

        internal void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ModelsEnum model)
        {
            _navigationModel?.Navigate(model);
        }
    }
}

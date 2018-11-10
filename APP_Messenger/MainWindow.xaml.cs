using System.Windows.Controls;
using APP_Messenger.Managers;
using APP_Messenger.Tools;

namespace APP_Messenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            navigationModel.Navigate(ModelsEnum.LogIn);
        }

        public ContentControl ContentControl => _contentControl;
    }
}

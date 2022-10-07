using System.Windows;

namespace BAPetitionCounter
{
    /// <summary>
    /// DebugWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            FetchingURLTextBox.Text = ((MainWindow)Owner).GetUrl();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Owner).SetUrl(FetchingURLTextBox.Text);
            Close();
        }
    }
}

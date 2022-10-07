using System.Windows;

namespace BAPetitionCounter
{
    /// <summary>
    /// SettingWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            DelayTextBox.Text = ((MainWindow)Owner).GetDelay().ToString();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(DelayTextBox.Text, out int n))
            {
                if (n >= 5000)
                {
                    ((MainWindow)Owner).SetDelay(n);
                    Close();
                }
                else
                {
                    MessageBox.Show("값은 5000보다 커야 합니다.");
                }
            }
            else
            {
                MessageBox.Show("올바르지 않은 값입니다.");
            }
        }
    }
}

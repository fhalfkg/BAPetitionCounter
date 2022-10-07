using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Net.WebRequestMethods;

namespace BAPetitionCounter
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        int delay = 5000;
        string url = "https://petitions.assembly.go.kr/api/petits/E1F0379DA6573803E054B49691C1987F";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        async private void Window_Initialized(object sender, EventArgs e)
        {
            while (true)
            {
                var agreed = await PetitionInfoFetcher.Fetch(url);
                var percentage = (double)agreed / 50000 * 100;
                Percentage.Text = $"{Math.Truncate(percentage * 1000) / 1000}% ({string.Format("{0:n0}", agreed)}명/50,000명)";
                _ = agreed >= 50000 ? PetitionProgressBar.Value = PetitionProgressBar.Maximum : PetitionProgressBar.Value = percentage;
                Debug.WriteLine(agreed);
                await Task.Delay(delay);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SetFetchingDelay_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow settingWindow = new();
            settingWindow.Show();
        }
        private void DebugSetting_Click(object sender, RoutedEventArgs e)
        {
            DebugWindow debugWindow = new();
            debugWindow.Show();
        }

        internal void SetDelay(int n)
        {
            delay = n;
        }

        internal int GetDelay()
        {
            return delay;
        }
        internal void SetUrl(string s)
        {
            url = s;
        }

        internal string GetUrl()
        {
            return url;
        }
    }
}

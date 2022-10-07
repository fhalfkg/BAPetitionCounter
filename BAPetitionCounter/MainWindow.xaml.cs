﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BAPetitionCounter
{
    public partial class MainWindow : Window
    {
        int delay = 5000;
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
                var agreed = await PetitionInfoFetcher.Fetch();
                var percentage = (double)agreed / 50000 * 100;
                Percentage.Text = $"{Math.Truncate(percentage * 1000) / 1000}% ({string.Format("{0:n0}", agreed)}명/50,000명)";
                _ = agreed >= 50000 ? PetitionProgressBar.Value = PetitionProgressBar.Maximum : PetitionProgressBar.Value = percentage;
                await Task.Delay(5000);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
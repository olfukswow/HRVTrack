using HRVTrack.ViewModel.Helpers;
using System.Windows;
using HRVTrack.View;
namespace HRVTrack
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            MainContent.Content = new MainPageUserControl();
            DatabaseHelper.InitializeDatabase();
        }

        private void MainPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MainPageUserControl();
        }

        private void MeasurmentsPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new MeasurmentsPageUserControl();
        }

        private void StatsPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new StatsPageUserControl();
        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SettingsPageUserControl();
        }
    }
}
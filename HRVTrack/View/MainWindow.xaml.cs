using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HRVTrack.View;
namespace HRVTrack
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            MainContent.Content = new MainPageUserControl();
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
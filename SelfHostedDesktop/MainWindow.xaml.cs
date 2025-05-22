using System.Windows;

namespace SelfHostedDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartApi_Click(object sender, RoutedEventArgs e)
        {
            ApiServer.Start();
        }

        private async void StopApi_Click(object sender, RoutedEventArgs e)
        {
            await ApiServer.Stop();
        }
    }
}
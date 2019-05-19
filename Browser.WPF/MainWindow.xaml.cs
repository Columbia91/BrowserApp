using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Browser.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WebBrowser webBrowser;
        private static int counter = 1;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void UrlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            webBrowser = (WebBrowser)tabControl.SelectedContent;
            if (e.Key == Key.Enter)
            {
                webBrowser.Navigate("https://www.google.com/search?q=" + urlTextBox.Text);
                //urlTextBox.Text = string.Empty;
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            webBrowser = (WebBrowser)tabControl.SelectedContent;
            if (webBrowser.CanGoBack)
                webBrowser.GoBack();
        }

        private void GoForwardButton_Click(object sender, RoutedEventArgs e)
        {
            webBrowser = (WebBrowser)tabControl.SelectedContent;
            if (webBrowser.CanGoForward)
                webBrowser.GoForward();
        }

        private void BrowseRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            webBrowser = (WebBrowser)tabControl.SelectedContent;
            webBrowser.Refresh();
        }

        private void UrlTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(urlTextBox.Text == "Введите поисковый запрос...")
            {
                TextBox textBox = (TextBox)sender;
                textBox.Text = string.Empty;
                textBox.GotFocus -= UrlTextBox_GotFocus;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void PageAddButton_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser newWebBrowser = new WebBrowser();
            newWebBrowser.Source = new Uri("https://www.google.com/");
            tabControl.Items.Add(new TabItem
            {
                Header = new TextBlock { Text = "Google" },
                Content = newWebBrowser
            });
            tabControl.SelectedIndex = counter;
            counter++;
        }

        private void PageCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if(tabControl.Items.Count > 1)
            {
                tabControl.Items.RemoveAt(tabControl.SelectedIndex);
                counter--;
            }
        }
    }
}

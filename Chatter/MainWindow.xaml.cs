using System;
using System.Windows;
using System.Windows.Controls;
using ObserverLib;

namespace Chatter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConcreteSubject subject;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            subject = new ConcreteSubject();
            numbClients.Content = $"Nr Clients {subject.NumberOfCLients}";
        }

        private void StartClient_OnClick(object sender, RoutedEventArgs e)
        {
            var observer = new ConcreteObserver(subject, newClientName.Text, this);
            Refresh();
        }

        public void Refresh()
        {
            numbClients.Content = $"Nr Clients {subject.NumberOfCLients}";
        }

        private void NewClientName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            startClient.IsEnabled = newClientName.Text.Length != 0;
        }

        public void addMessage(string name, string msg)
        {
            messages.Items.Add($"{DateOnly.FromDateTime(DateTime.Now)} {name} {msg}");
        }
        
        public void addLog(string name, string msg)
        {
            server.Items.Add($"{DateOnly.FromDateTime(DateTime.Now)} {name} {msg}");
        }
    }
}
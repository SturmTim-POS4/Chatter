using System;
using System.Windows;

namespace Chatter;

public partial class ClientWindow : Window
{
    private ConcreteObserver observer;
    private ConcreteSubject subject;

    private MainWindow mainWindow;
    
    public ClientWindow(ConcreteObserver observer, ConcreteSubject subject, MainWindow mainWindow)
    {
        InitializeComponent();
        this.observer = observer;
        this.subject = subject;
        clientName.Content = observer.ClientName;
        this.mainWindow = mainWindow;
        this.mainWindow.addLog(this.observer.ClientName, "Attached");
    }

    private void ClientWindow_OnClosed(object? sender, EventArgs e)
    {
        subject.Detach(observer);
        mainWindow.addLog(this.observer.ClientName, "Detached");
        mainWindow.Refresh();
    }

    public void addToList(string name, string msg)
    {
        messageBox.Items.Add($"{DateOnly.FromDateTime(DateTime.Now)} {name} {msg}");
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        subject.Notify(observer.ClientName, message.Text);
        mainWindow.addMessage(this.observer.ClientName, message.Text);
        
    }
}
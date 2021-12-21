using ObserverLib;

namespace Chatter;

public class ConcreteObserver : IObserver
{
    public string ClientName { get; set; }
    public string TopicOfInterest { get; set; }
    
    private readonly ConcreteSubject subject;

    private ClientWindow clientWindow;

    public ConcreteObserver(ConcreteSubject subject, string clientName, MainWindow mainWindow)
    {
        this.subject = subject;
        ClientName = clientName;
        clientWindow = new ClientWindow(this, subject, mainWindow);
        clientWindow.Show();
        subject.Attach(this);
    }

    public void Update(string name, string msg)
    {
        clientWindow.addToList(name,msg);
    }

    public void ClientAttached(string name)
    {
        clientWindow.addToList(name,"Joined");
    }

    public void ClientDetached(string name)
    {
        clientWindow.addToList(name,"Left");
    }

    public void Exit()
    {
        subject.Detach(this);
        clientWindow.Close();
    }
}
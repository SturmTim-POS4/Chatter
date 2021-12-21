namespace ObserverLib;

public interface IObserver
{
    public string ClientName { get; set; }

    public string TopicOfInterest { get; set; }
    void Update(string name, string msg);
    
    void ClientAttached(string name);
    
    void ClientDetached(string name);
}
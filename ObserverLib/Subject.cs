namespace ObserverLib;

public class Subject
{
    private readonly List<IObserver> _observers = new();

    public int NumberOfCLients { get; set; }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
        _observers.ForEach(x => x.ClientAttached(observer.ClientName));
        NumberOfCLients++;
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        _observers.ForEach(x => x.ClientDetached(observer.ClientName));
        NumberOfCLients--;
    }

    public void Notify(string name, string msg)
    {
        _observers.ForEach(x => x.Update(name, msg));
    }
}
namespace BuildingSurveillanceSystemApplication;

public class UnSubscriber<ExternalVisitor> : IDisposable
{
    private List<IObserver<ExternalVisitor>> _observers;
    private IObserver<ExternalVisitor> _observer;
    public UnSubscriber(List<IObserver<ExternalVisitor>> observers, IObserver<ExternalVisitor> observer)
    {
        _observers = observers;
        _observer = observer;
    }

    public void Dispose()
    {
        if (_observers.Contains(_observer))
            _observers.Remove(_observer);
    }
}


namespace BuildingSurveillanceSystemApplication;

public class SecuritySurveillanceHub : IObservable<ExternalVisitor>
{
    private List<ExternalVisitor> _externalVisitors;
    private List<IObserver<ExternalVisitor>> _observers;

    public SecuritySurveillanceHub()
    {
        _externalVisitors = new List<ExternalVisitor>();
        _observers = new List<IObserver<ExternalVisitor>>();
    }

    public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);

        foreach (var externalVisitor in _externalVisitors)
            observer.OnNext(externalVisitor);

        return new UnSubscriber<ExternalVisitor>(_observers, observer);

    }

    public void ConfirmExternalVisitorEntersBuilding(int id, string firstName, string lastName, string companyName, string jobTitle, DateTime entryDateTime, int employeeContactId)
    {
        ExternalVisitor externalVisitor = new ExternalVisitor
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            CompanyName = companyName,
            JobTitle = jobTitle,
            EntryDateTime = entryDateTime,
            InBuilding = true,
            EmployeeContactId = employeeContactId
        };

        _externalVisitors.Add(externalVisitor);

        foreach (var observer in _observers)
            observer.OnNext(externalVisitor);

    }
    public void ConfirmExternalVisitorExitsBuilding(int externalVisitorId, DateTime exitDateTime)
    {
        var externalVisitor = _externalVisitors.FirstOrDefault(e => e.Id == externalVisitorId);

        if (externalVisitor != null)
        {
            externalVisitor.ExitDateTime = exitDateTime;
            externalVisitor.InBuilding = false;

            foreach (var observer in _observers)
                observer.OnNext(externalVisitor);
        }
    }
    public void BuildingEntryCutOffTimeReached()
    {
        if (_externalVisitors.Any(e => e.InBuilding == true))
        {
            return;
        }

        foreach (var observer in _observers)
            observer.OnCompleted();
    }
}


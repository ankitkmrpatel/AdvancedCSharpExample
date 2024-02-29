namespace BuildingSurveillanceSystemApplication;

public class SecurityNotify : Observer
{

    public override void OnCompleted()
    {
        string heading = "Security Daily Visitor's Report";
        Console.WriteLine();

        Console.WriteLine(heading);
        Console.WriteLine(new string('-', heading.Length));
        Console.WriteLine();

        foreach (var externalVisitor in _externalVisitors)
        {
            externalVisitor.InBuilding = false;

            Console.WriteLine($"{externalVisitor.Id,-6}{externalVisitor.FirstName,-15}{externalVisitor.LastName,-15}{externalVisitor.EntryDateTime.ToString("dd MMM yyyy hh:mm:ss"),-25}{externalVisitor.ExitDateTime.ToString("dd MMM yyyy hh:mm:ss tt"),-25}");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    public override void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public override void OnNext(ExternalVisitor value)
    {
        var externalVisitor = value;

        var externalVisitorListItem = _externalVisitors.FirstOrDefault(e => e.Id == externalVisitor.Id);

        if (externalVisitorListItem == null)
        {
            _externalVisitors.Add(externalVisitor);

            OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Security);

            Console.WriteLine($"Security notification: Visitor Id({externalVisitor.Id}), FirstName({externalVisitor.FirstName}), LastName({externalVisitor.LastName}), entered the building, DateTime({externalVisitor.EntryDateTime.ToString("dd MMM yyyy hh:mm:ss tt")})");

            OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Normal);

            Console.WriteLine();
        }
        else
        {
            if (externalVisitor.InBuilding == false)
            {
                //update local external visitor list item with data from the external visitor object passed in from the observable object
                externalVisitorListItem.InBuilding = false;
                externalVisitorListItem.ExitDateTime = externalVisitor.ExitDateTime;

                Console.WriteLine($"Security notification: Visitor Id({externalVisitor.Id}), FirstName({externalVisitor.FirstName}), LastName({externalVisitor.LastName}), exited the building, DateTime({externalVisitor.ExitDateTime.ToString("dd MMM yyyy hh:mm:ss tt")})");
                Console.WriteLine();

            }
        }

    }
}


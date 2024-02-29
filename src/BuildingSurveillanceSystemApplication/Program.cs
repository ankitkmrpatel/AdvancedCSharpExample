// See https://aka.ms/new-console-template for more information
using BuildingSurveillanceSystemApplication;

Console.WriteLine("Hello, World!");

SecuritySurveillanceHub securitySurveillanceHub = new SecuritySurveillanceHub();

EmployeeNotify employeeNotify = new EmployeeNotify(new Employee
{
    Id = 1,
    FirstName = "Bob",
    LastName = "Jones",
    JobTitle = "Development Manager"
});
EmployeeNotify employeeNotify2 = new EmployeeNotify(new Employee
{
    Id = 2,
    FirstName = "Dave",
    LastName = "Kendal",
    JobTitle = "Chief Information Officer"
});

SecurityNotify securityNotify = new SecurityNotify();

employeeNotify.Subscribe(securitySurveillanceHub);
employeeNotify2.Subscribe(securitySurveillanceHub);
securityNotify.Subscribe(securitySurveillanceHub);

securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(1, "Andrew", "Jackson", "The Company", "Contractor", DateTime.Parse("12 May 2020 11:00"), 1);
securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(2, "Jane", "Davidson", "Another Company", "Lawyer", DateTime.Parse("12 May 2020 12:00"), 2);

// employeeNotify.UnSubscribe();

securitySurveillanceHub.ConfirmExternalVisitorExitsBuilding(1, DateTime.Parse("12 May 2020 13:00"));

securitySurveillanceHub.BuildingEntryCutOffTimeReached();

//securitySurveillanceHub.ConfirmExternalVisitorExitsBuilding(2, DateTime.Parse("12 May 2020 15:00"));

Console.ReadKey();
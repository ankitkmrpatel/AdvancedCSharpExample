// See https://aka.ms/new-console-template for more information
using ClubMembershipApplication;
using ClubMembershipApplication.Views;

Console.WriteLine("Hello, World!");

IView mainView = Factory.GetMainViewObject();
mainView.RunView();

Console.ReadKey();

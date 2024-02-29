// See https://aka.ms/new-console-template for more information
using ObservablePatternExample;

Console.WriteLine("Hello, World!");

// Define a provider and two observers.
LocationTracker provider = new();
LocationReporter reporter1 = new("FixedGPS");
reporter1.Subscribe(provider);
LocationReporter reporter2 = new("MobileGPS");
reporter2.Subscribe(provider);

provider.TrackLocation(new Location(47.6456, -122.1312));
reporter1.Unsubscribe();

provider.TrackLocation(new Location(47.6677, -122.1199));

provider.TrackLocation(null);


provider.EndTransmission();

Console.ReadLine();
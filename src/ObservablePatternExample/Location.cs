namespace ObservablePatternExample;

public struct Location
{
    double lat, lon;

    public Location(double latitude, double longitude)
    {
        this.lat = latitude;
        this.lon = longitude;
    }

    public double Latitude
    { get { return this.lat; } }

    public double Longitude
    { get { return this.lon; } }
}

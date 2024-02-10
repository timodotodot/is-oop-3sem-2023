using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Route;

public class RouteSection
{
    public RouteSection(int distance, EnvironmentType environment)
    {
        Distance = distance;
        Environment = environment;
    }

    public int Distance { get; private set; }
    public EnvironmentType Environment { get; private set; }
}
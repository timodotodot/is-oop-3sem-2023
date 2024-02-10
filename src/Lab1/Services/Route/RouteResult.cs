using Itmo.ObjectOrientedProgramming.Lab1.Models.Types;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Route;

public class RouteResult
{
    public RouteResult(int fuelConsumed, TypeOfRouteResult result)
    {
        FuelConsumed = fuelConsumed;
        Result = result;
    }

    public int FuelConsumed { get; private set; }
    public TypeOfRouteResult Result { get; private set; }
}
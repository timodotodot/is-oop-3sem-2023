using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Types;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.Route;

public class Route
{
    private readonly List<RouteSection> _routeSections = new List<RouteSection>();
    private readonly int _maxDistance = 500;
    private readonly int _minDistance = 1;

    public void AddRouteSections(int distance, EnvironmentType environment)
    {
        if (distance > _maxDistance || distance < _minDistance)
        {
            throw new DistanceOutOfRangeException("You have exceeded the permitted distances.");
        }

        _routeSections.Add(new RouteSection(distance, environment));
    }

    public RouteResult StartRoute(SpaceShip ship)
    {
        int totalFuelConsumed = 0;
        int sectionFuelConsumed;
        int distanceTravelInSection;
        foreach (RouteSection section in _routeSections)
        {
            sectionFuelConsumed = 0;
            distanceTravelInSection = 0;

            if (section.Environment is NormalSpace && ship is not null)
            {
                if (ship.ImpulseEngine is null)
                {
                    return new RouteResult(totalFuelConsumed, TypeOfRouteResult.LostShip);
                }

                sectionFuelConsumed = ship.ImpulseEngine.FuelConsumtion() * (section.Distance / ship.ImpulseEngine.Speed);
            }

            if (section.Environment is NebulaeIncreasedDensitySpace && ship is not null)
            {
                if (ship.JumpingEngine is null || ship.JumpingEngine.RangeOfJump < section.Distance)
                {
                    return new RouteResult(totalFuelConsumed, TypeOfRouteResult.LostShip);
                }

                sectionFuelConsumed = ship.JumpingEngine.FuelConsumtion(section.Distance);
            }

            if (section.Environment is NebulaeNitrineParticle && ship is not null)
            {
                if (ship.ImpulseEngine is not ImpulseEngineClassE)
                {
                    return new RouteResult(totalFuelConsumed, TypeOfRouteResult.LostShip);
                }

                while (distanceTravelInSection < section.Distance)
                {
                    distanceTravelInSection += ship.ImpulseEngine.Speed;
                    sectionFuelConsumed += ship.ImpulseEngine.FuelConsumtion();
                    ship.ImpulseEngine.SpeedUp(5);
                }
            }

            foreach (Obstacle obstacle in section.Environment.ObstacleList)
            {
                ship?.TakeDamage(obstacle);

                if (ship is not null && !ship.IsAlive)
                {
                    if (obstacle is AntimatterFlash)
                    {
                        return new RouteResult(totalFuelConsumed, TypeOfRouteResult.CrewIsDead);
                    }

                    if (obstacle is not AntimatterFlash)
                    {
                        return new RouteResult(totalFuelConsumed, TypeOfRouteResult.ShipIsDestroyed);
                    }
                }
            }

            totalFuelConsumed += sectionFuelConsumed;
        }

        return new RouteResult(totalFuelConsumed, TypeOfRouteResult.Success);
    }
}
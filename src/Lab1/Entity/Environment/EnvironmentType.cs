using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public abstract class EnvironmentType
{
    public Stack<Obstacle> ObstacleList { get; init; } = new Stack<Obstacle>();
}
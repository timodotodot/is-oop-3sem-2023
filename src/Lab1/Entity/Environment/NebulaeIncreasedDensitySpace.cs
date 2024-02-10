using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public class NebulaeIncreasedDensitySpace : EnvironmentType
{
    public NebulaeIncreasedDensitySpace(int countOfAntimatterFlashes)
    {
        for (int i = 0; i < countOfAntimatterFlashes; i++)
        {
            ObstacleList.Push(new AntimatterFlash());
        }
    }
}
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public class NebulaeNitrineParticle : EnvironmentType
{
    public NebulaeNitrineParticle(int countOfSpaceWhales)
    {
        for (int i = 0; i < countOfSpaceWhales; i++)
        {
            ObstacleList.Push(new SpaceWhale());
        }
    }
}
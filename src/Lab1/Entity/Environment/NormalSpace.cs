using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;

public class NormalSpace : EnvironmentType
{
   public NormalSpace(int countOfMeoroid, int countOfAsteroid)
   {
      for (int i = 0; i < countOfMeoroid; i++)
      {
         ObstacleList.Push(new Meteoroid());
      }

      for (int i = 0; i < countOfAsteroid; i++)
      {
         ObstacleList.Push(new SmallAsteroid());
      }
   }
}
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Types;
using Itmo.ObjectOrientedProgramming.Lab1.Services.Route;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class CosmosTests
{
    [Theory]
    [InlineData("WalkingShuttle", TypeOfRouteResult.LostShip)]
    [InlineData("Avgur", TypeOfRouteResult.LostShip)]
    public void NISDWalkingShuttleAndAvgurMustLostRouteMediumRange(string typeShip, TypeOfRouteResult expectedResult)
    {
        // Avarange
        var route = new Route();
        SpaceShip ship;
        if (typeShip == "WalkingShuttle")
        {
            ship = new WalkingShuttle();
        }
        else if (typeShip == "Avgur")
        {
            ship = new Avgur(false);
        }
        else
        {
            throw new InvalidTypeException("Invalid type ship");
        }

        // Act
        route.AddRouteSections(200, new NebulaeIncreasedDensitySpace(0));
        RouteResult result = route.StartRoute(ship);

        // Assert
        Assert.Equal(expectedResult, result.Result);
    }

    [Theory]
    [InlineData("VaklasWithoutPhoton", TypeOfRouteResult.CrewIsDead)]
    [InlineData("VaklasWithPhoton", TypeOfRouteResult.Success)]
    public void AntimatterFlashInChannelVaklasWithPhotonMustSuccessVaklasWithoutPhotonMustCrewIsDead(
        string typeShip, TypeOfRouteResult expectedResult)
    {
        // Avarange
        var route = new Route();
        SpaceShip ship;

        if (typeShip == "VaklasWithPhoton")
        {
            ship = new Vaklas(true);
        }
        else if (typeShip == "VaklasWithoutPhoton")
        {
            ship = new Vaklas(false);
        }
        else
        {
            throw new InvalidTypeException("Invalid type ship");
        }

        // Act
        route.AddRouteSections(1, new NebulaeIncreasedDensitySpace(1));
        RouteResult result = route.StartRoute(ship);

        // Assert
        Assert.Equal(expectedResult, result.Result);
    }

    [Theory]
    [InlineData("Vaklas", TypeOfRouteResult.ShipIsDestroyed)]
    [InlineData("Avgur", TypeOfRouteResult.Success)]
    [InlineData("Meredian", TypeOfRouteResult.Success)]
    public void SpaceWhaleInNebulaeNitrineParticle(string typeShip, TypeOfRouteResult expectedResult)
    {
        // Avarange
        var route = new Route();
        SpaceShip ship;

        if (typeShip == "Vaklas")
        {
            ship = new Vaklas(true);
        }
        else if (typeShip == "Avgur")
        {
            ship = new Avgur(true);
        }
        else if (typeShip == "Meredian")
        {
            ship = new Meridian(true);
        }
        else
        {
            throw new InvalidTypeException("Invalid ship type");
        }

        // Act
        route.AddRouteSections(1, new NebulaeNitrineParticle(1));
        RouteResult result = route.StartRoute(ship);

        // Assert
        Assert.Equal(expectedResult, result.Result);
    }

    [Fact]
    public void SmallRouteInNormalSpaceChoseMostOptimalWalkingShuttleAndVaklas()
    {
        // Arrange
        SpaceShip walkingShuttle = new WalkingShuttle();
        SpaceShip vaklas = new Vaklas(false);
        var route = new Route();
        route.AddRouteSections(50, new NormalSpace(0, 0));
        const string expectedResult = "WalkingShuttle";
        string result;

        // Act
        RouteResult resultWalkingShuttle = route.StartRoute(walkingShuttle);
        RouteResult resultVaklas = route.StartRoute(vaklas);

        if (resultVaklas.FuelConsumed < resultWalkingShuttle.FuelConsumed &&
            resultVaklas.Result == TypeOfRouteResult.Success)
        {
            result = "Vaklas";
        }
        else if (resultVaklas.FuelConsumed > resultWalkingShuttle.FuelConsumed ||
                 resultVaklas.Result != TypeOfRouteResult.Success)
        {
            result = "WalkingShuttle";
        }
        else
        {
            throw new InvalidTypeException("Invalid ship type");
        }

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void MediumRouteInNISDChoseMostOptimalAvgurOrStella()
    {
        // Arrange
        SpaceShip avgur = new Avgur(false);
        SpaceShip stella = new Stella(false);
        var route = new Route();
        route.AddRouteSections(200, new NebulaeIncreasedDensitySpace(0));
        const string expectedResult = "Stella";
        string result;

        // Act
        RouteResult resultAvgur = route.StartRoute(avgur);
        RouteResult resultStella = route.StartRoute(stella);

        if (resultAvgur.FuelConsumed < resultStella.FuelConsumed && resultAvgur.Result == TypeOfRouteResult.Success)
        {
            result = "Avgur";
        }
        else if (resultAvgur.FuelConsumed > resultStella.FuelConsumed ||
                 resultAvgur.Result != TypeOfRouteResult.Success)
        {
            result = "Stella";
        }
        else
        {
            throw new InvalidTypeException("Invalid ship type");
        }

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void RouteInNebulaeNitrineParticlChoseMostOptimalWalkingShuttleOrVaklas()
    {
        // Arrange
        SpaceShip walkingShuttle = new WalkingShuttle();
        SpaceShip vaklas = new Vaklas(false);
        var route = new Route();
        route.AddRouteSections(10, new NebulaeNitrineParticle(0));
        const string expectedResult = "Vaklas";
        string result;

        // Act
        RouteResult resultWalkingShuttle = route.StartRoute(walkingShuttle);
        RouteResult resultVaklas = route.StartRoute(vaklas);

        if (resultWalkingShuttle.FuelConsumed < resultVaklas.FuelConsumed &&
            resultWalkingShuttle.Result == TypeOfRouteResult.Success)
        {
            result = "WalkingShuttle";
        }
        else if (resultWalkingShuttle.FuelConsumed > resultVaklas.FuelConsumed ||
                 resultWalkingShuttle.Result != TypeOfRouteResult.Success)
        {
            result = "Vaklas";
        }
        else
        {
            throw new InvalidTypeException("Invalid ship type");
        }

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void MyTest()
    {
        // Avarange
        var route = new Route();
        SpaceShip ship = new Avgur(true);
        TypeOfRouteResult expectedResult = TypeOfRouteResult.Success;

        // Act
        route.AddRouteSections(20, new NebulaeNitrineParticle(1));
        RouteResult result = route.StartRoute(ship);

        // Assert
        Assert.Equal(expectedResult, result.Result);
    }
}

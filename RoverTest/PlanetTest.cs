using System;
using NUnit.Framework;
using MarsRovers;

namespace RoverLibraryTest
{
	[TestFixture()]
	public class PlanetTest
	{
		[Test()]
		public void Create() {
			var planet = new Planet(); // actual test
			Assert.IsNotNull(planet);  // just remove warning
		}

		[Test()]
		public void AddRovers() {
			var planet = new Planet();

			planet.Add(new Rover(0,0,'N'));

			Assert.AreEqual(1,planet.Rovers.Count);
		}

		[Test()]
		public void SetTerrain() {
			var planet = new Planet();

			planet.DefaultTerrain = new Plateau(2,2);
		}

		[Test()]
		public void MoveOverDefault() {
			var planet = new Planet();

			// Set a limited default terrain
			planet.DefaultTerrain = new Plateau(2,2);

			Rover rover = new Rover(0,0,'N');
			rover.Load("MMMMMM"); // Keep trying to move North

			planet.Add(rover);

			planet.MoveRovers();

			// Rover should move to the top (0,1)
			Assert.AreEqual(1,planet.Rovers[0].Y);

		}
	}
}


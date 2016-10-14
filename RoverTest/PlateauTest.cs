using System;
using NUnit.Framework;
using MarsRovers;

namespace RoverLibraryTest
{
	[TestFixture()]
	public class PlateauTest
	{
		Plateau testField;

		[TestFixtureSetUp]
		public void Setup() {
			// Instantiate global test field for testing movements
			testField = new Plateau(2,2);
		}

		[Test()]
		// Create a new plateau with upper-right location
		public void Create() {
			uint x=5;
			uint y=5;

			var field = new Plateau(x,y); // This is the test

			Assert.IsNotNull(field.ToString()); // just get rid of warning only
		}

		[Test()]
		public void NorthFrom() {
			Assert.AreEqual(1,testField.NorthFrom(0));
		}

		[Test()]
		public void NorthFromLimit() {
			uint sizeX = 3;
			uint sizeY = 3;

			var field = new Plateau(sizeX,sizeY);

			// Try and go past the North edge
			Assert.AreEqual(sizeY-1,field.NorthFrom(sizeY-1));
		}

		[Test()]
		public void EastFrom() {
			Assert.AreEqual(1,testField.EastFrom(0));
		}

		[Test()]
		public void EastFromLimit() {
			uint sizeX = 3;
			uint sizeY = 3;

			var field = new Plateau(sizeX,sizeY);

			// Try and go past the East edge
			Assert.AreEqual(sizeX-1,field.EastFrom(sizeX-1));
		}

		[Test()]
		public void SouthFrom() {
			Assert.AreEqual(0,testField.SouthFrom(1));
		}

		[Test()]
		public void SouthFromLimit() {
			Assert.AreEqual(0,testField.SouthFrom(0));
		}

		[Test()]
		public void WestFrom() {
			Assert.AreEqual(0,testField.WestFrom(1));
		}

		[Test()]
		public void WestFromLimit() {
			Assert.AreEqual(0,testField.WestFrom(0));
		}

		[Test()]
		public void TurnLeft() {
			// Turning Left when facing North, faces you West
			Assert.AreEqual('W',testField.Turn('L','N'));
		}

		[Test()]
		public void TurnRight() {
			// Turning Right when facing North, faces you East
			Assert.AreEqual('E',testField.Turn('R','N'));
		}

		[Test()]
		public void CreateFromLine() {
			string line = "5 5";

			var field = new Plateau(line);

			Assert.AreEqual(line,field.ToString());
		}
	}
}

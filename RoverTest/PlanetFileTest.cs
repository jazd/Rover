using System;
using NUnit.Framework;
using MarsRovers;
using System.Text;
using System.IO;

namespace RoverLibraryTest
{
	[TestFixture()]
	public class PlanetFileTest
	{
		string TestFilePath = "TestFile.txt";
		string FileContent = 
@"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
";
		string FileResultPreMove =
@"1 2 N
3 3 E
";
		string FileResultPostMove =
@"1 3 N
5 1 E
";

		// Create the test file
		[TestFixtureSetUp]
		public void SetUp() {
			FileStream stream = File.Create(TestFilePath);
			// File starts with upper right position x,y
			// Then each Rover consists of two lines.  First is starting x,y,facing direction then the movement commands
			var encoding = new ASCIIEncoding();
			byte[] testInputBytes = encoding.GetBytes(FileContent);
			stream.Write(testInputBytes,0,FileContent.Length);
			stream.Close();
		}
		[Test()]
		public void FromFile() {
			var planet = new Planet(TestFilePath);

			Assert.AreEqual(2,planet.Rovers.Count);
		}

		[Test()]
		public void ResultsFromFile() {
			var planet = new Planet(TestFilePath);

			string results = planet.RoverPositions();
			// Verify that rovers loaded correctly
			Assert.AreEqual(FileResultPreMove,results);

			planet.MoveRovers();
			// Verify that rovers moved correctly
			results = planet.RoverPositions();
			Assert.AreEqual(FileResultPostMove,results);
		}

		// Delete the test file
		[TestFixtureTearDown]
		public void TearDown() {
			File.Delete(TestFilePath);
		}
	}
}


using System;
using NUnit.Framework;
using MarsRovers;

namespace RoverLibraryTest
{
	[TestFixture()]
	public class RoverTest
	{
		[Test()]
		public void Create() {
			uint x = 1;
			uint y = 2;
			char face = 'N';

			var rover = new Rover(x,y,face);
			Assert.AreEqual(x,rover.X);
			Assert.AreEqual(y,rover.Y);
			Assert.AreEqual(face,rover.Facing);
		}

		[Test()]
		public void LoadCourse() {
			uint x = 1;
			uint y = 2;
			char face = 'N';

			string course = "LMLMLMLMM";

			var rover = new Rover(x,y,face);

			rover.Load(course);
		}

		[Test()]
		public void MoveInitialFacing() {
			uint x = 1;
			uint y = 2;
			char face = 'N';

			// Position after moving once in the facing direction
			uint x_ = 1;
			uint y_ = 3;
			string output = "1 3 N";

			string course = "M";

			var rover = new Rover(x,y,face);

			rover.Load(course);
			rover.Go(new Plateau(5,5));
			Assert.AreEqual(x_,rover.X);
			Assert.AreEqual(y_,rover.Y);
			Assert.AreEqual(face,rover.Facing);

			Assert.AreEqual(output,rover.ToString());
		}

		[Test()]
		public void FaceAnotherDirection() {
			uint x = 1;
			uint y = 2;
			char face = 'N';

			// Direction after turning
			char nowFacing = 'W';

			string course = "L";

			var rover = new Rover(x,y,face);
			var terrain = new Plateau(5,5);

			rover.Load(course);
			rover.Go(terrain);
			Assert.AreEqual(nowFacing,rover.Facing);

			// Turn back
			string newcourse = "R";
			rover.Load(newcourse);
			rover.Go(terrain);
			Assert.AreEqual(face,rover.Facing);
		}

		[Test()]
		// Test if rover can move in each direction
		public void MoveDirections() {
			// create 7x7 terrain
			uint sizeX = 7;
			uint sizeY = 7;

			uint startX = 3;
			uint startY = 3;

			var terrain = new Plateau(sizeX,sizeY);

			// Place rover in the middle and face North
			var rover = new Rover(startX,startY,'N');

			string course = "M";

			rover.Load(course);
			rover.Go(terrain);

			// Be sure rover has moved North
			Assert.AreEqual(startY+1,rover.Y);

			rover.Load("LM");
			rover.Go(terrain);
			// Should have moved West
			Assert.AreEqual(startX-1,rover.X);

			rover.Go(terrain);
			// Should have moved back South
			Assert.AreEqual(startY,rover.Y);

			rover.Go(terrain);
			// Should have moved back West and back to where we started
			Assert.AreEqual(startX,rover.X);
		}

		[Test()]
		public void MovePastEdgeNorth() {
			// create 6x6 terrain
			uint sizeX = 6;
			uint sizeY = 6;

			var terrain = new Plateau(sizeX,sizeY);

			// Place rover on North edge and face North
			var rover = new Rover(0,sizeY-1,'N');

			string course = "M";

			rover.Load(course);
			rover.Go(terrain);
			// Be sure rover is still at the North edge
			Assert.AreEqual(sizeY-1,rover.Y);
		}

		[Test()]
		public void MovePastEdgeSouth() {
			// create 6x6 terrain
			uint sizeX = 6;
			uint sizeY = 6;

			var terrain = new Plateau(sizeX,sizeY);

			// Place rover on South edge and face South
			var rover = new Rover(0,0,'S');

			string course = "M";

			rover.Load(course);
			rover.Go(terrain);
			// Be sure rover is still at the South edge
			Assert.AreEqual(0,rover.Y);
		}

		[Test()]
		public void MovePastEdgeWest() {
			// create 6x6 terrain
			uint sizeX = 6;
			uint sizeY = 6;

			var terrain = new Plateau(sizeX,sizeY);

			// Place rover on West edge and face West
			var rover = new Rover(0,0,'W');

			string course = "M";

			rover.Load(course);
			rover.Go(terrain);
			// Be sure rover is still at the West edge
			Assert.AreEqual(0, rover.X);
		}

		[Test()]
		public void MovePastEdgeEast() {
			// create 6x6 terrain
			uint sizeX = 6;
			uint sizeY = 6;

			var terrain = new Plateau(sizeX,sizeY);

			// Place rover on East edge and face East
			var rover = new Rover(sizeX -1,0,'E');

			string course = "M";

			rover.Load(course);
			rover.Go(terrain);
			// Be sure rover is still at the North edge
			Assert.AreEqual(sizeX -1, rover.X);
		}

		[Test()]
		// Be sure rover1 runs as expected
		public void YourExpectedRover1() {
			var terrain = new Plateau(6,6);
			var rover1 = new Rover(1,2,'N');

			rover1.Load("LMLMLMLMM");

			rover1.Go(terrain);

			Assert.AreEqual("1 3 N",rover1.ToString());
		}

		[Test()]
		// Be sure rover2 runs as expected
		public void YourExpectedRover2() {
			var terrain = new Plateau(6,6);
			var rover2 = new Rover(3,3,'E');

			rover2.Load("MMRMMRMRRM");

			rover2.Go(terrain);

			Assert.AreEqual("5 1 E",rover2.ToString());
		}

		[Test()]
		public void CreateFromLine() {
			string line = "1 2 N";
			uint x = 1;
			uint y = 2;
			char face = 'N';

			var rover = new Rover(line);
			Assert.AreEqual(x,rover.X);
			Assert.AreEqual(y,rover.Y);
			Assert.AreEqual(face,rover.Facing);
			Assert.AreEqual(line,rover.ToString());
		}
	}
}


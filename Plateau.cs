using System;

namespace MarsRovers
{

	/* Plateau
	 *   Evenually could inherit from a more general class Terrain
	 * Passed to Rover.Go(Plateau terrain)
	 * 
	 * New Plateau of size 6x6
	 * Plateau(6,6)
	 * 
	 */
	public class Plateau
	{
		uint mySizeX;
		uint mySizeY;

		public Plateau(uint x, uint y) {
			mySizeX = x;
			mySizeY = y;
		}

		// Format of create line in a file
		//  "5 5" upper right position is 5,5
		public Plateau(string line) {
			string[] cords = line.Split(' '); // Assume space separated
			// verify some sanity
			if(cords.Length > 1) {
				uint x=0;
				uint y=0;

				uint.TryParse(cords[0],out x);
				uint.TryParse(cords[1],out y);

				mySizeX = x + 1;
				mySizeY = y + 1;
			}
		}

		// Return new y if moving north from y
		public uint NorthFrom(uint y) {
			// Be sure we are not already at max North
			if(y < mySizeY-1)
				return y + 1;
			else
				return mySizeY -1;
		}

		public uint EastFrom(uint x) {
			if(x < mySizeX-1)
				return x + 1;
			else
				return mySizeX -1;
		}

		public uint SouthFrom(uint y) {
			// Be sure we are not already at max South
			if(y > 0)
				return y - 1;
			else
				return 0;
		}

		public uint WestFrom(uint x) {
			if(x > 0)
				return x - 1;
			else
				return 0;
		}

		public char Turn(char direction, char facing) {
			var compass = new Compass(facing);
			char newDirection = facing;  // If direction is not recognized, do not change direction, untested

			switch(direction) {
			case 'L':
				newDirection = compass.TurnLeft();
				break;
			case 'R':
				newDirection = compass.TurnRight();
				break;
			}

			return newDirection;
		}

		public override string ToString() {
			return string.Format ("{0} {1}",mySizeX -1, mySizeY -1);
		}
	}

	// Helper class to convert Facing direction after turning left or right
	public class Compass
	{
		uint left = 0;
		uint right = 1;

		char Direction {get;set;}

		public Compass(char direction) {
			Direction = direction;
		}

		public char TurnLeft() {
			return Turn(left);
		}

		public char TurnRight() {
			return Turn(right);
		}

		public char Turn(uint tothe) {
			switch(Direction) {
			case 'N':
				return tothe == left ? 'W' : 'E';
			case 'S':
				return tothe == left ? 'E' : 'W';
			case 'E':
				return tothe == left ? 'N' : 'S';
			case 'W':
				return tothe == left ? 'S' : 'N';
			}

			return Direction;  // did not recognize direction
		}
	}
}


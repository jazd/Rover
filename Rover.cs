using System;

namespace MarsRovers
{
	/* Rover
	 * 
	 * New Rover
	 * Rover(postition X, position Y, direction facing)
	 * 
	 * Load Course Commands
	 *   L = Turn Left, R = Turn Right, M = Move in facing direction
	 *   rover.Load(String commands)
	 * 
	 * Move rover using a Terrain
	 *   rover.Go(Plateau terrain)
	 * 
	 * Assumptions
	 *  Rover may get Terrain updates after completing a series of move commands
	 *  All Terrains are Plateaus for now
	 */
	public class Rover
	{
		string myCourse;
		Plateau myTerrain;

		public uint X {get;set;}
		public uint Y {get;set;}
		public char Facing {get;set;}

		public Plateau Terrain {
			get {
				if(myTerrain == null) {
					// Default to 2x2 terrain.  Tests will not pass with default terrain
					myTerrain = new Plateau(1,1);
				}
				return myTerrain;
			}
			set {
				myTerrain = value;
			}
		}

		// Create new Rover with starting position and starting facing direction
		public Rover(uint x, uint y, char face) {
			X = x;
			Y = y;
			Facing = face;
		}

		// Create new Rover from line in file
		public Rover(string line) {
			string[] specs = line.Split(' '); // Assume space separated
			// verify some sanity
			if(specs.Length > 2) {
				uint x=0;
				uint y=0;
				char face='S';

				uint.TryParse(specs[0],out x);
				uint.TryParse(specs[1],out y);
				if(!String.IsNullOrEmpty(specs[2]))
					face = specs[2][0];

				X = x;
				Y = y;
				Facing = face;
			}

		}

		// Load course for this rover
		// Move, turn Left, trun Right
		//  "LMLM" = turn Left, Move forward, turn Left, Move forward
		public void Load(string course) {
			myCourse = course;
		}

		// Execute course commands using passed terrain
		public void Go(Plateau terrain) {
			Terrain = terrain;
			Go();
		}

		// TODO: Go(String commands)

		public void Go() {
			// Process each character command in the course string
			foreach(char i in myCourse) {
				switch(i) {
				case 'M': // move in the facing direction
					Move();
					break;
				case 'L': // execute a left turn
				case 'R': // exectue a right turn
					Turn(i);
					break;
				}
			}
		}

		// Attempt to move the facing direction
		void Move() {
			switch(Facing) {
			case 'N': // move north
				Y = Terrain.NorthFrom(Y);
				break;
			case 'S': // move south
				Y = Terrain.SouthFrom(Y);
				break;
			case 'E': // move east
				X = Terrain.EastFrom(X);
				break;
			case 'W': // move west
				X = Terrain.WestFrom(X);
				break;
			}
		}

		// Turn Left or Right from facing direction
		void Turn(char direction) {
			Facing = Terrain.Turn(direction,Facing);
		}

		// Provide required output by default
		public override string ToString() {
			return string.Format ("{0} {1} {2}", X, Y, Facing);
		}
	}
}


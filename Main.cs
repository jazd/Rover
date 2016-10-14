using System;

namespace MarsRovers
{
	class MainClass
	{
		// MarsRovers.exe TestFile.txt
		public static void Main(string[] args) {
#if DEBUG
			args = new string[] {"TestFile.txt"};
#endif
			if(Usage(args)) {
				// Filename is first Argument
				string filename = args[0];

				// Load planet from file
				Planet planet = new Planet(filename);

				// Move the rovers
				planet.MoveRovers();

				// Write the position of all the rovers
				Console.Write(planet.RoverPositions());
			}
		}

		static bool Usage(string[] args) {
			var ok = false;

			if(args.Length < 1)
				Console.WriteLine("Usage MarsRovers <filename>\n");
			else ok = true;

			return ok;
		}
	}
}

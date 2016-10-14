using System;
using System.IO;

namespace MarsRovers
{
	// IO based methods for Planet Class
	public partial class Planet
	{
		// Create planet from file
		public Planet(string path) {
			using(StreamReader reader = File.OpenText(path)) {
				string line;
				// First line of file should be the upper right positon of the Plateau
				if((line = reader.ReadLine()) != null) {
					DefaultTerrain = new Plateau(line);
					// Pickup Rover Lines
					Rover rover;
					while((line = reader.ReadLine()) != null) {
						string commands;
						// First line is a Rover position and direction
						rover = new Rover(line);
						// Next line is the commands
						if((commands = reader.ReadLine()) != null) {
							rover.Load(commands);
						}
						Rovers.Add(rover);
					}
				}
			}
		}
	}
}


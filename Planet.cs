using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers
{
	/* Planet
	 * 
	 * Holds list of Rovers and a default Terrain
	 */
	public partial class Planet
	{
		List<Rover> myRovers;

		public Plateau DefaultTerrain {get;set;}

		public List<Rover> Rovers {
			get {
				if(myRovers == null)
					myRovers = new List<Rover>();
				return myRovers;
			}
			set {
				myRovers = value;
			}
		}

		public Planet() {}

		// Add a rover
		public void Add(Rover rover) {
			Rovers.Add(rover);
		}

		// Move each rover in turn
		public void MoveRovers() {
			foreach(Rover r in Rovers) {
				r.Go(DefaultTerrain);
			}
		}

		// Output current positions of all the rovers as text
		public string RoverPositions() {
			StringBuilder output = new StringBuilder();
			foreach(Rover r in Rovers) {
				output.Append(r.ToString() + System.Environment.NewLine);
			}
			return output.ToString();
		}
	}
}


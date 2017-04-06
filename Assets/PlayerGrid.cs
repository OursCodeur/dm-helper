using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerGrid : MonoBehaviour {

	public Button 		GridSquare;
	public Button[,] 	squaresArray;

	int WIDTH 			= 17;
	int HEIGHT 			= 17;

	void Start () {

		squaresArray = new Button[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
				squaresArray [x, y] = Instantiate(GridSquare);
				squaresArray [x, y].GetComponent<TwoDCoord> ().x = x;
				squaresArray [x, y].GetComponent<TwoDCoord> ().y = y;
				squaresArray [x, y].transform.SetParent(this.transform, false);
			}
		}
	}
}

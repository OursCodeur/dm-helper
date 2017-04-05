using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {

	public Toggle 		BoardSquare;
	public Toggle[,] 	squaresArray;

    int WIDTH 			= 17;
    int HEIGHT 			= 17;

    void Start() {

		squaresArray = new Toggle[WIDTH,HEIGHT];
		foreach (int x in Enumerable.Range(0, WIDTH)) {
			foreach (int y in Enumerable.Range(0, HEIGHT)) {
				squaresArray [x, y] = Toggle.Instantiate(BoardSquare) as Toggle;
				squaresArray [x, y].transform.SetParent(this.transform, false);
			}
		}
	}
}

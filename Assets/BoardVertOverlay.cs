using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardVertOverlay : MonoBehaviour {

	public Toggle 		BoardSquareVertEdge;
	public Toggle[,] 	vertEdgesArray;

    int WIDTH 			= 16;
    int HEIGHT 			= 17;

    void Start() {

		vertEdgesArray = new Toggle[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
				vertEdgesArray [x, y] = Instantiate(BoardSquareVertEdge);
				vertEdgesArray [x, y].transform.SetParent(this.transform, false);
			}
        }
    }
}

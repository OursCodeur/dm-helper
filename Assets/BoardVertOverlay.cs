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
        foreach (int x in Enumerable.Range(0, WIDTH)) {
			foreach (int y in Enumerable.Range(0, HEIGHT)) {
				vertEdgesArray [x, y] = Instantiate(BoardSquareVertEdge) as Toggle;
				vertEdgesArray [x, y].transform.SetParent(this.transform, false);
			}
        }
    }
}

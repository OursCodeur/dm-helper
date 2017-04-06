using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardHorizOverlay : MonoBehaviour {

	public Toggle 		BoardSquareHorizEdge;
	public Toggle[,] 	horizEdgesArray;

	int WIDTH 			= 17;
	int HEIGHT 			= 16;

	void Start() {

		horizEdgesArray = new Toggle[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
				horizEdgesArray [x, y] = Instantiate(BoardSquareHorizEdge);
				horizEdgesArray [x, y].transform.SetParent(transform, false);
			}
		}
	}
}
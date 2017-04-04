using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardHorizOverlay : MonoBehaviour {

    public Toggle BoardSquareHorizEdge;

    int WIDTH = 17;
    int HEIGHT = 16;

    void Start() {

        foreach (int x in Enumerable.Range(0, WIDTH * HEIGHT)) {
            Toggle newSquare = Instantiate(BoardSquareHorizEdge);
            newSquare.transform.SetParent(this.transform, false);
        }
    }
}

using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardVertOverlay : MonoBehaviour {

    public Toggle BoardSquareVertEdge;

    int WIDTH = 16;
    int HEIGHT = 17;

    void Start() {

        foreach (int x in Enumerable.Range(0, WIDTH * HEIGHT)) {
            Toggle newSquare = Instantiate(BoardSquareVertEdge);
            newSquare.transform.SetParent(this.transform, false);
        }
    }
}

using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour {

    public Toggle BoardSquare;

    int WIDTH = 17;
    int HEIGHT = 17;

    void Start() {

        foreach (int x in Enumerable.Range(0, WIDTH * HEIGHT)) {
            Toggle newSquare = Instantiate(BoardSquare);
            newSquare.transform.SetParent(this.transform, false);
        }
    }
}

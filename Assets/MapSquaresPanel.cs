using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapSquaresPanel : MonoBehaviour {

	public Toggle       MapSquarePrefab;
	public Toggle[,]    MapSquaresArray;

    int WIDTH 			= 17;
    int HEIGHT 			= 17;

    void Start() {

        MapSquaresArray = new Toggle[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
                MapSquaresArray[x, y] = Instantiate(MapSquarePrefab);
                MapSquaresArray[x, y].GetComponent<TwoDCoord> ().coord = new Vector2(x, y);
                MapSquaresArray[x, y].transform.SetParent(transform, false);
			}
		}
	}
}

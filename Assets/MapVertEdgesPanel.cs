using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapVertEdgesPanel : MonoBehaviour {

	public Toggle       MapVertEdgePrefab;
	public Toggle[,] 	MapVertEdgesArray;

    int WIDTH 			= 16;
    int HEIGHT 			= 17;

    void Start() {

		MapVertEdgesArray = new Toggle[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
				MapVertEdgesArray [x, y] = Instantiate(MapVertEdgePrefab);
				MapVertEdgesArray [x, y].transform.SetParent(transform, false);
			}
        }
    }
}

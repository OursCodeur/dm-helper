using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapHorizEdgesPanel : MonoBehaviour {

	public Toggle       MapHorizEdgePrefab;
	public Toggle[,]    MapHorizEdgesArray;

	int WIDTH 			= 17;
	int HEIGHT 			= 16;

	void Start() {

        MapHorizEdgesArray = new Toggle[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
                MapHorizEdgesArray[x, y] = Instantiate(MapHorizEdgePrefab);
                MapHorizEdgesArray[x, y].transform.SetParent(transform, false);
			}
		}
	}
}
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerSquaresPanel : MonoBehaviour {

	public Button 		PlayerSquarePrefab;
	public Button[,] 	PlayerSquaresArray;
	public Button 		currentPlayerCard;

	int WIDTH 			= 17;
	int HEIGHT 			= 17;

	void Start () {

        PlayerSquaresArray = new Button[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
                PlayerSquaresArray[x, y] = Instantiate(PlayerSquarePrefab);
                PlayerSquaresArray[x, y].GetComponent<TwoDCoord> ().coord = new Vector2(x,y);
                PlayerSquaresArray[x, y].GetComponent<PlayerSquare> ().ParentPlayerSquaresPanel = this;
                PlayerSquaresArray[x, y].transform.SetParent(this.transform, false);
			}
		}
	}
}

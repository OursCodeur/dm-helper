using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerCardsGrid : MonoBehaviour {

	public Button 		PlayerCardPrefab;
	public Button[,]    PlayerCardsArray;

	int WIDTH 			= 3;
	int HEIGHT 			= 6;

	void Start () {

        PlayerCardsArray = new Button[WIDTH,HEIGHT];
		foreach (int y in Enumerable.Range(0, HEIGHT)) {
			foreach (int x in Enumerable.Range(0, WIDTH)) {
                PlayerCardsArray[x, y] = Instantiate(PlayerCardPrefab);
                PlayerCardsArray[x, y].GetComponent<TwoDCoord>().coord = new Vector2(x, y);
                PlayerCardsArray[x, y].transform.SetParent(transform, false);
			}
		}
	}
}

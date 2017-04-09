using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerCardsGrid : MonoBehaviour
{
    public Button PlayerCardPrefab;
    public Button[,] PlayerCardsArray;

    private const int Width = 3;
    private const int Height = 6;

    private void Start()
    {
        PlayerCardsArray = new Button[Width, Height];
        foreach (var y in Enumerable.Range(0, Height))
        {
            foreach (var x in Enumerable.Range(0, Width))
            {
                PlayerCardsArray[x, y] = Instantiate(PlayerCardPrefab);
                PlayerCardsArray[x, y].GetComponent<TwoDCoord>().Coord = new Vector2(x, y);
                PlayerCardsArray[x, y].transform.SetParent(transform, false);
            }
        }
    }
}
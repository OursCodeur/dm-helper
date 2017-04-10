using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerSquaresPanel : MonoBehaviour
{
    public Button PlayerSquarePrefab;
    public Button[,] PlayerSquaresArray;
    public Button CurrentPlayerCard;

    private const int Width = 18;
    private const int Height = 18;

    private void Start()
    {
        PlayerSquaresArray = new Button[Width, Height];
        foreach (var y in Enumerable.Range(0, Height))
        {
            foreach (var x in Enumerable.Range(0, Width))
            {
                PlayerSquaresArray[x, y] = Instantiate(PlayerSquarePrefab);
                PlayerSquaresArray[x, y].GetComponent<TwoDCoord>().Coord = new Vector2(x, y);
                PlayerSquaresArray[x, y].GetComponent<PlayerSquare>().ParentPlayerSquaresPanel = this;
                PlayerSquaresArray[x, y].transform.SetParent(transform, false);
            }
        }
    }
}
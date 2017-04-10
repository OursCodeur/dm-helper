using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapSquaresPanel : MonoBehaviour
{
    public Toggle MapSquarePrefab;
    public Toggle[,] MapSquaresArray;

    private const int Width = 18;
    private const int Height = 18;

    private void Start()
    {
        MapSquaresArray = new Toggle[Width, Height];
        foreach (var y in Enumerable.Range(0, Height))
        {
            foreach (var x in Enumerable.Range(0, Width))
            {
                MapSquaresArray[x, y] = Instantiate(MapSquarePrefab);
                MapSquaresArray[x, y].GetComponent<TwoDCoord>().Coord = new Vector2(x, y);
                MapSquaresArray[x, y].transform.SetParent(transform, false);
            }
        }
    }
}
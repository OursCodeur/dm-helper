using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapHorizEdgesPanel : MonoBehaviour
{
    public Toggle MapHorizEdgePrefab;
    public Toggle[,] MapHorizEdgesArray;

    private const int Width = 17;
    private const int Height = 16;

    private void Start()
    {
        MapHorizEdgesArray = new Toggle[Width, Height];
        foreach (var y in Enumerable.Range(0, Height))
        {
            foreach (var x in Enumerable.Range(0, Width))
            {
                MapHorizEdgesArray[x, y] = Instantiate(MapHorizEdgePrefab);
                MapHorizEdgesArray[x, y].transform.SetParent(transform, false);
            }
        }
    }
}
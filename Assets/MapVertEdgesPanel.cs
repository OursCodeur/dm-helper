using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapVertEdgesPanel : MonoBehaviour
{
    public Toggle MapVertEdgePrefab;
    public Toggle[,] MapVertEdgesArray;

    private const int Width = 16;
    private const int Height = 17;

    private void Start()
    {
        MapVertEdgesArray = new Toggle[Width, Height];
        foreach (var y in Enumerable.Range(0, Height))
        {
            foreach (var x in Enumerable.Range(0, Width))
            {
                MapVertEdgesArray[x, y] = Instantiate(MapVertEdgePrefab);
                MapVertEdgesArray[x, y].transform.SetParent(transform, false);
            }
        }
    }
}
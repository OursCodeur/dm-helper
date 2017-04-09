using UnityEngine;
using UnityEngine.UI;

public class MapSquare : MonoBehaviour
{
    private Toggle _parentToggle;

    private void Start()
    {
        _parentToggle = GetComponent<Toggle>();
        _parentToggle.onValueChanged.AddListener(delegate { ToggleEdges(); });
    }

    public void ToggleEdges()
    {
        var x = (int) _parentToggle.GetComponent<TwoDCoord>().Coord.x;
        var y = (int) _parentToggle.GetComponent<TwoDCoord>().Coord.y;

        var boardH = GameObject.FindGameObjectWithTag("BoardH").GetComponent<MapHorizEdgesPanel>();
        var boardV = GameObject.FindGameObjectWithTag("BoardV").GetComponent<MapVertEdgesPanel>();

        try
        {
            boardH.MapHorizEdgesArray[x, y].isOn = _parentToggle.isOn;
        }
        catch (System.IndexOutOfRangeException)
        {
            /**/
        }
        try
        {
            boardH.MapHorizEdgesArray[x, y - 1].isOn = _parentToggle.isOn;
        }
        catch (System.IndexOutOfRangeException)
        {
            /**/
        }
        try
        {
            boardV.MapVertEdgesArray[x - 1, y].isOn = _parentToggle.isOn;
        }
        catch (System.IndexOutOfRangeException)
        {
            /**/
        }
        try
        {
            boardV.MapVertEdgesArray[x, y].isOn = _parentToggle.isOn;
        }
        catch (System.IndexOutOfRangeException)
        {
            /**/
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardColorPicker : MonoBehaviour
{
    public TwoDCoord ParentTwoDCoords;
    public Color[] ColorArray;
    private Button _parentButton;
    private int _colorArrayIndex;

    private void Start()
    {
        _colorArrayIndex = 0;
        _parentButton = transform.GetComponent<Button>();
        _parentButton.onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        _colorArrayIndex = (_colorArrayIndex + 1) % ColorArray.Length;
        _parentButton.GetComponent<Graphic>().color = ColorArray[_colorArrayIndex];

        if (ParentTwoDCoords.Coord == new Vector2(-1, -1)) return;
        var playerGrid = GameObject.FindGameObjectWithTag("Grid");
        playerGrid.GetComponent<PlayerSquaresPanel>()
            .PlayerSquaresArray[(int) ParentTwoDCoords.Coord.x, (int) ParentTwoDCoords.Coord.y]
            .GetComponent<Graphic>()
            .color = ColorArray[_colorArrayIndex];
    }
}
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardColorPicker : MonoBehaviour {
	
	private Button 		ParentButton;
	public TwoDCoord 	ParentTwoDCoords;
    public Color[]      ColorArray;
    private int         ColorArrayIndex = 0;

	void Start () {

        ParentButton = this.transform.GetComponent<Button>();
        ParentButton.onClick.AddListener (delegate {ButtonClicked(); });
	}
	
	public void ButtonClicked() {

        ColorArrayIndex = (ColorArrayIndex + 1) % ColorArray.Length;
        ParentButton.GetComponent<Graphic> ().color = ColorArray[ColorArrayIndex];

		if (ParentTwoDCoords.coord != new Vector2(-1,-1)) {
            GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
            playerGrid.GetComponent<PlayerSquaresPanel> ().PlayerSquaresArray [(int)ParentTwoDCoords.coord.x, (int)ParentTwoDCoords.coord.y].GetComponent<Graphic> ().color = ColorArray[ColorArrayIndex];
		}
	}
}

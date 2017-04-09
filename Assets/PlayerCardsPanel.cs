using UnityEngine;
using UnityEngine.UI;

public class PlayerCardsPanel : MonoBehaviour {

	public GameObject   MapSquaresPanel;
	public GameObject   MapVertEdgesPanel;
	public GameObject   MapHorizEdgesPanel;
	public GameObject   PlayerSquaresPanel;
	public GameObject   FreezeCardsPanel;
	public Toggle       EdgeSquareToggle;
	public Button       ClearMapButton;

	private bool _reset = true;

    public void ClearMap() {

		_reset = !_reset;

		foreach (Toggle square in MapSquaresPanel.GetComponentsInChildren<Toggle>())    { square.isOn   = _reset; }
		foreach (Toggle vEdge in MapVertEdgesPanel.GetComponentsInChildren<Toggle>())   { vEdge.isOn    = _reset; }
		foreach (Toggle hEdge in MapHorizEdgesPanel.GetComponentsInChildren<Toggle>())  { hEdge.isOn    = _reset; }
    }

    public void ToggleFreezeBoard(Toggle ToggleButton) {

        bool boardEnabled = ToggleButton.isOn;

		EdgeSquareToggle.interactable 							=  boardEnabled;
        ClearMapButton.interactable 							=  boardEnabled;
        PlayerSquaresPanel.GetComponent<Graphic>().raycastTarget 		= !boardEnabled;
        FreezeCardsPanel.GetComponent<Graphic>().raycastTarget 	=  boardEnabled;

		foreach (Button gridSquare in PlayerSquaresPanel.GetComponentsInChildren<Button>()) {
			gridSquare.GetComponent<Image> ().raycastTarget = !boardEnabled;
		}

		ToggleButton.GetComponentInChildren<Text>().text = (boardEnabled == true) ? "Edit Mode" : "Play Mode" ;

    }

    public void ToggleSquareCollisions(Toggle ToggleButton) {

		foreach (GameObject square in GameObject.FindGameObjectsWithTag("Square")) {
			square.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = !ToggleButton.isOn;
		}

		foreach (GameObject edge in GameObject.FindGameObjectsWithTag("Edge")) {
			edge.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = ToggleButton.isOn;
		}
    }
}

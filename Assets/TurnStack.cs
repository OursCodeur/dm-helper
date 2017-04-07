using UnityEngine;
using UnityEngine.UI;

public class TurnStack : MonoBehaviour {

	public GameObject Board;
	public GameObject BoardVertOverlay;
	public GameObject BoardHorizOverlay;
	public GameObject PlayerGrid;
	public GameObject FreezeStackPanel;
	public Toggle EdgeModeToggle;
	public Button ClearBoardButton;

	private bool _reset = true;

    public void ClearBoardMethod() {

		_reset = !_reset;

		foreach (Toggle square in Board.GetComponentsInChildren<Toggle>()) {
			square.isOn = _reset;
		}

		foreach (Toggle vEdge in BoardVertOverlay.GetComponentsInChildren<Toggle>()) {
			vEdge.isOn = _reset;
		}

		foreach (Toggle hEdge in BoardHorizOverlay.GetComponentsInChildren<Toggle>()) {
			hEdge.isOn = _reset;
		}
    }

    public void ToggleFreezeBoard(Toggle ToggleButton) {

        bool boardEnabled = ToggleButton.isOn;

		EdgeModeToggle.interactable 							=  boardEnabled;
		ClearBoardButton.interactable 							=  boardEnabled;
		PlayerGrid.GetComponent<Graphic>().raycastTarget 		= !boardEnabled;
		FreezeStackPanel.GetComponent<Graphic>().raycastTarget 	=  boardEnabled;

		foreach (Button gridSquare in PlayerGrid.GetComponentsInChildren<Button>()) {
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

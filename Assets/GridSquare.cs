using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour {

	public  PlayerGrid parentPlayerGrid;
	private	Button thisButton;
	public  Button thisPCNPCButton;

	void Start () {

		thisButton = GetComponent<Button> ();
		thisButton.onClick.AddListener (delegate {ButtonClicked(); });
	}

	public void ButtonClicked() {

		if (parentPlayerGrid.GetComponent<PlayerGrid> ().currentPCNPCButton != null) {

			foreach (Button button in parentPlayerGrid.GetComponentsInChildren<Button>()) {
				if (button.GetComponent<GridSquare> ().thisPCNPCButton == parentPlayerGrid.GetComponent<PlayerGrid> ().currentPCNPCButton) {
					button.GetComponent<GridSquare> ().thisPCNPCButton = null;
				}
			}

			thisPCNPCButton = parentPlayerGrid.GetComponent<PlayerGrid> ().currentPCNPCButton;
			parentPlayerGrid.GetComponent<PlayerGrid> ().currentPCNPCButton = null;
			thisPCNPCButton.GetComponent<TwoDCoord> ().coord = thisButton.GetComponent<TwoDCoord> ().coord;
			
			foreach (Button button in parentPlayerGrid.GetComponentsInChildren<Button>()) {
				if (button.GetComponent<GridSquare> ().thisPCNPCButton == null) {
					button.GetComponent<Graphic> ().raycastTarget = false;
					button.GetComponent<Graphic> ().color = Color.clear;
				}
			}
			thisButton.GetComponent<Graphic> ().color = thisPCNPCButton.GetComponent<GridButton> ().thisColorPicker.GetComponent<Graphic> ().color;
		}
	}
}

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
			thisPCNPCButton.GetComponent<TwoDCoord> ().x = thisButton.GetComponent<TwoDCoord> ().x;
			thisPCNPCButton.GetComponent<TwoDCoord> ().y = thisButton.GetComponent<TwoDCoord> ().y;
			
			foreach (Button button in parentPlayerGrid.GetComponentsInChildren<Button>()) {
				if (button.GetComponent<GridSquare> ().thisPCNPCButton == null) {
					button.GetComponent<Graphic> ().raycastTarget = false;
					button.GetComponent<Graphic> ().color = new Color (0, 0, 0, 0);
				}
			}
			thisButton.GetComponent<Graphic> ().color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f), 1);
		}
	}
}

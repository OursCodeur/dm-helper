using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour {

	private	Button thisButton;

	void Start () {

		thisButton = GetComponent<Button> ();
		thisButton.onClick.AddListener (delegate {ButtonClicked(); });
	}

	public void ButtonClicked() {

		int x = thisButton.GetComponent<TwoDCoord> ().x;
		int y = thisButton.GetComponent<TwoDCoord> ().y;

	}
}

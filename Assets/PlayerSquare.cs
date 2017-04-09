using UnityEngine;
using UnityEngine.UI;

public class PlayerSquare : MonoBehaviour {

	public  PlayerSquaresPanel  ParentPlayerSquaresPanel;
	private	Button              ParentButton;
	public  Button              CurrentPlayerCard;

	void Start () {

		ParentButton = GetComponent<Button> ();
		ParentButton.onClick.AddListener (delegate {ButtonClicked(); });
	}

	public void ButtonClicked() {

		if (ParentPlayerSquaresPanel.GetComponent<PlayerSquaresPanel> ().currentPlayerCard != null) {

			foreach (Button button in ParentPlayerSquaresPanel.GetComponentsInChildren<Button>()) {
				if (button.GetComponent<PlayerSquare> ().CurrentPlayerCard == ParentPlayerSquaresPanel.GetComponent<PlayerSquaresPanel> ().currentPlayerCard) {
					button.GetComponent<PlayerSquare> ().CurrentPlayerCard = null;
				}
			}

			CurrentPlayerCard = ParentPlayerSquaresPanel.GetComponent<PlayerSquaresPanel> ().currentPlayerCard;
            ParentPlayerSquaresPanel.GetComponent<PlayerSquaresPanel> ().currentPlayerCard = null;
			CurrentPlayerCard.GetComponent<TwoDCoord> ().coord = ParentButton.GetComponent<TwoDCoord> ().coord;
			
			foreach (Button button in ParentPlayerSquaresPanel.GetComponentsInChildren<Button>()) {
				if (button.GetComponent<PlayerSquare> ().CurrentPlayerCard == null) {
					button.GetComponent<Graphic> ().raycastTarget = false;
					button.GetComponent<Graphic> ().color = Color.clear;
				}
			}
			ParentButton.GetComponent<Graphic> ().color = CurrentPlayerCard.GetComponent<PlayerCard> ().CardColorPicker.GetComponent<Graphic> ().color;
		}
	}
}

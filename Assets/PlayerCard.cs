using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour {
	
	public InputField 	CardNameInputField;
	public Outline      CardOutline;
	public TwoDCoord 	CardPosition;
	public Button 		CardColorPicker;
    public GameObject   CardTurnIndicator;
    private Button      ParentButton;

    void Start () {

		ParentButton = this.transform.GetComponent<Button>();
		ParentButton.onClick.AddListener (delegate {ButtonClicked(); });
        ParentButton.GetComponent<TwoDCoord>().coord = new Vector2(-1, -1);
    }
	
	public void ButtonClicked() {

		if (CardNameInputField.gameObject.activeSelf == false) {
			CardNameInputField.gameObject.SetActive (true);
        } else {
			if (CardNameInputField.text == "") {

				CardNameInputField.gameObject.SetActive (false);
                CardOutline.effectColor = new Color(0, 0, 0, .5f);
                CardColorPicker.GetComponent<Graphic>().color = new Color(.33f, .33f, .33f, 1);
                foreach (InputField field in CardNameInputField.GetComponentsInChildren<InputField>()) {field.text = ""; }

                if (ParentButton.GetComponent<TwoDCoord>().coord != new Vector2(-1, -1)) {
                    GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
                    Button matchingButton = playerGrid.GetComponent<PlayerSquaresPanel>().PlayerSquaresArray[(int)ParentButton.GetComponent<TwoDCoord>().coord.x,
                                                                                               (int)ParentButton.GetComponent<TwoDCoord>().coord.y].GetComponent<Button>();
                    matchingButton.GetComponent<PlayerSquare>().CurrentPlayerCard = null;
                    playerGrid.GetComponent<PlayerSquaresPanel>().currentPlayerCard = null;
                    foreach (Button button in playerGrid.GetComponentsInChildren<Button>()) {
                        if (button.GetComponent<PlayerSquare>().CurrentPlayerCard == null) {
                            button.GetComponent<Graphic>().raycastTarget = false;
                            button.GetComponent<Graphic>().color = Color.clear;
                        }
                    }
                    ParentButton.GetComponent<TwoDCoord>().coord = new Vector2(-1, -1);
                }
            } else {

                bool allFieldsCompleted = true;
                foreach (InputField field in CardNameInputField.GetComponentsInChildren<InputField>()) { allFieldsCompleted &= (field.text != "") ? true : false; }

                if (allFieldsCompleted) {

                    GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
                    GameObject mapBoard = GameObject.FindGameObjectWithTag("Board");
                    foreach (Button button in playerGrid.GetComponentsInChildren<Button>()) {
						if (button.GetComponent<PlayerSquare> ().CurrentPlayerCard == null || button.GetComponent<PlayerSquare> ().CurrentPlayerCard == ParentButton ) {
                            int x = (int)button.GetComponent<TwoDCoord>().coord.x;
                            int y = (int)button.GetComponent<TwoDCoord>().coord.y;
                            if (mapBoard.GetComponent<MapSquaresPanel>().MapSquaresArray[x,y].GetComponent<Toggle>().isOn == false) {
                                button.GetComponent<Graphic>().raycastTarget = true;
                                button.GetComponent<Graphic>().color = new Color(.325f, .659f, .82f, .2f);
                            }
						}
                    }

					playerGrid.GetComponent<PlayerSquaresPanel>().currentPlayerCard = ParentButton;
                }
            }
		}
	}
}

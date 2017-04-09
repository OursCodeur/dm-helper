using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour {
	
	public InputField 	thisInputField;
	public Outline      thisOutline;
	public TwoDCoord 	position;
	public Button 		thisColorPicker;
    public GameObject   thisTurnIndicator;
    private Button      _parent;

    void Start () {

		_parent = this.transform.GetComponent<Button>();
		_parent.onClick.AddListener (delegate {ButtonClicked(); });
        _parent.GetComponent<TwoDCoord>().coord = new Vector2(-1, -1);
    }
	
	public void ButtonClicked() {

		if (thisInputField.gameObject.activeSelf == false) {
			thisInputField.gameObject.SetActive (true);
        } else {
			if (thisInputField.text == "") {

				thisInputField.gameObject.SetActive (false);
                thisOutline.effectColor = new Color(0, 0, 0, .5f);
                thisColorPicker.GetComponent<Graphic>().color = new Color(.33f, .33f, .33f, 1);
                foreach (InputField field in thisInputField.GetComponentsInChildren<InputField>()) {field.text = ""; }

                if (_parent.GetComponent<TwoDCoord>().coord != new Vector2(-1, -1)) {
                    GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
                    Button matchingButton = playerGrid.GetComponent<PlayerSquaresPanel>().PlayerSquaresArray[(int)_parent.GetComponent<TwoDCoord>().coord.x,
                                                                                               (int)_parent.GetComponent<TwoDCoord>().coord.y].GetComponent<Button>();
                    matchingButton.GetComponent<PlayerSquare>().CurrentPlayerCard = null;
                    playerGrid.GetComponent<PlayerSquaresPanel>().currentPlayerCard = null;
                    foreach (Button button in playerGrid.GetComponentsInChildren<Button>()) {
                        if (button.GetComponent<PlayerSquare>().CurrentPlayerCard == null) {
                            button.GetComponent<Graphic>().raycastTarget = false;
                            button.GetComponent<Graphic>().color = Color.clear;
                        }
                    }
                    _parent.GetComponent<TwoDCoord>().coord = new Vector2(-1, -1);
                }
            } else {

                bool allFieldsCompleted = true;
                foreach (InputField field in thisInputField.GetComponentsInChildren<InputField>()) { allFieldsCompleted &= (field.text != "") ? true : false; }

                if (allFieldsCompleted) {

                    GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
                    GameObject mapBoard = GameObject.FindGameObjectWithTag("Board");
                    foreach (Button button in playerGrid.GetComponentsInChildren<Button>()) {
						if (button.GetComponent<PlayerSquare> ().CurrentPlayerCard == null || button.GetComponent<PlayerSquare> ().CurrentPlayerCard == _parent ) {
                            int x = (int)button.GetComponent<TwoDCoord>().coord.x;
                            int y = (int)button.GetComponent<TwoDCoord>().coord.y;
                            if (mapBoard.GetComponent<MapSquaresPanel>().MapSquaresArray[x,y].GetComponent<Toggle>().isOn == false) {
                                button.GetComponent<Graphic>().raycastTarget = true;
                                button.GetComponent<Graphic>().color = new Color(.325f, .659f, .82f, .2f);
                            }
						}
                    }

					playerGrid.GetComponent<PlayerSquaresPanel>().currentPlayerCard = _parent;
                }
            }
		}
	}
}

using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour {
	
	public InputField 	thisInputField;
	public Outline      thisOutline;
	public TwoDCoord 	position;
	private Button 		_parent;
	public  Button 		thisColorPicker;
	
	void Start () {

		_parent = this.transform.GetComponent<Button>();
		_parent.onClick.AddListener (delegate {ButtonClicked(); });
	}
	
	public void ButtonClicked() {

		if (thisInputField.gameObject.activeSelf == false) {
			thisInputField.gameObject.SetActive (true);
        } else {
			if (thisInputField.text == "") {
				thisInputField.gameObject.SetActive (false);
                thisOutline.effectColor = new Color(0, 0, 0, .5f);
                foreach (InputField field in thisInputField.GetComponentsInChildren<InputField>()) {field.text = ""; }
            } else {

                bool allFieldsCompleted = true;
                foreach (InputField field in thisInputField.GetComponentsInChildren<InputField>()) { allFieldsCompleted &= (field.text != "") ? true : false; }

                if (allFieldsCompleted) {

                    GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
                    foreach (Button button in playerGrid.GetComponentsInChildren<Button>()) {
						if (button.GetComponent<GridSquare> ().thisPCNPCButton == null || button.GetComponent<GridSquare> ().thisPCNPCButton == _parent ) {
							button.GetComponent<Graphic> ().raycastTarget = true;
							button.GetComponent<Graphic> ().color = new Color (.325f, .659f, .82f, .2f);
						}
                    }

					playerGrid.GetComponent<PlayerGrid>().currentPCNPCButton = _parent;
                }
            }
		}
	}
}

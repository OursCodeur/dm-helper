using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour {
	
	public InputField 	thisInputField;
    public Toggle       thisTurnIndicator;
    public Outline      thisOutline;
    private Button 		_parent;
	
	void Start () {

		_parent = this.transform.GetComponent<Button>();
		_parent.onClick.AddListener (delegate {ButtonClicked(); });
	}
	
	public void ButtonClicked() {

		if (thisInputField.gameObject.activeSelf == false) {
			thisInputField.gameObject.SetActive (true);
            thisTurnIndicator.gameObject.SetActive(true);
        } else {
			if (thisInputField.text == "") {
				thisInputField.gameObject.SetActive (false);
                thisTurnIndicator.gameObject.SetActive(false);
            } else {

            }
		}
	}
}

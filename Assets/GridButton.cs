using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour {
	
	public InputField 	thisInputField;
	private Button 		_parent;
	public string 		_name;
	
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
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnGridClicked : MonoBehaviour {

	private	Button 	thisButton;
	private PCNPC 	thisPcNpc;

	void Start () {
		
		thisPcNpc 	= this.GetComponent<PCNPC> ();
		thisButton 	= this.GetComponent<Button> ();
		thisButton.onClick.AddListener (delegate {ButtonClicked(); });
	}

	public void ButtonClicked() {

		int x = thisButton.GetComponent<TwoDCoord> ().x;
		int y = thisButton.GetComponent<TwoDCoord> ().y;

		if (thisPcNpc._name == "") {

		} else {
			/**/
		}

	}
}

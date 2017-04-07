using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButtonColorPicker : MonoBehaviour {
	
	private Button 		_parent;

	void Start () {

		_parent = this.transform.GetComponent<Button>();
		_parent.onClick.AddListener (delegate {ButtonClicked(); });
		
	}
	
	public void ButtonClicked() {

		_parent.GetComponent<Graphic> ().color = new ColorHSV(Random.Range(0f, 255f), .8f, 1f).ToColor();
	}
}

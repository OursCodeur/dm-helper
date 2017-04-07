using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButtonColorPicker : MonoBehaviour {
	
	private Button 		_parent;
	public TwoDCoord 	_parentTwo2Coords;

	void Start () {

		_parent = this.transform.GetComponent<Button>();
		_parent.onClick.AddListener (delegate {ButtonClicked(); });
		
	}
	
	public void ButtonClicked() {

		GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
		float colorComponent = (Input.mousePosition.y - (_parent.GetComponent<RectTransform> ().position.y + _parent.GetComponent<RectTransform> ().rect.yMin)) / 270 * 255;
		_parent.GetComponent<Graphic> ().color = new ColorHSV(colorComponent, .8f, .8f).ToColor();
		if (_parentTwo2Coords.y != -1) {
			playerGrid.GetComponent<PlayerGrid> ().squaresArray [_parentTwo2Coords.x, _parentTwo2Coords.y].GetComponent<Graphic> ().color = new ColorHSV (colorComponent, .8f, .8f).ToColor ();
		}
	}
}

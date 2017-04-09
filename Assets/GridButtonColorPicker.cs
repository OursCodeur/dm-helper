using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButtonColorPicker : MonoBehaviour {
	
	private Button 		_parent;
	public TwoDCoord 	_parentTwo2Coords;
    public Color[]      _colorArray;
    private int         _colorArrayIndex = 0;

	void Start () {

		_parent = this.transform.GetComponent<Button>();
		_parent.onClick.AddListener (delegate {ButtonClicked(); });
	}
	
	public void ButtonClicked() {

        _colorArrayIndex = (_colorArrayIndex + 1) % _colorArray.Length;
		_parent.GetComponent<Graphic> ().color = _colorArray[_colorArrayIndex];

		if (_parentTwo2Coords.coord != new Vector2(-1,-1)) {
            GameObject playerGrid = GameObject.FindGameObjectWithTag("Grid");
            playerGrid.GetComponent<PlayerGrid> ().squaresArray [(int)_parentTwo2Coords.coord.x, (int)_parentTwo2Coords.coord.y].GetComponent<Graphic> ().color = _colorArray[_colorArrayIndex];
		}
	}
}

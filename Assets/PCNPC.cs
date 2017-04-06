using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCNPC : MonoBehaviour {

	private Button 	_parent;
	public string 	_name;
	
	void Start () {
		_parent = this.transform.GetComponent<Button>();
	}
}

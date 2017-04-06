using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridButtonInput : MonoBehaviour {

	public InputField parentField;

	void Start () {

		parentField.gameObject.SetActive (false);
	}
}

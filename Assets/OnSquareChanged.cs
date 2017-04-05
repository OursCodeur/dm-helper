using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSquareChanged : MonoBehaviour {

	private	Toggle thisToggle;

	// Use this for initialization
	void Start () {
		thisToggle = this.GetComponent<Toggle> ();
		thisToggle.onValueChanged.AddListener (delegate {ToggleEdges(); });

	}

	public void ToggleEdges() {

		GameObject board = GameObject.FindGameObjectWithTag("Board");
	}
}

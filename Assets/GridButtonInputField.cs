using UnityEngine;
using UnityEngine.UI;

public class GridButtonInputField : MonoBehaviour {

	public InputField parentField;

	void Start () {

		parentField.gameObject.SetActive (false);
	}
}

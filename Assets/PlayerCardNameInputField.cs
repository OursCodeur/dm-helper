using UnityEngine;
using UnityEngine.UI;

public class PlayerCardNameInputField : MonoBehaviour {

	public InputField ParentNameInputField;

	void Start () {

        ParentNameInputField.gameObject.SetActive (false);
	}
}

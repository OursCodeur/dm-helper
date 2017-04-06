using System;
using UnityEngine;
using UnityEngine.UI;

public class HPInputField : MonoBehaviour {

    public InputField   thisField;
    public Outline      parentButtonOutline;

    void Start () {

        thisField.onEndEdit.AddListener(delegate { HPUpdate(); });
    }
	
	private void HPUpdate() {

        if (thisField.text != "") {
            parentButtonOutline.effectColor = (Int32.Parse(thisField.text) <= 0) ? new Color(1, 0, 0, .5f) : new Color(0, 0, 0, .5f);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerCardHPInputField : MonoBehaviour {

    public InputField   ParentHPInputField;
    public Outline      ParentOutline;

    void Start () {

        ParentHPInputField.onEndEdit.AddListener(delegate { HPUpdate(); });
    }
	
	private void HPUpdate() {

        if (ParentHPInputField.text != "") {
            ParentOutline.effectColor = (int.Parse(ParentHPInputField.text) <= 0) ? new Color(1, 0, 0, .5f) : new Color(0, 0, 0, .5f);
        }
    }
}

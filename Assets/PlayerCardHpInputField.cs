using UnityEngine;
using UnityEngine.UI;

public class PlayerCardHpInputField : MonoBehaviour
{
    public InputField ParentHpInputField;
    public Outline ParentOutline;

    private void Start()
    {
        ParentHpInputField.onEndEdit.AddListener(delegate { HpUpdate(); });
    }

    private void HpUpdate()
    {
        if (ParentHpInputField.text == "") return;
        ParentOutline.effectColor = int.Parse(ParentHpInputField.text) <= 0
            ? new Color(1, 0, 0, .5f)
            : new Color(0, 0, 0, .5f);
    }
}
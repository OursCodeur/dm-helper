using UnityEngine;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour {

    public void ToggleFreezeBoard(GameObject fromButton) {

        bool boardFrozen = !fromButton.GetComponent<Toggle>().isOn;
        GetComponent<Graphic>().raycastTarget = boardFrozen;
    }
}

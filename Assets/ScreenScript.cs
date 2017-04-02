using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour {

    public void ToggleFreezeBoard(GameObject fromButton) {

        bool boardFrozen = !fromButton.GetComponent<Toggle>().isOn;
        this.GetComponent<Graphic>().raycastTarget = boardFrozen;
    }
}

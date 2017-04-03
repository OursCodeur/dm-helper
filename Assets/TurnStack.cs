using UnityEngine;
using UnityEngine.UI;

public class TurnStack : MonoBehaviour {

    public GameObject Board;
    public GameObject BoardFreezeOverlay;

    public void ClearBoardMethod() {

        Toggle[] squares = Board.GetComponentsInChildren<Toggle>();
        foreach (Toggle square in squares) { square.isOn = false; }
    }

    public void ToggleFreezeBoard(Toggle fromButton) {

        bool boardFrozen = !fromButton.isOn;
        BoardFreezeOverlay.GetComponent<Graphic>().raycastTarget = boardFrozen;
    }
}

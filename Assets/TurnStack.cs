using UnityEngine;
using UnityEngine.UI;

public class TurnStack : MonoBehaviour {

	public GameObject Board;
	public GameObject BoardVertOverlay;
	public GameObject BoardHorizOverlay;
    public GameObject BoardFreezeOverlay;

    public void ClearBoardMethod() {

        Toggle[] squares = Board.GetComponentsInChildren<Toggle>();
		foreach (Toggle square in squares) { square.isOn = false; }

		Toggle[] vEdges = BoardVertOverlay.GetComponentsInChildren<Toggle>();
		foreach (Toggle vEdge in vEdges) { vEdge.isOn = false; }

		Toggle[] hEdges = BoardHorizOverlay.GetComponentsInChildren<Toggle>();
		foreach (Toggle hEdge in hEdges) { hEdge.isOn = false; }
    }

    public void ToggleFreezeBoard(Toggle toggleButton) {

        bool boardFrozen = !toggleButton.isOn;
        BoardFreezeOverlay.GetComponent<Graphic>().raycastTarget = boardFrozen;
    }

    public void ToggleSquareCollisions(Toggle toggleButton) {

        bool collisionDisabled = !toggleButton.isOn;

        GameObject[] squares = GameObject.FindGameObjectsWithTag("Square");
        foreach (GameObject square in squares) { square.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = collisionDisabled; }

        GameObject[] edges = GameObject.FindGameObjectsWithTag("Edge");
        foreach (GameObject edge in edges) { edge.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = !collisionDisabled; }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class TurnStack : MonoBehaviour {

	public GameObject Board;
	public GameObject BoardVertOverlay;
	public GameObject BoardHorizOverlay;
    public GameObject BoardFreezeOverlay;

	private bool _reset = false;

    public void ClearBoardMethod() {

		_reset = !_reset;

        Toggle[] squares = Board.GetComponentsInChildren<Toggle>();
		foreach (Toggle square in squares) { square.isOn = _reset; }

		Toggle[] vEdges = BoardVertOverlay.GetComponentsInChildren<Toggle>();
		foreach (Toggle vEdge in vEdges) { vEdge.isOn = _reset; }

		Toggle[] hEdges = BoardHorizOverlay.GetComponentsInChildren<Toggle>();
		foreach (Toggle hEdge in hEdges) { hEdge.isOn = _reset; }
    }

    public void ToggleFreezeBoard(Toggle ToggleButton) {

        bool boardFrozen = !ToggleButton.isOn;
        BoardFreezeOverlay.GetComponent<Graphic>().raycastTarget = boardFrozen;
    }

    public void ToggleSquareCollisions(Toggle ToggleButton) {

        bool collisionDisabled = !ToggleButton.isOn;

        GameObject[] squares = GameObject.FindGameObjectsWithTag("Square");
        foreach (GameObject square in squares) { square.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = collisionDisabled; }

        GameObject[] edges = GameObject.FindGameObjectsWithTag("Edge");
        foreach (GameObject edge in edges) { edge.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = !collisionDisabled; }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerCardsPanel : MonoBehaviour
{
    public GameObject MapSquaresPanel;
    public GameObject MapVertEdgesPanel;
    public GameObject MapHorizEdgesPanel;
    public GameObject PlayerSquaresPanel;
    public GameObject FreezeCardsPanel;
    public Toggle EdgeSquareToggle;
    public Button ClearMapButton;

    private bool _reset = true;

    public void ClearMap()
    {
        _reset = !_reset;

        foreach (var square in MapSquaresPanel.GetComponentsInChildren<Toggle>())
        {
            square.isOn = _reset;
        }
        foreach (var vEdge in MapVertEdgesPanel.GetComponentsInChildren<Toggle>())
        {
            vEdge.isOn = _reset;
        }
        foreach (var hEdge in MapHorizEdgesPanel.GetComponentsInChildren<Toggle>())
        {
            hEdge.isOn = _reset;
        }
    }

    public void ToggleEditPlay(Toggle toggleButton)
    {
        var boardEnabled = toggleButton.isOn;

        EdgeSquareToggle.interactable = boardEnabled;
        ClearMapButton.interactable = boardEnabled;
        PlayerSquaresPanel.GetComponent<Graphic>().raycastTarget = !boardEnabled;
        FreezeCardsPanel.GetComponent<Graphic>().raycastTarget = boardEnabled;

        foreach (var gridSquare in PlayerSquaresPanel.GetComponentsInChildren<Button>())
        {
            gridSquare.GetComponent<Image>().raycastTarget = !boardEnabled;
        }

        toggleButton.GetComponentInChildren<Text>().text = boardEnabled ? "Edit Mode" : "Play Mode";
    }

    public void ToggleSquareEdge(Toggle toggleButton)
    {
        foreach (var square in GameObject.FindGameObjectsWithTag("Square"))
        {
            square.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = !toggleButton.isOn;
        }

        foreach (var edge in GameObject.FindGameObjectsWithTag("Edge"))
        {
            edge.GetComponent<Toggle>().GetComponent<CanvasGroup>().blocksRaycasts = toggleButton.isOn;
        }
    }
}
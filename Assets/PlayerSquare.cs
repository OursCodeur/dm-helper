using UnityEngine;
using UnityEngine.UI;

public class PlayerSquare : MonoBehaviour
{
    public PlayerSquaresPanel ParentPlayerSquaresPanel;
    private Button _parentButton;
    public Button CurrentPlayerCard;

    private void Start()
    {
        _parentButton = GetComponent<Button>();
        _parentButton.onClick.AddListener(ButtonClicked);
    }

    public void ButtonClicked()
    {
        if (ParentPlayerSquaresPanel.GetComponent<PlayerSquaresPanel>().CurrentPlayerCard == null) return;
        foreach (var button in ParentPlayerSquaresPanel.GetComponentsInChildren<Button>())
        {
            if (button.GetComponent<PlayerSquare>().CurrentPlayerCard == ParentPlayerSquaresPanel
                    .GetComponent<PlayerSquaresPanel>()
                    .CurrentPlayerCard)
            {
                button.GetComponent<PlayerSquare>().CurrentPlayerCard = null;
            }
        }

        CurrentPlayerCard = ParentPlayerSquaresPanel.GetComponent<PlayerSquaresPanel>().CurrentPlayerCard;
        ParentPlayerSquaresPanel.GetComponent<PlayerSquaresPanel>().CurrentPlayerCard = null;
        CurrentPlayerCard.GetComponent<TwoDCoord>().Coord = _parentButton.GetComponent<TwoDCoord>().Coord;

        foreach (var button in ParentPlayerSquaresPanel.GetComponentsInChildren<Button>())
        {
            if (button.GetComponent<PlayerSquare>().CurrentPlayerCard != null) continue;
            button.GetComponent<Graphic>().raycastTarget = false;
            button.GetComponent<Graphic>().color = Color.clear;
        }
        _parentButton.GetComponent<Graphic>().color = CurrentPlayerCard.GetComponent<PlayerCard>()
            .CardColorPicker.GetComponent<Graphic>()
            .color;
    }
}
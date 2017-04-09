using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour
{
    public InputField CardNameInputField;
    public Outline CardOutline;
    public TwoDCoord CardPosition;
    public Button CardColorPicker;
    public GameObject CardTurnIndicator;
    private Button _parentButton;

    private void Start()
    {
        _parentButton = transform.GetComponent<Button>();
        _parentButton.onClick.AddListener(ButtonClicked);
        _parentButton.GetComponent<TwoDCoord>().Coord = new Vector2(-1, -1);
    }

    public void ButtonClicked()
    {
        if (CardNameInputField.gameObject.activeSelf == false)
        {
            CardNameInputField.gameObject.SetActive(true);
        }
        else
        {
            if (CardNameInputField.text == "")
            {
                CardNameInputField.gameObject.SetActive(false);
                CardOutline.effectColor = new Color(0, 0, 0, .5f);
                CardColorPicker.GetComponent<Graphic>().color = new Color(.33f, .33f, .33f, 1);
                foreach (var field in CardNameInputField.GetComponentsInChildren<InputField>())
                {
                    field.text = "";
                }

                if (_parentButton.GetComponent<TwoDCoord>().Coord == new Vector2(-1, -1)) return;
                var playerGrid = GameObject.FindGameObjectWithTag("Grid");
                var matchingButton = playerGrid.GetComponent<PlayerSquaresPanel>()
                    .PlayerSquaresArray[(int) _parentButton.GetComponent<TwoDCoord>().Coord.x,
                        (int) _parentButton.GetComponent<TwoDCoord>().Coord.y]
                    .GetComponent<Button>();
                matchingButton.GetComponent<PlayerSquare>().CurrentPlayerCard = null;
                playerGrid.GetComponent<PlayerSquaresPanel>().CurrentPlayerCard = null;
                foreach (var button in playerGrid.GetComponentsInChildren<Button>())
                {
                    if (button.GetComponent<PlayerSquare>().CurrentPlayerCard != null) continue;
                    button.GetComponent<Graphic>().raycastTarget = false;
                    button.GetComponent<Graphic>().color = Color.clear;
                }
                _parentButton.GetComponent<TwoDCoord>().Coord = new Vector2(-1, -1);
            }
            else
            {
                var allFieldsCompleted = CardNameInputField.GetComponentsInChildren<InputField>()
                    .Aggregate(true, (current, field) => current & (field.text != ""));

                if (!allFieldsCompleted) return;
                var playerGrid = GameObject.FindGameObjectWithTag("Grid");
                var mapBoard = GameObject.FindGameObjectWithTag("Board");
                foreach (var button in playerGrid.GetComponentsInChildren<Button>())
                {
                    if (button.GetComponent<PlayerSquare>().CurrentPlayerCard != null &&
                        button.GetComponent<PlayerSquare>().CurrentPlayerCard != _parentButton) continue;
                    var x = (int) button.GetComponent<TwoDCoord>().Coord.x;
                    var y = (int) button.GetComponent<TwoDCoord>().Coord.y;
                    if (mapBoard.GetComponent<MapSquaresPanel>()
                        .MapSquaresArray[x, y]
                        .GetComponent<Toggle>()
                        .isOn) continue;
                    button.GetComponent<Graphic>().raycastTarget = true;
                    button.GetComponent<Graphic>().color = new Color(.325f, .659f, .82f, .2f);
                }

                playerGrid.GetComponent<PlayerSquaresPanel>().CurrentPlayerCard = _parentButton;
            }
        }
    }
}
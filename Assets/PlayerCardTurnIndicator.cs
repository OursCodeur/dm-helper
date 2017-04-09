using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCardTurnIndicator : MonoBehaviour
{
    public Toggle ParentToggle;
    private GameObject _parentPlayerCardGrid;

    private void Start()
    {
        _parentPlayerCardGrid = GameObject.FindGameObjectWithTag("TurnGrid");
        ParentToggle.onValueChanged.AddListener(delegate { ButtonClicked(); });
    }

    public void ButtonClicked()
    {
        var allSelected = _parentPlayerCardGrid.GetComponentsInChildren<PlayerCard>()
            .Where(gridButton => gridButton.CardNameInputField.gameObject.activeSelf)
            .Aggregate(true,
                (current, gridButton) => current & gridButton.CardTurnIndicator.GetComponent<Toggle>().isOn);
        if (!allSelected) return;
        foreach (var gridButton in _parentPlayerCardGrid.GetComponentsInChildren<PlayerCard>())
        {
            if (gridButton.CardNameInputField.gameObject.activeSelf)
            {
                gridButton.CardTurnIndicator.GetComponent<Toggle>().isOn = false;
            }
        }
    }
}
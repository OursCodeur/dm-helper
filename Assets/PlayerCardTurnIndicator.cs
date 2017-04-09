using UnityEngine;
using UnityEngine.UI;

public class PlayerCardTurnIndicator : MonoBehaviour {

    public  Toggle      ParentToggle;
    private GameObject  ParentPlayerCardGrid;

    void Start() {

        ParentPlayerCardGrid = GameObject.FindGameObjectWithTag("TurnGrid");
        ParentToggle.onValueChanged.AddListener(delegate { ButtonClicked(); });
    }

    public void ButtonClicked() {

        bool allSelected = true;
        foreach (PlayerCard gridButton in ParentPlayerCardGrid.GetComponentsInChildren<PlayerCard>()) {
            if (gridButton.CardNameInputField.gameObject.activeSelf == true) {
                allSelected &= (gridButton.CardTurnIndicator.GetComponent<Toggle>().isOn == true) ? true : false;
            }
        }
        if (allSelected) {
            foreach (PlayerCard gridButton in ParentPlayerCardGrid.GetComponentsInChildren<PlayerCard>()) {
                if (gridButton.CardNameInputField.gameObject.activeSelf == true) {
                    gridButton.CardTurnIndicator.GetComponent<Toggle>().isOn = false;
                }
            }
        }
    }
}

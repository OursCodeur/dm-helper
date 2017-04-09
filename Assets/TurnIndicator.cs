using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnIndicator : MonoBehaviour {

    public Toggle thisToggle;
    private GameObject thisTurnGrid;

    void Start() {

        thisTurnGrid = GameObject.FindGameObjectWithTag("Grid");
        thisToggle.onValueChanged.AddListener(delegate { ButtonClicked(); });
    }

    public void ButtonClicked() {

        bool allSelected = true;
        foreach (PlayerCard gridButton in thisTurnGrid.GetComponentsInChildren<PlayerCard>()) {
            if (gridButton.thisInputField.gameObject.activeSelf == true) {
                allSelected &= (gridButton.thisTurnIndicator.GetComponent<Toggle>().isOn == true) ? true : false;
            }
        }
        if (allSelected) {
            foreach (PlayerCard gridButton in thisTurnGrid.GetComponentsInChildren<PlayerCard>()) {
                if (gridButton.thisInputField.gameObject.activeSelf == true) {
                    gridButton.thisTurnIndicator.GetComponent<Toggle>().isOn = false;
                }
            }
        }
    }
}

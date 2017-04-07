using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnIndicator : MonoBehaviour {

    public Toggle thisToggle;
    private GameObject thisTurnGrid;

    void Start() {

        thisTurnGrid = GameObject.FindGameObjectWithTag("TurnGrid");
        thisToggle.onValueChanged.AddListener(delegate { ButtonClicked(); });
    }

    public void ButtonClicked() {

        bool allSelected = true;
        foreach (GridButton gridButton in thisTurnGrid.GetComponentsInChildren<GridButton>()) {
            if (gridButton.thisInputField.gameObject.activeSelf == true) {
                allSelected &= (gridButton.thisTurnIndicator.GetComponent<Toggle>().isOn == true) ? true : false;
            }
        }
        if (allSelected) {
            foreach (GridButton gridButton in thisTurnGrid.GetComponentsInChildren<GridButton>()) {
                if (gridButton.thisInputField.gameObject.activeSelf == true) {
                    gridButton.thisTurnIndicator.GetComponent<Toggle>().isOn = false;
                }
            }
        }
    }
}

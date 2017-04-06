using UnityEngine;
using UnityEngine.UI;

public class TurnIndicator : MonoBehaviour {

    public Toggle parentToggle;

    void Start() {

        parentToggle.gameObject.SetActive(false);
    }
}

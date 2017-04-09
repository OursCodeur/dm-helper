using UnityEngine;
using UnityEngine.UI;

public class PlayerCardNameInputField : MonoBehaviour
{
    public InputField ParentNameInputField;

    private void Start()
    {
        ParentNameInputField.gameObject.SetActive(false);
    }
}
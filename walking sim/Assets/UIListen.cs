using TMPro;
using UnityEngine;

public class UIListen : MonoBehaviour
{

    public TextMeshProUGUI statusText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void UpdateText()
    {

        statusText.text = "Button Pressed";
    }

    public void OnEnable()
    {
        buttonEvent.onButtonPressed += UpdateText;
    }

    public void OnDisable()
    {
        buttonEvent.onButtonPressed -= UpdateText;
    }
}

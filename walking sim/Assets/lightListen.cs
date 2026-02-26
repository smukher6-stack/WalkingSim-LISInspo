using UnityEngine;

public class lightListen : MonoBehaviour
{
    public Light sceneLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnEnable()
    {
        buttonEvent.onButtonPressed += ChangeLight;
    }

    public void OnDisable()
    {
        buttonEvent.onButtonPressed -= ChangeLight;
    }

    void ChangeLight()
    {
        sceneLight.color = Color.aliceBlue;
    }
}

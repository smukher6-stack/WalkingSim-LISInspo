using System;
using TMPro;
using UnityEngine;

public class buttonEvent : MonoBehaviour
{

    public static event Action onButtonPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void OnButtonPressed()
    {
        onButtonPressed?.Invoke();
    }

  // action = delegate
  // delegate= variable that stores functions
}

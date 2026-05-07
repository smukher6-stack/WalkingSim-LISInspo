using TMPro;
using UnityEngine;

public class UIListen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI storyProgress;

    gameManager manager;
   

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("game manager").GetComponent<gameManager>();
    }

   
}

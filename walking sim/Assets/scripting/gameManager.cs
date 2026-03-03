using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour

   
{
    public static gameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (context.performed) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("reload");


    }
}

using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Events;

public class cutsceneScript : MonoBehaviour
{
    public UnityEvent continuePlot;
    public GameObject ghostShenanigans;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("storybeat"))
        {
            cutsceneScript.Instantiate(ghostShenanigans);
            continuePlot.Invoke();
            Debug.Log("Proceed");
            Destroy(gameObject);
        }

    }
}

using UnityEngine;

public class storyLine : MonoBehaviour
{

    public puzzleSolver solver;

    bool storyValue = puzzleSolver.solvedIt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(solver.solvedIt())
        {
            Debug.Log("oh yeah baby time to move on");
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

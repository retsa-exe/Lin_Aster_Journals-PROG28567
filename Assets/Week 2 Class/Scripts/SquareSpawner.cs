using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mathFunctions.DrawSquare(transform.position, 1f, Color.white, 5f);
    }
}

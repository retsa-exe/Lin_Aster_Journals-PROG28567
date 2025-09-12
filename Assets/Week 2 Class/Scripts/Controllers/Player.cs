using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //bomb trail variables
    public float bombTrailSpacing;
    public int numberOfTrailBombs;

    void Update()
    {
        float speed = 0.5f;

        Vector2 targetPosition = enemyTransform.position;
        Vector2 startPosition = transform.position;
        Vector2 directionToMove = targetPosition - startPosition;

        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector2(0, 1));
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            transform.position = transform.position + (Vector3)directionToMove.normalized * speed;
        }

        //instantiate bomb trail when press T
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
        }
    }

    public void SpawnBombAtOffset (Vector2 inOffset)
    {
        Instantiate(bombPrefab, inOffset + (Vector2)transform.position, Quaternion.identity);
    }

    //instantiate a series of bomb behinde player
    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        for (int i = 0; i < inNumberOfBombs; i++)
        {
            //calculate the place of bomb
            Vector2 placeOfBomb = (Vector2)transform.position - new Vector2(0, inBombSpacing) * (i + 1);

            //place the bomb at the right position
            Instantiate(bombPrefab, placeOfBomb, Quaternion.identity);
        }
    }
}

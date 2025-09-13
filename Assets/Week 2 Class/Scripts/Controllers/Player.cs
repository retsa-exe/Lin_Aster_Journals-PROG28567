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

    //corner bomb variables
    public float bombCornerSpacing = 1;

    //wrap variables
    public float wrapRatio = 0.5f;
    
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

        //instantiate bomb at corner when press C
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner(bombCornerSpacing);
        }

        //start space wrap when press w
        if (Input.GetKeyDown(KeyCode.W))
        {
            WarpPlayer(enemyTransform, wrapRatio);
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

    public void SpawnBombOnRandomCorner(float inDistance)
    {
        //generate 4 numbers
        float num1 = Random.Range(-1, 1);
        float num2 = Random.Range(-1, 1);
        float num3 = Random.Range(-1, 1);
        float num4 = Random.Range(-1, 1);

        Vector2 playerPos = transform.position;

        //instantiate according to the numbers
        //top left bomb
        if (num1 < 0)
        {
            Instantiate(bombPrefab, new Vector2(playerPos.x - inDistance, playerPos.y + inDistance), Quaternion.identity);
        }
        //top right bomb
        if (num2 < 0)
        {
            Instantiate(bombPrefab, new Vector2(playerPos.x + inDistance, playerPos.y + inDistance), Quaternion.identity);
        }
        //buttom left bomb
        if (num3 < 0)
        {
            Instantiate(bombPrefab, new Vector2(playerPos.x - inDistance, playerPos.y - inDistance), Quaternion.identity);
        }
        //buttom right bomb
        if (num4 < 0)
        {
            Instantiate(bombPrefab, new Vector2(playerPos.x + inDistance, playerPos.y - inDistance), Quaternion.identity);
        }
    }

    public void WarpPlayer(Transform target, float ratio)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;


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
    }

    public void SpawnBombAtOffset (Vector2 inOffset)
    {
        Instantiate(bombPrefab, inOffset + (Vector2)transform.position, Quaternion.identity);
    }

}

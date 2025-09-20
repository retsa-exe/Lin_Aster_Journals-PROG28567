using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Vector2 direction;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        //set the initial target first
        direction = Random.insideUnitCircle;
        //calculate the target point
        target = transform.position + (Vector3)direction * maxFloatDistance;
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        //move the asteroid to the target
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

        //detect if the asteroid is close to the target
        if (Vector3.Distance(target, transform.position) < arrivalDistance)
        {
            //reset the target
            direction = Random.insideUnitCircle;
            target = transform.position + (Vector3)direction* maxFloatDistance;
        }
    }
}

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

    //player variables
    public float playerSpeed = 0;
    public float maxRange = 2.5f;

    //playermovement variables
    public Vector3 velocity;
    public float maxSpeed = 3f;
    public float accelerationTime = 2f;
    public float acceleration;
    public float decelerationTime = 2f;
    public float deceleration;

    //radar variabels 
    public int numberOfPints = 3;
    public float radius = 2f;
    public Transform enemy;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }
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

        PlayerMovement();

        //press r to open the radar
        if (Input.GetKey(KeyCode.R))
        {
            DetectAsteroids(maxRange, asteroidTransforms);
        }

        PlayerRadar();
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

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in inAsteroids)
        {
            //calculate the distance between player and asteroids
            Vector3 toAsteroid = asteroid.position - transform.position;

            //detect if is in the range
            if (toAsteroid.magnitude <= inMaxRange)
            {
                //normalized the direction
                Vector3 lineDirection = toAsteroid.normalized;
                Vector3 start = transform.position;
                Vector3 end = start + lineDirection * 2.5f;

                //draw the line
                Debug.DrawLine(start, end, Color.green);
            }
        }
    }

    public void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 moveDirection = new Vector3(horizontal, vertical, 0);
            velocity += moveDirection.normalized * acceleration * Time.deltaTime;
        }
        else
        {
            velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * deceleration);
        }

        transform.position += velocity * playerSpeed * Time.deltaTime;


        //Vector2 moveDirection = Vector2.zero;

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    moveDirection += Vector2.right;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    moveDirection += Vector2.left;
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    moveDirection += Vector2.up;
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    moveDirection += Vector2.down;
        //}

        //moveDirection = moveDirection.normalized;
        //velocity += (Vector3)moveDirection * acceleration * Time.deltaTime;

        //transform.position += velocity * playerSpeed * Time.deltaTime;


    }

    public void PlayerRadar()
    {
        float degree = 360 / numberOfPints;

        for (int i = 0; i < numberOfPints; i++)
        {
            float degreeOfA = i * degree;
            float degreeOfB = (i + 1) * degree;

            float radiansOfA = degreeOfA * Mathf.Deg2Rad;
            float radiansOfB = degreeOfB * Mathf.Deg2Rad;

            float xOfA = Mathf.Cos(radiansOfA);
            float yOfA = Mathf.Sin(radiansOfA);
            float xOfB = Mathf.Cos(radiansOfB);
            float yOfB = Mathf.Sin(radiansOfB);

            Vector3 ApointOnCircle = new Vector3(xOfA, yOfA, 0) * radius + transform.position;
            Vector3 BpointOnCircle = new Vector3(xOfB, yOfB, 0) * radius + transform.position;

            if (Vector3.Distance(transform.position, enemy.position) < radius)
            {
                Debug.DrawLine(ApointOnCircle, BpointOnCircle, Color.red);
            }
            else
            {
                Debug.DrawLine(ApointOnCircle, BpointOnCircle, Color.green);
            }
                
        }
    }
}

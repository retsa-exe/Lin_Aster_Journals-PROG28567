using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Vector3 direction;
    Vector2 screenPos;
    public float t;
    public AnimationCurve animationCurve;
    public float animationTime = 1f;
    public Vector3 pos;

    float previousY;

    private void Start()
    {
        direction = Vector3.zero;
        direction.x = Random.Range(2f, 5f);

        t = 0;
        //record the previous y
        previousY = transform.position.y;
    }

    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        pos = transform.position;

        //calculate the screen position
        screenPos = Camera.main.WorldToScreenPoint(pos);
        //make the enemy bounce in the screen
        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            direction.x *= -1;
        }
        
        //set the timer
        t += Time.deltaTime;

        //reset the timer when exceed
        if (t > animationTime)
        {
            t = 0;
        }

        //calculate y off set
        float yOffset = animationCurve.Evaluate(t);

        //move the enemy
        pos.x += direction.x * Time.deltaTime;
        pos.y = previousY + yOffset;
        transform.position = pos;
    }
}

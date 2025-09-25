using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;

    //orbiting variables
    public float moonRadius;
    public float moonSpeed;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        //set the moon to the start place
        transform.position = planetTransform.position + Vector3.right * moonRadius;
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(moonRadius, moonSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        //start timer
        t += Time.deltaTime;

        float vectorRadius = speed * t;

        float x = Mathf.Cos(vectorRadius);
        float y = Mathf.Sin(vectorRadius);

        Vector3 moonPosition = new Vector3(x, y, 0) * radius + target.position;

        transform.position = moonPosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    public float t;

    int i = 0;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();

    }

    public void DrawConstellation()
    {
        //start the timer
        t += Time.deltaTime;

        //calculate the ratio
        float ratio = t / drawingTime;

        //calculate the point
        Vector3 start = starTransforms[i].position;
        Vector3 end = Vector3.Lerp(starTransforms[i].position, starTransforms[i + 1].position, ratio);

        //draw the line
        Debug.DrawLine(start, end, Color.white);

        //restart the timer when reach the limit, also change the point
        if (t > drawingTime)
        {
            t = 0;

            //go to the next line
            i++;

            if (i > starTransforms.Count - 2)
            {
                i = 0;
            }
        }
    }
}

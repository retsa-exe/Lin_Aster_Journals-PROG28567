using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;


    // Update is called once per frame
    void Update()
    {
        //DrawConstellation();
    }

    public void DrawConstellation()
    {
        for (int i = 0; i < starTransforms.Count; i++)
        {
            DrawLine(starTransforms[i], starTransforms[i + 1]);
        }

    }

    public void DrawLine(Transform a, Transform b)
    {
        //Debug.DrawLine(a.position, b.position, Color.white);
    }
}

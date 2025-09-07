using UnityEngine;
using System.Collections.Generic;

public class Pipeline : MonoBehaviour
{
    //create a list for the points
    public List<Vector2> points;

    //add a timer
    public float t;

    //the total length of the lines
    public float length = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //create new list for the points
        points = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //start the timer
            t += Time.deltaTime;

            //take down the point every 0.1 sec
            if (t > 0.1)
            {
                //clear the timer
                t = 0;

                //store the mouse position when pressed down
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Debug.Log(mousePos);

                //add the point to the list
                points.Add(mousePos);

                //draw the lines if there is more than one points
                if (points.Count > 1)
                {
                    //get the privious point in the list
                    Vector2 previousPos = points[points.Count - 2];

                    //draw the line
                    Debug.DrawLine(mousePos, previousPos, Color.white, 5f);
                }
            }

            
        }

        //when release the mouse
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < (points.Count - 1); i++)
            {
                //calculate the distance between
                Vector2 a = points[i];
                Vector2 b = points[i + 1];

                float distance = Mathf.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));

                //add up the length
                length += distance;
            }

            //print out the final length
            Debug.Log(length);

            //clear the list and length
            points.Clear();
            length = 0;
        }
    }
}

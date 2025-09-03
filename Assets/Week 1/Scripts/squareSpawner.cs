using UnityEngine;

public class squareSpawner : MonoBehaviour
{
    public float size = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //change the size based on scroll
        size += Input.mouseScrollDelta.y;

        if (Input.GetMouseButtonDown(0))
        {
            //get the mouse position
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mouse);

            //draw a square at mouse position
            Debug.DrawLine(new Vector2(mouse.x - size, mouse.y + size), new Vector2(mouse.x + size, mouse.y + size), Color.red, 5f);
            Debug.DrawLine(new Vector2(mouse.x + size, mouse.y + size), new Vector2(mouse.x + size, mouse.y - size), Color.red, 5f);
            Debug.DrawLine(new Vector2(mouse.x + size, mouse.y - size), new Vector2(mouse.x - size, mouse.y - size), Color.red, 5f);
            Debug.DrawLine(new Vector2(mouse.x - size, mouse.y - size), new Vector2(mouse.x - size, mouse.y + size), Color.red, 5f);
        }

        //get mouse pos
        Vector2 m = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //draw a semi-transparent square at the position of the mouse at all times
        Debug.DrawLine(new Vector2(m.x - size, m.y + size), new Vector2(m.x + size, m.y + size), new Color(1f, 1f, 1f, 0.5f));
        Debug.DrawLine(new Vector2(m.x + size, m.y + size), new Vector2(m.x + size, m.y - size), new Color(1f, 1f, 1f, 0.5f));
        Debug.DrawLine(new Vector2(m.x + size, m.y - size), new Vector2(m.x - size, m.y - size), new Color(1f, 1f, 1f, 0.5f));
        Debug.DrawLine(new Vector2(m.x - size, m.y - size), new Vector2(m.x - size, m.y + size), new Color(1f, 1f, 1f, 0.5f));
    }

}

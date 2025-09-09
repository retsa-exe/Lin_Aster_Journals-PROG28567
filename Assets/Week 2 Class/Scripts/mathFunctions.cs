using UnityEngine;
using UnityEngine.UIElements;

public class mathFunctions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 position = transform.position; 

        float magnitude = GetMagnitude(position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float GetMagnitude(Vector2 position)
    {
        return Mathf.Sqrt(position.x * position.x + position.y * position.y);
    }

    public static void DrawSquare (Vector2 position, float size, Color color, float duration)
    {
        Vector2 topLeftPoint = new Vector2(position.x + size / 2f, position.y - size / 2f);
        Vector2 topRightPoint = new Vector2(position.x + size / 2f, position.y + size / 2f);
        Vector2 buttomRightPoint = new Vector2(position.x - size / 2f, position.y + size / 2f);
        Vector2 buttomLeftPoint = new Vector2(position.x - size / 2f, position.y - size / 2f);

        Debug.DrawLine(topLeftPoint, topRightPoint, color, duration);
        Debug.DrawLine(topRightPoint, buttomRightPoint, color, duration);
        Debug.DrawLine(buttomRightPoint, buttomLeftPoint, color, duration);
        Debug.DrawLine(buttomLeftPoint, topLeftPoint, color, duration);
    }
}

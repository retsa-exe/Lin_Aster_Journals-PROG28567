using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class rowGeneration : MonoBehaviour
{
    public TMP_InputField squareNumberInput;
    public Button generateButton;
    int num;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void drawSquare(Vector2 pos)
    {
        Debug.DrawLine(new Vector2(pos.x - 0.5f, pos.y + 0.5f), new Vector2(pos.x + 0.5f, pos.y + 0.5f), Color.white, 10f);
        Debug.DrawLine(new Vector2(pos.x + 0.5f, pos.y + 0.5f), new Vector2(pos.x + 0.5f, pos.y - 0.5f), Color.white, 10f);
        Debug.DrawLine(new Vector2(pos.x + 0.5f, pos.y - 0.5f), new Vector2(pos.x - 0.5f, pos.y - 0.5f), Color.white, 10f);
        Debug.DrawLine(new Vector2(pos.x - 0.5f, pos.y - 0.5f), new Vector2(pos.x - 0.5f, pos.y + 0.5f), Color.white, 10f);
    }

    public void takeDownNumber()
    {
        //get the number when the button is pressed
        string textMessage = squareNumberInput.text;
        Debug.Log(textMessage);

        //transfer it into int
        if (int.TryParse(textMessage, out num))
        {
            if (num > 0)
            {
                Debug.Log("Success");

                //draw the sqaures
                for (int i = 0; i < num; i++)
                {
                    drawSquare(new Vector2(i * 2, 0));
                }
            }
            else
            {
                Debug.Log("Invalid integer, please try again.");
            }
        }
        else
        {
            Debug.Log("Invalid integer, please try again.");
        }
    }
}

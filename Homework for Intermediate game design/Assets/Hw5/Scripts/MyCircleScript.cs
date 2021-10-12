using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCircleScript : MonoBehaviour
{
    private SpriteRenderer SprRend;
    public Color colorOne = Color.red;
    public Color colorTwo = Color.green;


    private void Awake()
    {
        SprRend = GetComponent<SpriteRenderer>();
    }

    public void SelectButton(int n)
    {
        if (n == 0)
        {
            SprRend.color = colorOne;
        }
        else if (n == 1)
        {
            SprRend.color = colorTwo;
        }
    }
}

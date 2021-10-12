using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyCameraRaycast : MonoBehaviour
{
    Camera mainCamera;
    public TMP_Text myText;
    int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }


    void ClickCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));
            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<MyCircleScript>().SelectButton(0);
            }
            points += 1;
            myText.text = $"points = {points}";
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));
            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<MyCircleScript>().SelectButton(1);
            }
            points -= 1;
            myText.text = $"points = {points}";
        }
    }

    private void Update()
    {
        ClickCheck();
    }
}

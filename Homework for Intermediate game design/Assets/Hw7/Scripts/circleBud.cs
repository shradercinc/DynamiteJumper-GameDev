using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleBud : MonoBehaviour
{
    public float speed = 1.0f;
    Vector2 nextLocation = new Vector2();
    GridSystem gridsystem;
    SpriteRenderer ren;
    float pauseTime = 1.0f;

    bool isActive;

    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        gridsystem = GameObject.FindGameObjectWithTag("GridSystem").GetComponent<GridSystem>();
        isActive = true;
        StartCoroutine(MoveToLocation());
    }

    IEnumerator MoveToLocation()
    {
        while (isActive)
        {
            float t = 0.0f;
            nextLocation = gridsystem.GetRandomLocation();
            Vector2 startlocation = transform.position;
            ren.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            while (t < 1.0f)
            {
                t += Time.deltaTime * speed;
                transform.position = Vector2.Lerp(startlocation, nextLocation, t);
                yield return null;
            }
            yield return new WaitForSeconds(pauseTime);
        }
    }
}

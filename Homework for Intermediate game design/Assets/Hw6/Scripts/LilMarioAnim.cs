using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilMarioAnim : MonoBehaviour
{
    SpriteRenderer ren;
    public List<Sprite> spriteList = new List<Sprite>();
    public float delay = 1.0f;

    public AnimationCurve curve;

    private void Awake()
    {
        ren = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(evalCurve());
    }
    IEnumerator Animate()
    {
        int counter = 0;
        StartCoroutine(Move());
        while (true)
        {
            ren.sprite = spriteList[counter];
            yield return new WaitForSeconds(delay);
            counter++;
            if (counter > spriteList.Count - 1)
            {
                counter = 0;
            }
        }
    }

    IEnumerator evalCurve()
    {
        float t = 0.0f;
        while (t < 2.0f)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(curve.Evaluate(t), 0.0f, 0.0f);
            yield return null;
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.y);
            yield return null;

            if (transform.position.x < -10)
            {
                transform.position = new Vector3(10.0f, transform.position.y, transform.position.y);
            }
        }
    }
}

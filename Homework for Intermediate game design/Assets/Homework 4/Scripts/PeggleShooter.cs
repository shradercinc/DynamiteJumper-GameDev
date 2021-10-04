using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeggleShooter : MonoBehaviour
{
    public Rigidbody2D ball;
    Vector3 ballStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        ballStartPosition = ball.transform.localPosition;
    }

    public void ResetBall()
    {
        ball.velocity = Vector2.zero;
        ball.angularVelocity = 0;
        ball.simulated = false;

        ball.transform.SetParent(transform, true);
        ball.transform.localPosition = ballStartPosition;
        ball.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

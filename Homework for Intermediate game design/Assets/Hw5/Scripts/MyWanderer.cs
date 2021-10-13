using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWanderer : MonoBehaviour
{
    public enum Direction { none, Right, Left, Up, Down}
    public Direction currentDir = Direction.none;
    public float speed;
    public Vector3 RayCastOffSet = Vector3.zero;
    public float RayCastDistance = 1.0f;


    void MoveObject()
    {
        RaycastHit2D rayCheck = Physics2D.Raycast(transform.position + RayCastOffSet, GetDirectionVector(currentDir), RayCastDistance);

        if (rayCheck.collider != null)
        {
            ChooseDirection();        
        }else 
        {
            transform.Translate(GetDirectionVector(currentDir) * (speed * Time.deltaTime));
        }
    }

    void ChooseDirection()
    {
        switch (currentDir) 
        {
            case Direction.Right:
            case Direction.Left:
                if (IsSomethingThere(Direction.Up))
                    currentDir = Direction.Down;
                else
                    currentDir = Direction.Up;
                break;


            case Direction.Up:
            case Direction.Down:
                if (IsSomethingThere(Direction.Left))
                    currentDir = Direction.Right;
                else
                    currentDir = Direction.Left;
                break;
                

        }
    }

    Vector2 GetDirectionVector(Direction dir)
    {
        Vector2 vc = new Vector2();

        switch (dir)
        {
            case Direction.Right:
                vc = Vector2.right;
                break;
            case Direction.Left:
                vc = Vector2.left;
                break;
            case Direction.Up:
                vc = Vector2.up;
                break;
            case Direction.Down:
                vc = Vector2.down;
                break;
        }
        return vc;
    }

    bool IsSomethingThere(Direction dir)
    {
        bool b = false;
        RaycastHit2D ray = new RaycastHit2D();

        switch (dir)
        {
            case Direction.Right:
                ray = Physics2D.Raycast(transform.position, Vector2.right, RayCastDistance + 2);
                Debug.DrawRay(transform.position, Vector2.right, Color.red);
                break;

            case Direction.Down:
                ray = Physics2D.Raycast(transform.position, Vector2.down, RayCastDistance + 2);
                Debug.DrawRay(transform.position, Vector2.down, Color.red);
                break;

            case Direction.Up:
                ray = Physics2D.Raycast(transform.position, Vector2.up, RayCastDistance + 2);
                Debug.DrawRay(transform.position, Vector2.up, Color.red);
                break;

            case Direction.Left:
                ray = Physics2D.Raycast(transform.position, Vector2.left, RayCastDistance + 2);
                Debug.DrawRay(transform.position, Vector2.left, Color.red);
                break;
        }
        if (ray.collider != null)
        {
            Debug.Log($"Something is to the {dir}. {ray.collider.name} | {ray.collider.gameObject} so B is {b}");
            b = true;
        }

        return b;
    }

    private void Update()
    {
        MoveObject();
    }


}

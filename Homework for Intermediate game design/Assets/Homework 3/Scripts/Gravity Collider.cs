using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCollider : MonoBehaviour
{

    public BoxCollider2D bc;
    public Rigidbody2D grav;

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        grav = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

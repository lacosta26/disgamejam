using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    private Vector3 lastMousePos = new Vector3(1000, 1000, 1000);
    public float speed = 5;
    private Rigidbody2D myRigid;
    public Vector3 directionn;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        directionn = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePos.z = 0;
            if (Vector3.Distance(lastMousePos, transform.position) > speed / 50)
            {
                //lastMousePos = lastMousePos - transform.position;
                directionn = lastMousePos - transform.position;
                directionn = directionn.normalized;
                myRigid.velocity = directionn * speed;
            }

        }
        if (Vector3.Distance(lastMousePos, transform.position) <= speed / 50)
        {
            transform.position = lastMousePos;
            myRigid.velocity = Vector3.zero;
        }
    }
}


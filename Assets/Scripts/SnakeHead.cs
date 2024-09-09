using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public GameObject snakeTail;
    private GameObject obj;

    private Vector3 lastMousePos = new Vector3(1000, 1000, 1000);
    public float speed = 5;
    private Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        obj = Instantiate(snakeTail, transform.position + Vector3.up, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePos.z = 0;
            if (Vector3.Distance(lastMousePos, transform.position) > speed / 50)
            {
                //lastMousePos = lastMousePos - transform.position;
                Vector3 directionn = lastMousePos - transform.position;
                directionn = directionn.normalized;
                myRigid.velocity = directionn * speed;
            }

        }
        if (Vector3.Distance(lastMousePos, transform.position) <= speed / 50)
        {
            transform.position = lastMousePos;
            myRigid.velocity = Vector3.zero;
        }

        obj.transform.position = transform.position + Vector3.up;
    }
}


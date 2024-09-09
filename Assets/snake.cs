using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{

    private Vector3 lastMousePos = new Vector3(1000, 1000, 1000);
    public float speed = 5;
    private Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            lastMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastMousePos.z = 0;
            lastMousePos = lastMousePos - transform.position;
            lastMousePos = lastMousePos.normalized;
            myRigid.velocity = lastMousePos * speed;

        } else if (Vector3.Distance(lastMousePos, transform.position) < speed / 10)
        {
            transform.position = lastMousePos;
            myRigid.velocity = Vector3.zero;
        } 
        else
        {
            Debug.Log(transform.position);
            Debug.Log(Vector3.Distance(lastMousePos, transform.position));
        }
    }
}

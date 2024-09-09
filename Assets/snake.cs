using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{

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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos = mousePos - transform.position;
        mousePos = mousePos.normalized;
        myRigid.velocity = mousePos * speed;
    }
}

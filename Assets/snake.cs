using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    public GameObject snakeTailPiece;

    private Vector3 lastMousePos = new Vector3(1000, 1000, 1000);
    public float speed = 5;
    private Rigidbody2D myRigid;
    // Start is called before the first frame update
    TrailRenderer trailRenderer;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        Instantiate(snakeTailPiece, transform.position + Vector3.up, Quaternion.identity);
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.material.renderQueue = 3000;
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

        snakeTailPiece.transform.position = lastMousePos + Vector3.up + Vector3.forward;
        //Debug.Log("set tail position to " + (lastMousePos + Vector3.up));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    public GameObject snakeTailPiece;

    public float speed = 5;
    private Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        Instantiate(snakeTailPiece, transform.position + Vector3.up, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos = mousePos - transform.position;
        mousePos = mousePos.normalized;
        myRigid.velocity = mousePos * speed;

        snakeTailPiece.transform.position = mousePos + Vector3.up + Vector3.forward;
        Debug.Log("set tail position to " + (mousePos + Vector3.up));
    }
}

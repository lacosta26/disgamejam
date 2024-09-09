using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using UnityEngine;

public class snake : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    public GameObject snakeTailPiece;
    private SpriteRenderer myRenderer;
>>>>>>> Stashed changes

    private Vector3 lastMousePos = new Vector3(1000, 1000, 1000);
    public float speed = 5;
    private Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myRigid = GetComponent<Rigidbody2D>();
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
<<<<<<< Updated upstream
=======

        snakeTailPiece.transform.position = lastMousePos + Vector3.up + Vector3.forward;
        //Debug.Log("set tail position to " + (lastMousePos + Vector3.up));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myRenderer.sortingOrder = 0;
        Vector3 newPos = new Vector3(-6.611f, 3.447f, 0);
        myRigid.velocity = Vector3.zero;
        transform.position = newPos;
        StartCoroutine(reappear());
    }

    IEnumerator reappear()
    {
        yield return new WaitForSeconds(3);
        myRenderer.sortingOrder = 2;
>>>>>>> Stashed changes
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeHead;
    public GameObject snakeTailPiece;
    public GameObject snakeTailEnd;
    private List<GameObject> pieces;
    private Rigidbody2D myRigid;

    private float threshold = 0.5f;
    private int nPieces = 10;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        //Debug.Log("snake init");
        snakeHead = Instantiate(snakeHead, transform.position, Quaternion.identity);

        pieces = new List<GameObject>();
        pieces.Add(snakeHead);
        for (int i = 0; i < nPieces; i++)
        {
            GameObject piece = Instantiate(snakeTailPiece, transform.position + (Vector3.up * (i + 1)), Quaternion.identity);
            pieces.Add(piece);
        }
        GameObject end = Instantiate(snakeTailEnd, transform.position + (Vector3.up * (nPieces + 1)), Quaternion.identity);
        pieces.Add(end);
    }

    // Update is called once per frame
    void Update()
    {
        // move each previous section to next assigned target



        // each point should know what forward node is, and frontmost node

        // if distance to forward node is more than threshold, lerp to that. otherwise, lerp to target

        // static field for path, list of vectors
        // distance btwn each element determines when to move


        // FixedJoint possibly
        for (int i = 1; i < pieces.Count; i++)
        {
            //pieces[i].transform.position = transform.position + (Vector3.up * i);

            // IF
            // go toward node in front's [i - 1] current position
            float interPieceDistance = (pieces[i].transform.position - pieces[i - 1].transform.position).magnitude;

            //pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[i - 1].transform.position, Time.deltaTime * 2.0f);
            if (interPieceDistance > threshold)
            {
                pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[i - 1].transform.position, Time.deltaTime * 5.0f);
            }
            //else
            //{
            //    pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[0].transform.position, Time.deltaTime * 2.0f);
            //}

            pieces[i].transform.rotation = Quaternion.Euler(0, 0, -45);
            //        pieces[i].transform.eulerAngles = new Vector3(pieces[i].transform.eulerAngles.x,
            //pieces[i].transform.eulerAngles.y,
            //pieces[i].transform.eulerAngles.z + 0.1f);
        }
        Vector3 headFacingVector = pieces[0].GetComponent<SnakeHead>().directionn;
        float angle = Mathf.Atan2(headFacingVector.y, headFacingVector.x) + (Mathf.PI * 0.5f);
        pieces[0].transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        //foreach (var piece in pieces)
        //{
        //    piece.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        //}

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.gameObject.tag);
    //    if (collision.gameObject.CompareTag("hole"))
    //    {
    //        tpLol();
    //    }
    //}

    IEnumerator reappear(SpriteRenderer myRendererrrrr)
    {
        yield return new WaitForSeconds(3);
        myRendererrrrr.sortingOrder = 3;
    }

    public void tpLol()
    {
        Vector3 newPos = new Vector3(-6.610781f, 3.447038f, 0);
        myRigid.velocity = Vector3.zero;
        foreach (GameObject piece in pieces)
        {
            SpriteRenderer myRenderrerr = piece.GetComponent<SpriteRenderer>();
            myRenderrerr.sortingOrder = 0;
            piece.transform.position = newPos;
            StartCoroutine(reappear(myRenderrerr));
        }
    }
}

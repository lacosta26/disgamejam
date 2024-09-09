using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeHead;
    public GameObject snakeTailPiece;
    public GameObject snakeTailEnd;
    public GameObject shirt;
    private List<GameObject> pieces;

    public float threshold = 0.1f;
    public int nPieces = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("snake init");
        snakeHead = Instantiate(snakeHead, transform.position, Quaternion.identity);
        shirt = Instantiate(shirt, transform.position + Vector3.up, Quaternion.identity);


        pieces = new List<GameObject>();
        pieces.Add(snakeHead);
        //shirt should be fixed distance from head, but not same rotation if that's easy
        for (int i = 0; i < nPieces; i++)
        {
            GameObject piece = Instantiate(snakeTailPiece, transform.position + (Vector3.up * i), Quaternion.identity);
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


        // set head facing direction and shirt
        Vector3 headFacingVector = pieces[0].GetComponent<SnakeHead>().directionn;
        float headFacingAngle = Mathf.Atan2(headFacingVector.y, headFacingVector.x) + (Mathf.PI * 0.5f);
        pieces[0].transform.rotation = Quaternion.AngleAxis(headFacingAngle * Mathf.Rad2Deg, Vector3.forward);

        for (int i = 1; i < pieces.Count; i++)
        {
            //pieces[i].transform.position = transform.position + (Vector3.up * i);

            // IF
            // go toward node in front's [i - 1] current position
            Vector3 betweenPieces = pieces[i].transform.position - pieces[i - 1].transform.position;
            float interPieceDistance = betweenPieces.magnitude;

            //pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[i - 1].transform.position, Time.deltaTime * 2.0f);
            if (interPieceDistance > threshold)
            {
                pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[i - 1].transform.position, Time.deltaTime * 5.0f);

                // pieces should be facing the piece in front of them


                float pieceFacingAngle = Mathf.Atan2(betweenPieces.y, betweenPieces.x) + (Mathf.PI * 0.5f);
                pieces[i].transform.rotation = Quaternion.AngleAxis(pieceFacingAngle * Mathf.Rad2Deg, Vector3.forward);

                // unless piece is not moving, then should face direction of head
            }
            //else
            //{
            //    pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[0].transform.position, Time.deltaTime * 2.0f);
            //}

            //pieces[i].transform.rotation = Quaternion.Euler(0, 0, -45);
            //        pieces[i].transform.eulerAngles = new Vector3(pieces[i].transform.eulerAngles.x,
            //pieces[i].transform.eulerAngles.y,
            //pieces[i].transform.eulerAngles.z + 0.1f);
        }

        //update shirt



        //foreach (var piece in pieces)
        //{
        //    piece.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        //}

    }

    private void GoBack()
    {
        foreach (var piece in pieces)
        {
            piece.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }
}

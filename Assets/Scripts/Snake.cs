using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeHead;
    public GameObject snakeTailPiece;
    public GameObject snakeTailEnd;
    public GameObject shirt;
    public GameObject threadPiece;

    private List<GameObject> pieces;

    public float threshold = 0.2f;
    public int nPieces = 10;
    public float moveTime = 5.0f;
    public int shirtPiece = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("snake init");
        snakeHead = Instantiate(snakeHead, transform.position, Quaternion.identity);

        // snake head initial rotation
        Quaternion headRotationInit = Quaternion.AngleAxis(180, Vector3.forward);
        snakeHead.transform.rotation = headRotationInit;


        pieces = new List<GameObject>();
        pieces.Add(snakeHead);

        for (int pieceI = 0; pieceI < shirtPiece; pieceI++)
        {
            GameObject piece = Instantiate(snakeTailPiece, transform.position + (Vector3.down * pieceI), Quaternion.identity);
            pieces.Add(piece);
            Debug.Log(transform.position + (Vector3.down * pieceI));
        }
        shirt = Instantiate(shirt, transform.position + (Vector3.down * shirtPiece), Quaternion.identity);
        pieces.Add(shirt);
        for (int pieceI = shirtPiece + 1; pieceI < nPieces; pieceI++)
        {
            GameObject piece = Instantiate(snakeTailPiece, transform.position + (Vector3.down * pieceI), Quaternion.identity);
            pieces.Add(piece);
        }

        GameObject end = Instantiate(snakeTailEnd, transform.position + (Vector3.up * (nPieces + 1)), Quaternion.identity);
        pieces.Add(end);

    }

    private void FixedUpdate()
    {
        // move each previous section to next assigned target



        // each point should know what forward node is, and frontmost node

        // if distance to forward node is more than threshold, lerp to that. otherwise, lerp to target

        // static field for path, list of vectors
        // distance btwn each element determines when to move


        // set head facing direction and shirt
        Vector3 headFacingVector = pieces[0].GetComponent<SnakeHead>().directionn;
        float headFacingAngle = Mathf.Atan2(headFacingVector.y, headFacingVector.x) + (Mathf.PI * 0.5f);
        Quaternion headRotation = Quaternion.AngleAxis(headFacingAngle * Mathf.Rad2Deg, Vector3.forward);
        pieces[0].transform.rotation = headRotation;


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
                pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[i - 1].transform.position, Time.deltaTime * moveTime);

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

        // 4th segment is good place to draw line from- some smoothing but not too far from regular position
        Instantiate(threadPiece, pieces[4].transform.position, Quaternion.identity);


        // spawn thread from last piece
        //Instantiate(threadPiece, pieces[nPieces + 1].transform.position, Quaternion.identity);

        //shirt.transform.position = pieces[0].transform.position - (headFacingVector.normalized * shirtDistance);
        // shirt sprite is 180 degrees upside down
        //Quaternion shirtRotation = Quaternion.AngleAxis((headFacingAngle + Mathf.PI) * Mathf.Rad2Deg, Vector3.forward);
        //shirt.transform.rotation = shirtRotation;

        //foreach (var piece in pieces)
        //{
        //    piece.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);

        //}

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeTailPiece;
    public GameObject snakeHead;
    private GameObject obj;
    private List<GameObject> pieces;

    private int threshold = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("snake tail init");
        pieces = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject piece = Instantiate(snakeTailPiece, transform.position + (Vector3.up * i), Quaternion.identity);
            pieces.Add(piece);
        }
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

            //pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[i - 1].transform.position, Time.deltaTime * 2.0f);
            pieces[i].transform.position = Vector3.Lerp(pieces[i].transform.position, pieces[i - 1].transform.position, Time.deltaTime * 2.0f);



            pieces[i].transform.rotation = Quaternion.Euler(0, 0, -45);
            //        pieces[i].transform.eulerAngles = new Vector3(pieces[i].transform.eulerAngles.x,
            //pieces[i].transform.eulerAngles.y,
            //pieces[i].transform.eulerAngles.z + 0.1f);
        }
    }
}

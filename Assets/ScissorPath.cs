using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScissorPath : MonoBehaviour
{
    public GameObject[] Points; 
    private float moveSpeed = 1; 
    private int pointsIndex = 0; 
    private bool backward = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == Points[0].transform.position){
            backward = false;
        } else if (transform.position == Points[Points.Length - 1].transform.position){
            backward = true; 
        }

        if (backward == false){
            if(pointsIndex < Points.Length - 1){
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex + 1].transform.position, moveSpeed * Time.deltaTime);
            //Debug.Log("Current: " + transform.position);
            //Debug.Log("Target: " + Points[pointsIndex].transform.position);
            if (transform.position == Points[pointsIndex + 1].transform.position){
                pointsIndex +=1; 
                //Debug.Log ("Test");
            }
        }
        } else if (backward == true){
            if(pointsIndex >= 0){
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            //Debug.Log("Current: " + transform.position);
            //Debug.Log("Target: " + Points[pointsIndex].transform.position);
            if (transform.position == Points[pointsIndex].transform.position){
                pointsIndex -=1; 
                //Debug.Log ("Test");
            }
        }
        
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene("SampleScene");
    }
}

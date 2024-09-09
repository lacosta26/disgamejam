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
    private float angle; 
    TrailRenderer trailRenderer;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.material.renderQueue = 3000; // 3000 is the default queue for transparent objects
    }

    // Update is called once per frame
    void Update()
    {
        /*float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movementX, movementY, 0);
        Direction(movement);*/
        if (pointsIndex < 0){
            pointsIndex = 0;
        }

        Vector3 target = Points[pointsIndex].transform.position;
        Vector3 origin = transform.position; 
        Vector3 dir = target - origin;
		dir.Normalize();

        if (transform.position == Points[0].transform.position){
            backward = false;
        } else if (transform.position == Points[Points.Length - 1].transform.position){
            backward = true; 
        }

        if (backward == false){
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 135;
		
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
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 45;

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

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		
    }

    private void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene("SampleScene");
    }

    private void Direction(Vector3 movement)
    {
        Debug.Log("Movement" + movement);
        
        if (movement.x < 0)
        {
            Debug.Log("turning left");
            transform.Rotate(0,0,135);
        }

        else if (movement.x > 0)
        {
            //transform.rotation.z = -45;

        }

        else if (movement.y < 0)
        {
            //transform.rotation.z = -135;

        }
        else if (movement.y > 0)
        {
            //transform.rotation.z = 45;

        }
    }
}

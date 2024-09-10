using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public float targetSize = 10f;  // Target orthographic size

    private float initialZoomSpeed = 3f;  // Initial zoom speed
    public float maxZoomSpeed = 50f;      // Maximum zoom speed
    public float acceleration = 1f;    // Rate of acceleration
    private float currentZoomSpeed;
    public GameObject newMap; 
    public float smoothTime = 0.3f;       // Smoothing time for movement

    private Vector3 velocity = Vector3.zero;  // Used by SmoothDamp

    void Start(){
        currentZoomSpeed = initialZoomSpeed;
    }

    void Update(){
        BigReveal();

    }

    public void BigReveal()
    {
        // Gradually interpolate the orthographic size of the camera
        //Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, Time.deltaTime * growSpeed);
        if (Camera.main.orthographicSize < targetSize)
        {
            if (Camera.main.orthographicSize >= 100){
                Debug.Log("Speed Changed");
                acceleration = 300f;
                
            }

            if (currentZoomSpeed < maxZoomSpeed)
            {
            currentZoomSpeed += acceleration * Time.deltaTime;
            }

            Camera.main.orthographicSize += currentZoomSpeed * Time.deltaTime;
        }
        else if (Camera.main.orthographicSize >= targetSize){
            transform.position = Vector3.Lerp(transform.position, newMap.transform.position, Time.deltaTime * 0.70f);
        } 
        
        //else if (transform.position == newMap.transform.position) { 
        if(transform.position.z >= -0.75){    
            SceneManager.LoadScene("SampleScene");
        }

        //transform.position = Vector3.Lerp(transform.position, newMap.transform.position, Time.deltaTime * 0.1f);
    
    }
}

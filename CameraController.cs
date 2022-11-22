using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCam;
    public GameObject point;

    public float normalSpeed;
    public float fastSpeed;

    public float movementSpeed;
    public float movementTime;

    public float rotationAmount;
    public Vector3 zoomAmount;

    public Vector3 newPosition;
    public Vector3 newZoom;

    public Quaternion newRotation;



    void Start()
    {

        newPosition = transform.position;
        newZoom = mainCam.transform.localPosition;
        newRotation = transform.rotation;
        

        
    }

    
    void Update()
    {
        
        MovementHandler();
        ZoomHandler();
        RotationHandler();
       

       
        
    }

    void MovementHandler(){

        if(Input.GetKey(KeyCode.LeftShift)){

            movementSpeed = fastSpeed;
        }
        else {
            movementSpeed = normalSpeed;
            
        }


        if(Input.GetKey(KeyCode.W)){
            newPosition +=(transform.forward * movementSpeed);

        }
        if(Input.GetKey(KeyCode.S)){
            newPosition += (transform.forward * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.A)){
            newPosition += (transform.right * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.D)){
            newPosition += (transform.right * movementSpeed);
        }


        
        transform.position = Vector3.Lerp(transform.position,newPosition,Time.deltaTime* movementSpeed); //smoth transition

        




        
    }

    void ZoomHandler(){

         if (Input.GetAxis("Mouse ScrollWheel") > 0f ){
            newZoom +=zoomAmount;
            


         }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ){
            newZoom -=zoomAmount;
            


         }

         Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

         mainCam.transform.localPosition = Vector3.Lerp(mainCam.transform.localPosition,newZoom,Time.deltaTime*movementTime);




    }

    void RotationHandler(){

        if(Input.GetKey(KeyCode.Q)){

            newRotation *= Quaternion.Euler(Vector3.up*rotationAmount);
        }
         if(Input.GetKey(KeyCode.E)){

            newRotation *= Quaternion.Euler(Vector3.up*-rotationAmount);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation,newRotation,Time.deltaTime*movementTime);



    }


}

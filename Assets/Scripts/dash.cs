using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour{

    public Camera PlayerCam;
    public float DashDistance;
    public RaycastHit hit;
    public float Speed;
    private Vector3 finalPosition;
    public bool isMoving;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.F)){
            useDash();
        }

        if(isMoving){
            deplacement();
        }
    }


    public void deplacement(){
            transform.position = Vector3.Lerp(transform.position, finalPosition, Speed * Time.deltaTime / Vector3.Distance(transform.position, finalPosition));
            if(Vector3.Distance(transform.position, finalPosition) < 1f){
                isMoving = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
    }
        

    public void useDash(){
        isMoving = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        finalPosition = PlayerCam.transform.position + PlayerCam.transform.forward * DashDistance;
        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, DashDistance)){
                finalPosition = hit.point;
            }
            
        }

    }


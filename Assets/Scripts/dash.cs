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
    public float Cooldown; 
    private float Timer;
    private bool Utilisable = true;

    void Start(){
        Timer = Cooldown;
    }

    void FixedUpdate()
    {
        if (Utilisable) {
            if(Input.GetKey(KeyCode.F)){
                useDash();
            }
        } else{
            if (Timer > 0) {
                Timer -= Time.deltaTime;
            } else {
                Utilisable = true;
                Timer = Cooldown;
            }
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
        Utilisable = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        finalPosition = PlayerCam.transform.position + PlayerCam.transform.forward * DashDistance;
        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, DashDistance)){
                finalPosition = hit.point;
            }
            
        }

    }


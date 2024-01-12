using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour{

    public Transform bodyTransform;
    public float DashDistance;
    public RaycastHit hit;
    public float Speed;
    private Vector3 finalPosition;
    public bool isMoving;
    public float Cooldown; 
    private float Timer;
    private bool Utilisable = true;
    private int counter = 0;

    void Start(){
        Timer = Cooldown;
    }

    void FixedUpdate()
    {
        if (Utilisable) {
            if(Input.GetKey(KeyCode.F) && counter > 0){
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
        Debug.Log(counter);
        isMoving = true;
        Utilisable = false;
        counter -= 2;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        finalPosition = bodyTransform.transform.position + bodyTransform.transform.up * DashDistance;
        if(Physics.Raycast(bodyTransform.transform.position, bodyTransform.transform.up, out hit, DashDistance)){
                finalPosition = hit.point;
            }
            
        }

    public void Counter(){
        counter += 1;
        Debug.Log(counter);
    }
    }


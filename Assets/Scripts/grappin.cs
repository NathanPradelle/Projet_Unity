using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class grappin : MonoBehaviour{
 
    public Camera PlayerCam;
    public RaycastHit hit;
    public Object accrocheGrappin;
    public int maxRange;
    public bool isMoving;
    public Vector3 target;
    public float speed = 10;
    public Transform corde;
    public LineRenderer LR;
    private int counter = 0;


    void Update(){
        
        if(Input.GetKey(KeyCode.Q) && counter > 0){
            useGrappin();
        }
         
        if(isMoving)
        {
            deplacement();
        }
        
        if(Input.GetKey(KeyCode.Space) && isMoving)
        {
            isMoving = false;
            LR.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
 
        
    }
    
    public void deplacement(){
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime / Vector3.Distance(transform.position, target));
        LR.SetPosition(0, corde.position);
        
        if(Vector3.Distance(transform.position, target) < 1.2f){
            isMoving = false;
            LR.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void useGrappin(){
        Debug.Log(accrocheGrappin);

        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, maxRange)){
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("l'objet touché est " + hitObject);
            if (hitObject.name == accrocheGrappin.name) {
                isMoving = true;
                counter -= 2;
                target = hit.point;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                LR.enabled = true;
                LR.SetPosition(1, target);
            }
            
        }
 
    }

    public void Counter(){
        counter += 1;
        Debug.Log(counter);
    }
}
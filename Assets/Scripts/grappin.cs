using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class grappin : MonoBehaviour{
 
    public Camera PlayerCam;
    public RaycastHit hit;
 
    public LayerMask surfaces;
    public int maxRange;
    
    public bool isMoving;
    public Vector3 target;
    
    public float speed = 10;
    public Transform corde;
    
    public LineRenderer LR;
 
    void Update(){
 
        // Envois du grappin
        if(Input.GetKey(KeyCode.G)){
            useGrappin();
        }
        
        // Si le personnage vole, on l'envoie vers le point d'arrivÃ©e 
        if(isMoving)
        {
            deplacement();
        }
        
        // Annulation / dÃ©crochage du grappin
        if(Input.GetKey(KeyCode.Space) && isMoving)
        {
            isMoving = false;
            LR.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
 
        
    }
    
    // Lors de l'envois du grappin
    public void useGrappin(){
        // On crÃ©Ã© un raycast de "maxDistance" unitÃ©s depuis la camÃ©ra vers l'avant.
        // Si ce raycast touche quelque chose c'est que la grappin est utilisable
        if(Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out hit, maxRange, surfaces)){
            isMoving = true;
            target = hit.point;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            LR.enabled = true;
            LR.SetPosition(1, target);
        }
 
    }
 
    // DÃ©placement du joueur vers le point touchÃ© par le grappin
    public void deplacement(){
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime / Vector3.Distance(transform.position, target));
        LR.SetPosition(0, corde.position);
        
        // Si on est Ã  - de 1 unitÃ©(s) de la cible final on dÃ©croche le grappin automatiquement
        if(Vector3.Distance(transform.position, target) < 1f){
            isMoving = false;
            LR.enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
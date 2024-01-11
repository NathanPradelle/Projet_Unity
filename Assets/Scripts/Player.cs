using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform bodyTransform;
    public Transform lava;
    public Transform cameraTransform;
    public Rigidbody playerRigidBody;
    public float speed;
    public float yawRotationSpeed;
    public float pitchRotationSpeed;
    public float enduranceMax;
    public float sprintAcceleration;
    private Vector3 directionIntent;
    private bool wantToJump;
    private float sprintBoost;
    private float endurance;
    public Transform finish;
    public int pourcent;
    public Text scoreText;
    public MenuController MenuController;
    private bool sprintUtilisable;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        endurance = enduranceMax;
    }
    
    public void Highest() 
    {
        
        PlayerPrefs.SetInt("score", pourcent);
        if (PlayerPrefs.GetInt("highscore" + MenuController.Lvlname) < pourcent || PlayerPrefs.GetInt("highscore" + MenuController.Lvlname) == 0)
        {
            PlayerPrefs.SetInt("highscore" + MenuController.Lvlname, pourcent);
        }
    }

    // Update is called once per frame
    private void Update()
    {   
        
        pourcent = Mathf.RoundToInt(bodyTransform.transform.position.y / finish.transform.position.y * 100);
        scoreText.text = pourcent.ToString() + "%";
        
        if (Input.GetKey(KeyCode.W))
        {
            directionIntent += Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            directionIntent += Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            directionIntent += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            directionIntent += Vector3.right;
        }

        if (Input.GetKey(KeyCode.LeftShift)  &&
            Physics.SphereCast(bodyTransform.position + Vector3.up * (0.1f + 0.45f), 0.45f, Vector3.down, 
                out var Info, 
                    0.11f)
            )
        {
            if (sprintUtilisable) {
                sprintBoost = sprintAcceleration;
                if (endurance >= 0) { 
                endurance -= 0.1f;
                } else {
                    sprintUtilisable = false;
                }

            } else {
                sprintBoost = 1;
            }



            
            
        } else {
            sprintBoost = 1;
            
            if (endurance < enduranceMax) {
                    endurance += 0.1f;
                } else {
                    sprintUtilisable = true;
                }
                
            }
        
        //Debug.Log("Endurance: " + endurance);

        var mouseXDelta = Input.GetAxis("Mouse X");

        bodyTransform.Rotate(Vector3.up, Time.deltaTime * yawRotationSpeed * mouseXDelta);

        var mouseYDelta = Input.GetAxis("Mouse Y");

        var rotation = cameraTransform.localRotation;

        var rotationX = rotation.eulerAngles.x;

        rotationX += -Time.deltaTime * pitchRotationSpeed * mouseYDelta;
        

        var unClampedRotationX = rotationX;

        if (unClampedRotationX >= 180)
        {
            unClampedRotationX -= 360;
        }

        var clampedRotationX = Mathf.Clamp(unClampedRotationX, -60, 60);

        cameraTransform.localRotation =
            Quaternion.Euler(new Vector3(
                clampedRotationX,
                rotation.eulerAngles.y,
                rotation.eulerAngles.z
            ));

        if (Input.GetKeyDown(KeyCode.Space) &&
            Physics.SphereCast(bodyTransform.position + Vector3.up * (0.1f + 0.45f), 0.45f, Vector3.down, 
                out var _hitInfo, 
                    0.11f)
            )
        {
            wantToJump = true;
        }
    }
    
    private void FixedUpdate()
    {
        var normalizedDirection = directionIntent.normalized;
        bodyTransform.position += bodyTransform.rotation * normalizedDirection * (Time.deltaTime * speed * sprintBoost);
        lava.position += Vector3.up.normalized * (Time.deltaTime / 2);

        directionIntent = Vector3.zero;
        
        if (wantToJump)
        {
            playerRigidBody.AddForce(
                Vector3.up * 5f, ForceMode.VelocityChange
                );
            wantToJump = false;
        }
    }
}
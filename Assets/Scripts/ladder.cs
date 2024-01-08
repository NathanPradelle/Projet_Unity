using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    public Transform bodyTransform;
    private Vector3 directionIntent;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            directionIntent += Vector3.up;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        var normalizedDirection = directionIntent.normalized;
        bodyTransform.position += normalizedDirection * (Time.deltaTime * speed);
        directionIntent = Vector3.zero;
    }
}

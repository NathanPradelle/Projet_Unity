using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pouvoir : MonoBehaviour
{
    public UnityEvent Event;

    private void OnTriggerEnter(Collider other)
    {
            Event.Invoke();         
        }

    void Update(){
    transform.Rotate(Vector3.forward, Time.deltaTime * 100);
    }

}


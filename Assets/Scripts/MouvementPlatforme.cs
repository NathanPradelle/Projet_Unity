using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPlsateforme : MonoBehaviour
{
    public Vector3 vecteurDeplacement;
    public float vitesseDeplacement = 1.0f;

    private Vector3 positionDepart;
    private float facteurDeplacement;

    void Start()
    {
        positionDepart = transform.position;
    }

    void Update()
    {
        if (vecteurDeplacement != Vector3.zero)
        {
            facteurDeplacement = Mathf.PingPong(Time.time * vitesseDeplacement, 1);
            transform.position = positionDepart + vecteurDeplacement * facteurDeplacement;
        }
    }
}

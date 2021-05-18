using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    float force = 100f; //force to shoot the ammo

    private Camera fpsCam; // first person Camera
        
    // Start is called before the first frame update
    void Start()
    {
       fpsCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); //get cam propreties
        
       GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * force); //give the shot a force in the direction the camera is facing
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); //destroys the shot after a collision
    }
}

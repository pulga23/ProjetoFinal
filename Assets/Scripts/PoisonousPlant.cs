using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonousPlant : MonoBehaviour
{
    [SerializeField] 
    int plantLives = 5; //how many lifes the poisonous plant has.
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ammo"))
        {
            plantLives--;
            if(plantLives<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    Transform target;
    float speed = 6f;
    Vector3 aux, direction;
    [SerializeField]
    GameObject playerAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.mousePosition;
        direction.z = 0f;
        direction = Camera.main.ScreenToWorldPoint(direction);
        direction = direction - transform.position;
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(playerAmmo, transform.position, transform.rotation);
        }
        //float step = speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, aux, step);
    }
}

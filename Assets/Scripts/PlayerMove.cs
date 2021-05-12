using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float velocity = 5f;

    Vector3 front, sideways;
    // Start is called before the first frame update
    void Start()
    {
        front = transform.forward;
        sideways = Quaternion.Euler(new Vector3(0, 90, 0)) * front;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontal = Input.GetAxis("Horizontal") * velocity * Time.deltaTime * sideways;
        Vector3 vertical = Input.GetAxis("Vertical") * velocity * Time.deltaTime * front;

    }
}

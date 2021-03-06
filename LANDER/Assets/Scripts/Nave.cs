using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    [SerializeField]
    float maxRelativeVelocity = 2f;

    [SerializeField]
    float MaxRotation = 10f;

    [SerializeField]
    float thrustForce = 150f;

    [SerializeField]
    float torqueForce = 15f;

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().AddTorque(torqueForce * Time.deltaTime);
        } else if(Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().AddTorque(-torqueForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Aterrei");
            if (collision.relativeVelocity.magnitude > maxRelativeVelocity || Mathf.Abs(transform.localEulerAngles.z) > MaxRotation)
            {
                Debug.Log("...mas explodi!");
            }
            else
            {
                Debug.Log("Explodi!");
            }
        }
    }
}

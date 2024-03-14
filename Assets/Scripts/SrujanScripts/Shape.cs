using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public GameObject starGameobject;
    Rigidbody2D rb;

    private void Start()
    {
            rb= GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name== "Triangle1")
        {
            Instantiate(starGameobject.gameObject,collision.gameObject.transform.position, starGameobject.transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "AntiGravityZone")
        {
            Debug.Log("Collided");
            rb.gravityScale = 0;
            rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
        }

        if(collision.gameObject.tag== "Button")
        {
            this.transform.SetParent(collision.gameObject.transform);
        }
    }
}

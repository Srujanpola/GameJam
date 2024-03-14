using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape2 : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "AntiGravityZone")
        {
            Debug.Log("Collided");
            rb.gravityScale = 0;
            rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag == "Button")
        {
            this.transform.SetParent(collision.gameObject.transform);
        }
    }
}

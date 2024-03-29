using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlrController2 : MonoBehaviour
{
    [SerializeField]  float plrSpd;
    [SerializeField]  float plrJumpSpd;
    [SerializeField]  bool isOnGround=true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        isOnGround = true;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Movement());
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Movement());             
        }
       
        if (Input.GetKeyUp(KeyCode.W) && isOnGround)
        {
          
            isOnGround = false;
            rb.AddForce(Jump(),ForceMode2D.Impulse);
        }

        if (transform.position.y < 0.5 && rb.gravityScale == 0)
        {
            rb.gravityScale = 1f;
        }
        EndGame();

    }
    void EndGame()
    {
        if (this.transform.position.y < -8)
        {
            SceneManager.LoadScene(3);
        }

        if(this.transform.position.y > 10)
        {
            SceneManager.LoadScene(3);
        }
    }
    protected Vector3 Movement()
    {
       return Vector3.right*plrSpd*Time.deltaTime;
    }
    protected Vector3 Jump()
    {
        return Vector2.up * plrJumpSpd;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "AntiGravityZone")
        {
            rb.gravityScale = 0f;
        }

        if (collision.gameObject.tag == "Button")
        {
            rb.gravityScale = 0f;
            rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);

            
        }

        if (collision.gameObject.tag == "Ground"|| collision.gameObject.tag == "Button")
        {
            isOnGround = true;
        }

        if (collision.gameObject.tag == "Blade")
        {
            SceneManager.LoadScene(3);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlrController : MonoBehaviour
{
    [SerializeField] float plrSpd;
    [SerializeField] float plrJumpSpd;
    [SerializeField] bool isOnGround=true;
    Rigidbody2D rb;
    public Camera cam;
    public GameObject levelPrefab;
  
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        isOnGround = true;
        //camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Movement());
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Movement());             
        }
       
        if (Input.GetKeyUp(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Jump(), ForceMode2D.Impulse);
        }

        EndGame();
    }


    void EndGame()
    {
        if(this.transform.position.y < -8)
        {
            Debug.Log("End");
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
            if (Input.GetKey(KeyCode.W)){
                rb.AddForce(Vector2.down * plrJumpSpd, ForceMode2D.Impulse);
            }
        }
        if (collision.gameObject.tag == "Button")
        {
            rb.gravityScale = 0f;
            rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "Ground"||collision.gameObject.tag == "Button")
        {
            isOnGround = true;
        }

        if (collision.gameObject.tag == "Blade")
        {
            Debug.Log("End");
        }
    }
}

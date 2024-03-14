using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Plr2Leve2 : MonoBehaviour
{
    [SerializeField] float playerSpd;
    [SerializeField] float playerJumpSpd;
    [SerializeField] bool  isPlrOnGround = true;
    public Rigidbody2D rb;

    [SerializeField] GameObject Triangle;
    private bool isObjEquiped = false;
    [SerializeField]  Plr1Leve2 Player1;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        Player1 = GameObject.Find("player1").GetComponent<Plr1Leve2>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Movement());
            rb.gravityScale = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Movement());
            rb.gravityScale = 1;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && isPlrOnGround)
        {
            isPlrOnGround = false;
            rb.AddForce(Jump(), ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }

        EquipObject();
        PlayerExchange();
        EndGame();
    }
    void EndGame()
    {
        if (this.transform.position.y < -6.3f)
        {
            Debug.Log("End");
        }
    }
    void EquipObject()
    {
        if(Triangle != null)
        {
            float distance = Vector2.Distance(this.transform.position, Triangle.transform.position);
            Debug.Log(distance);

            if (distance < 5)
            {
                Debug.Log("Press E to Equip Object");

                if (Input.GetKeyDown(KeyCode.E) && Triangle.transform.parent == null)
                {
                    isObjEquiped = true;

                }
                else if (Input.GetKeyDown(KeyCode.E) && Triangle.transform.parent != null)
                {
                    isObjEquiped = false;

                }
                if (isObjEquiped)
                {
                    Vector3 offset = new Vector3(0f, 1f, 0f);

                    Triangle.transform.position = this.transform.position + offset;
                    Triangle.transform.SetParent(this.transform);
                }

                if (!isObjEquiped)
                {
                    Triangle.transform.SetParent(null);
                }
            }
        }
       
    }
    protected Vector3 Movement()
    {
        return Vector3.right * playerSpd * Time.deltaTime;
    }
    protected Vector3 Jump()
    {
        return Vector2.up * playerJumpSpd;
    }
    void PlayerExchange()
    {
        if (rb.gravityScale == 0)
        {
            Player1.rb.gravityScale = 1;
        }

        if (rb.gravityScale == 1)
        {
            Player1.rb.gravityScale = 0;
            Player1.rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isPlrOnGround = true;
        }
        if (collision.gameObject.tag == "Blade")
        {
            Debug.Log("End");
        }
    }
}

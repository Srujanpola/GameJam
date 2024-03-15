using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plr1Leve2 : MonoBehaviour {

    [SerializeField] float playerSpd;
    [SerializeField] float playerJumpSpd;
    [SerializeField] bool isPlrOnGround = true;
    public Rigidbody2D rb;
    bool isObjEquiped = false;

    [SerializeField] GameObject Triangle;
    [SerializeField] public Plr2Leve2 Player2;
    // Start is called before the first frame update
    void Start()
    {
        Player2 = GameObject.Find("player2").GetComponent<Plr2Leve2>();
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Movement());
            rb.gravityScale = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Movement());
            rb.gravityScale = 1;
        }
        if (Input.GetKeyUp(KeyCode.W) && isPlrOnGround)
        {
            isPlrOnGround = false;
            rb.AddForce(Jump(), ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }
        EquipObject();
        PlayerExchange();
        EndGame();

    }
    protected Vector3 Movement()
    {
        return Vector3.right * playerSpd * Time.deltaTime;
    }
    protected Vector3 Jump()
    {
        return Vector2.up * playerJumpSpd;
    }
    void EndGame()
    {
        if (this.transform.position.y < -6.3f)
        {
            SceneManager.LoadScene(3);
        }
    }
    void EquipObject()
    {
        if(Triangle != null)
        {
            float distance = Vector2.Distance(this.transform.position, Triangle.transform.position);
            //Debug.Log(distance);

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

    void PlayerExchange()
    {
        if (rb.gravityScale == 0)
        {
            Player2.rb.gravityScale = 1;
           
        }

        if (rb.gravityScale == 1)
        {
            Player2.rb.gravityScale = 0;
            Player2.rb.AddForce(Vector2.up * 2f, ForceMode2D.Impulse);
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
            SceneManager.LoadScene(3);
        }
    }
}

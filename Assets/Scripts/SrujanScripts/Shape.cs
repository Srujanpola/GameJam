using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //StartCoroutine(ChangeScene());


           
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

    /*IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("New Scene");
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }*/
   /* IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }*/

}

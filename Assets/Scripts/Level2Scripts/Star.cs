using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (collision.gameObject.tag == "Bound")
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (collision.gameObject.tag == "Ground")
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }


    }
}

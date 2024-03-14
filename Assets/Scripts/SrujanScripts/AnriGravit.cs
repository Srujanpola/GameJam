using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnriGravit : MonoBehaviour
{
    public GameObject brickfall;
    public GameObject plr1;
    public GameObject plr2;

   

    private void Update()
    {
        if(plr1.transform.position.y>7 && plr2.transform.position.y > 7)
        {
            brickfall.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public Vector3 targetPosition;
    public Vector3 intitialPosition;
    private float timer = 0.0f;
    bool islerpDone=false;
    // Update is called once per frame
    private void Awake()
    {
         intitialPosition = transform.position;
    }
    void Update()
    {
        if (!islerpDone)
        {
            timer += Time.deltaTime;
            float percentage_cmplt = timer / 3f;
            this.transform.position = Vector3.Lerp(intitialPosition, targetPosition, percentage_cmplt);

            if (percentage_cmplt >= 1f)
            {
                islerpDone = true;
                timer = 0f;
            }

        }
        else if (islerpDone)
        {
            timer += Time.deltaTime;
            float percentage_cmplt = timer / 3f;
            this.transform.position = Vector3.Lerp(targetPosition,intitialPosition, percentage_cmplt);

            if (percentage_cmplt >= 1f)
            {
                islerpDone = false;
                timer = 0f;
            }
        }


    }
}

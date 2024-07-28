using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance = 3f;
    public float smoothTime = 0.1f; 

    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private bool isHeldDown = false;
    void Start()
    {
        initialPosition = new Vector2(0, 0);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHeldDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isHeldDown = false;
        }

        if (isHeldDown)
        {
  
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         

            mousePosition = Vector2.ClampMagnitude(mousePosition, maxDistance);
            targetPosition = mousePosition;
            transform.position = targetPosition;
        }
        else
        {
            transform.localPosition = new Vector2(0, 0);
        }

        //transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, smoothTime);


    }
    //private Vector3 velocity = Vector3.zero;
}

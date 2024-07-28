using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguisherScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance = 3f;
    public float smoothTime = 0.1f;

    private Vector2 targetPosition;
    private Transform parent;

    void Start()
    {
        parent = transform.parent;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       
            Vector2 direction = mousePosition - (Vector2)parent.position;

          
            direction = Vector2.ClampMagnitude(direction, maxDistance);

            targetPosition = (Vector2)parent.position + direction;

            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            transform.localPosition = new Vector2(0, 0);
        }
    }

    private Vector2 velocity = Vector2.zero;

}

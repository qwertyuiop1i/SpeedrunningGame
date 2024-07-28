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

    public float waterStrength = 1f;

    public GameObject waterParticle;

    public float time=0;
    public float reloadTime = 0.2f;

    public float waterPower = 5f;
    void Start()
    {
        parent = transform.parent;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       
            Vector2 direction = mousePosition - (Vector2)parent.position;

          
            direction = Vector2.ClampMagnitude(direction, maxDistance);

            targetPosition = (Vector2)parent.position + direction;

            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

            if (time > reloadTime) 
            {
                GameObject water = Instantiate(waterParticle,transform.position,Quaternion.identity);
                water.GetComponent<Rigidbody2D>().AddForce(transform.right * waterPower,ForceMode2D.Impulse);
                time = 0f;
            }

        }
        else
        {
            transform.localPosition = new Vector2(0, 0);
        }
    }

    private Vector2 velocity = Vector2.zero;

}

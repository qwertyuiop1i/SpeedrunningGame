using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 move;
    private Vector2 mousePos;

    public GameObject fireGrenade;

    public float time;
    public float reloadTime=5f;
    void Start()
    {
        time = reloadTime;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for movement
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        // Get mouse position in world coordinates
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)&&time>reloadTime)
        {
            time = 0f;
            GameObject grenade = Instantiate(fireGrenade, transform.position, Quaternion.identity);
            //grenade.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f);
        }
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + move.normalized * moveSpeed * Time.fixedDeltaTime);

        // Rotate the player to face the mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-90f;
        rb.rotation = angle;
    }
}

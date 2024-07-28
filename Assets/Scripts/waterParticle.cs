using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterParticle : MonoBehaviour
{
    public SpriteRenderer sr;

    public Color startColor;
    public Color endColor;
    public float strength = 3f;
    // Start is called before the first frame update

    public GameObject ps;

    public Rigidbody2D rb;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        sr.color = Color.Lerp(startColor, endColor, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < 0.6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("water"))
        {
            if (collision.gameObject.CompareTag("burnable"))
            {
                collision.gameObject.GetComponent<fireBox>().putOut(strength);

            }
            ps.GetComponent<ParticleSystem>().Play();
            ps.transform.parent = null;
            Destroy(gameObject);
        }
        Physics2D.IgnoreCollision(collision.collider, GetComponent<BoxCollider2D>());
    }
    
}

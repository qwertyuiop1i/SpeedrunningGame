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
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

       // sr.color = Color.Lerp(startColor, endColor, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("burnable"))
        {
            collision.gameObject.GetComponent<fireBox>().putOut(strength);
            
        }
        Destroy(gameObject);
    }
}

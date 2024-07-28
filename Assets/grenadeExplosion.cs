using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeExplosion : MonoBehaviour
{
    public GameObject water;
    public int waterAmount = 50;

    public float force = 20f;
    public float time = 0f;
    public float explodeTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > explodeTime)
        {
            for (int i = 0; i < waterAmount; i++)
            {
                GameObject wa=Instantiate(water,transform.position,Quaternion.identity);
                wa.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle.normalized*force, ForceMode2D.Impulse);
            }
            Destroy(gameObject);
        }

    }
}

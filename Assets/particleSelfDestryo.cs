using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleSelfDestryo : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ps.isPlaying)
        {
            Destroy(gameObject,0.5f);
        }
    }
}

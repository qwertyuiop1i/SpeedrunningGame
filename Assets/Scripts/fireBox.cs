using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBox : MonoBehaviour
{
    public float fireMaxStrength;
    public float fireStrength;
    public float buildupSpeed;

    public ParticleSystem smokePs;
    public ParticleSystem firePs;

    public float time = 0f;
    public float buildTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        fireStrength = fireMaxStrength;
    }

    // Update is called once per frame
    void Update()
    {
        var smokeStuff = smokePs.emission;
        var fireStuff = firePs.emission;

        smokeStuff.rateOverTime = fireStrength / fireMaxStrength * 30;
        fireStuff.rateOverTime = fireStrength / fireMaxStrength * 60;
        time += Time.deltaTime;
        if (time > buildTime)
        {
            if (fireStrength != 0)
            {
                fireStrength += buildupSpeed;
                fireStrength = Mathf.Clamp(fireStrength, 0f, fireMaxStrength);
                time = 0f;

            }
        }
    }
    public void putOut (float damage){

        fireStrength -= damage;

        fireStrength = Mathf.Clamp(fireStrength, 0f, fireMaxStrength);

        if (fireStrength == 0)
        {
            gameObject.tag = "putOut";
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heatbarFollow : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    public Vector2 offset;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)player.position + offset;
    }
}

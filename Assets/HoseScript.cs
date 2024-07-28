using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseScript : MonoBehaviour
{

    public Transform start;
    public Transform end;

    public LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, start.position);
        lr.SetPosition(1, end.position);
    }
}

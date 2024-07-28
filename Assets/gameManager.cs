using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    
    List<float> myFloatList = new List<float>();
    public float currentTime;
    public bool hasWon;

    public float heatBar = 0f;

    public GameObject heatBarGO;
    public float heatBarFullWidth=30f;
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (GameObject.FindGameObjectsWithTag("burnable").Length == 0)
        {
            hasWon = true;
            Debug.Log("Won");
        }
        else
        {
            heatBar += Time.deltaTime * GameObject.FindGameObjectsWithTag("burnable").Length;
        }
        //if no burning objects then win screen and go to next.

        heatBarGO.transform.localScale =new Vector3( heatBarFullWidth * heatBar / 100f,0.8f,1);
    }
}

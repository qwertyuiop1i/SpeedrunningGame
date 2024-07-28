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

    public GameObject t;

    public AudioSource soundPlayer;

    public AudioClip warningBeep;
    public float beepTime = 1f;
    public float timeTrack = 0f;
    void Start()
    {
        currentTime = 0f;


        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        heatBarGO = GameObject.Find("heatFilling");
        t = GameObject.Find("timerText");

        currentTime += Time.deltaTime;
        timeTrack += Time.deltaTime;
        t.GetComponent<TMPro.TextMeshProUGUI>().text = (currentTime).ToString();

        if (GameObject.FindGameObjectsWithTag("burnable").Length == 0)
        {
            hasWon = true;
            Debug.Log("Won");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            heatBar += Time.deltaTime * GameObject.FindGameObjectsWithTag("burnable").Length;
            if (heatBar >= 100f)
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                heatBar = 0f;
            }
        }
        //if no burning objects then win screen and go to next.
        if (heatBar >= 80f)
        {
            
            if (!soundPlayer.isPlaying&&timeTrack>beepTime)
            {
                soundPlayer.PlayOneShot(warningBeep);
                timeTrack = 0f;
            }

        }
        heatBarGO.transform.localScale =new Vector3( heatBarFullWidth * heatBar / 100f,0.8f,1);
    }
}

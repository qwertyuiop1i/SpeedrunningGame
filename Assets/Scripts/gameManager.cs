using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    

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

    public float ?bestTime=null;
    void Start()
    {
        currentTime = 0f;


        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
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
                heatBar = 0f;
            }
            else
            {
                heatBar += 0.2f*Time.deltaTime * GameObject.FindGameObjectsWithTag("burnable").Length;
                if (heatBar >= 100f)
                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    heatBar = 0f;
                }
            }
           
            if (heatBar >= 80f)
            {

                if (!soundPlayer.isPlaying && timeTrack > beepTime)
                {
                    soundPlayer.PlayOneShot(warningBeep);
                    timeTrack = 0f;
                }
            }
            heatBarGO.transform.localScale = new Vector3(heatBarFullWidth * heatBar / 100f, 0.8f, 1);
        }
        else
        {
            GameObject.Find("HStext").GetComponent<TMPro.TextMeshProUGUI>().text = "High Score: " + bestTime.ToString();
        }
    }
    
}

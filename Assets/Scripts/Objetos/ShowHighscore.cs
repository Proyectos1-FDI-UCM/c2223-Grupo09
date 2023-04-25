using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowHighscore : MonoBehaviour
{
    private float Highscore;
    // Start is called before the first frame update
    void Start()
    {
        Highscore = PlayerPrefs.GetFloat("Highscore");
        TimeSpan time = TimeSpan.FromSeconds(Highscore);
        if (Highscore == 0f) GetComponent<Text>().text = "--:--";
        else if (time.Minutes < 10 && time.Seconds < 10) GetComponent<Text>().text = "0" + time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        else if (time.Minutes < 10 && time.Seconds >= 10) GetComponent<Text>().text = "0" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
        else if (time.Minutes >= 10 && time.Seconds < 10) GetComponent<Text>().text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        else if (time.Minutes >= 10 && time.Seconds >= 10) GetComponent<Text>().text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void Reset()
    {
        PlayerPrefs.SetFloat("Highscore", 0f);
        GetComponent<Text>().text = "--:--";
    }
}

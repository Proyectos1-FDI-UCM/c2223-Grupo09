using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActivado = true;
    float _tiempo;
    private Text _timerText1;
    private Text _timerText2;
    private GameObject SecurityTemporal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timerText1 == null || _timerText2 == null)
        {
            SecurityTemporal = GameObject.Find("Timer1");
            if(SecurityTemporal !=null)_timerText1 = SecurityTemporal.GetComponent<Text>();
            SecurityTemporal = GameObject.Find("Timer2");
            if (SecurityTemporal != null) _timerText2 = SecurityTemporal.GetComponent<Text>();
        }else if (timerActivado)
        {
            _tiempo += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_tiempo);
            if(_tiempo%60 < 10)
            {
                _timerText2.text = "0"+time.Seconds.ToString();
            }
            else
            {
                _timerText2.text = time.Seconds.ToString();
            }
            if (_tiempo / 60 < 10)
            {
                _timerText1.text = "0"+time.Minutes.ToString();
            }
            else
            {
                _timerText1.text = time.Minutes.ToString();
            }                       
        }        
    }
    public void StartTimer()
    {
        timerActivado = true;
    }
    public void StopTimer()
    {
        timerActivado = false;
    }
    public void RestartTimer()
    {
        _tiempo = 0f;
    }
    public void SaveData()
    {
        StopTimer();
        SecurityTemporal = GameObject.Find(":");
        if (PlayerPrefs.GetFloat("Highscore") == 0 || _tiempo < PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", _tiempo);            
            _timerText1.color = Color.yellow;
            _timerText2.color = Color.yellow;
            SecurityTemporal.GetComponent<Text>().color = Color.yellow;
        }
        else
        {
            _timerText1.color = Color.green;
            _timerText2.color = Color.green;
            SecurityTemporal.GetComponent<Text>().color = Color.green;
        }
    }
}

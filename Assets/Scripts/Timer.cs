using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    bool timerActivado = true;
    float _tiempo;
    private Text _timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timerText == null)
        {
            _timerText = GameObject.Find("Timer").GetComponent<Text>(); 
        }
        if (timerActivado)
        {
            _tiempo += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_tiempo);
            _timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
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
}

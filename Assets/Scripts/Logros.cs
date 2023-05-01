using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logros : MonoBehaviour
{
    [SerializeField] Image _logro1;
    [SerializeField] Image _logro2;
    [SerializeField] Image _logro3;
    [SerializeField] Image _logro4;
    [SerializeField] Image _logro5;
    [SerializeField] Image _logro6;
    [SerializeField] Image _logro7;
    [SerializeField] Image _logro8;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("Highscore") > 600f|| PlayerPrefs.GetFloat("Highscore") ==0)
        {
            _logro1.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        if (PlayerPrefs.GetInt("Engranajes") ==0)
        {
            _logro2.color = new Color(0.25f, 0.25f, 0.25f,1f);
        }
        if (PlayerPrefs.GetInt("EncontradoCabeza") == 0)
        {
            _logro3.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        if (PlayerPrefs.GetInt("EncontradoBuho") == 0)
        {
            _logro4.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        if (PlayerPrefs.GetFloat("Highscore") > 300f || PlayerPrefs.GetFloat("Highscore") == 0)
        {
            _logro5.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        if (PlayerPrefs.GetInt("SinMejoras") == 0)
        {
            _logro6.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        if (PlayerPrefs.GetInt("Tocado") == 0)
        {
            _logro7.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
        if (PlayerPrefs.GetFloat("Highscore") > 210f || PlayerPrefs.GetFloat("Highscore") == 0)
        {
            _logro8.color = new Color(0.25f, 0.25f, 0.25f, 1f);
        }
    }
    // Update is called once per frame
    public void Logro1()
    {
        
    }
    public void Logro2()
    {
        Debug.Log("2");
    }
    public void Logro3()
    {
        Debug.Log("3");
    }
    public void Logro4()
    {
        Debug.Log("4");
    }
    public void Logro5()
    {
        Debug.Log("5");
    }
    public void Logro6()
    {
        Debug.Log("6");
    }
    public void Logro7()
    {
        Debug.Log("7");
    }
    public void Logro8()
    {
        Debug.Log("8");
    }
}

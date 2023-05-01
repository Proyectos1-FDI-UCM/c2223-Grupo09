using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    [SerializeField] Text descripción;
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
        if (PlayerPrefs.GetInt("Cabeza") == 0)
        {
            _logro3.color = new Color(0.35f, 0.35f, 0.35f, 1f);
        }
        if (PlayerPrefs.GetInt("Buho") == 0)
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
        descripción.text = new string("Completa una partida en menos de 10 minutos");
    }
    public void Logro2()
    {
        descripción.text = new string("Consigue todos los engranajes posibles en una sola partida");
    }
    public void Logro3()
    {
        descripción.text = new string("Encuentra la piedra con forma de cabeza escondida en alguna zona del mapa");
    }
    public void Logro4()
    {
        descripción.text = new string("Encuentra al buho con gorro escondido en alguna zona del mapa");
    }
    public void Logro5()
    {
        descripción.text = new string("Completa una partida en menos de 5 minutos");
    }
    public void Logro6()
    {
        descripción.text = new string("Completa una partida sin usar un solo escudo o vida extra");
    }
    public void Logro7()
    {
        descripción.text = new string("Completa una partida sin recibir un solo golpe (se pueden usar los escudos)");
    }
    public void Logro8()
    {
        descripción.text = new string("Completa una partida en menos de 3 minutos y 30 segundos");
    }
}

using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolumen : MonoBehaviour
{
    public Slider slider;      //referencia al slider
    public float _sliderValue;  //valor que va a tomar
    public Image _mute;         //imagen de mute
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0.5f;   //comienza con el volumen a la mitad
        AudioListener.volume = slider.value;   
        
    }

    public void ChangeSlider(float valor)
    {
        _sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", _sliderValue);
        AudioListener.volume = slider.value;
        IsMute();

    }

    public void IsMute()
    {
        if (_sliderValue == 0)
        {
            _mute.enabled = true;
        }
        else
        {
            _mute.enabled = false;
        }
    }
}

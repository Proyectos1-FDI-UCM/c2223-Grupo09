using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolumen : MonoBehaviour
{
    public Slider volumen;
    public float _sliderValue;
    public Image _mute;
    // Start is called before the first frame update
    void Start()
    {
        volumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = volumen.value;
        IsMute();
    }

    private void ChangeSlider(float valor)
    {
        volumen.value = valor;
        PlayerPrefs.SetFloat("volumenAudio", _sliderValue);
        AudioListener.volume = _sliderValue;
        IsMute();

    }

    private void IsMute()
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

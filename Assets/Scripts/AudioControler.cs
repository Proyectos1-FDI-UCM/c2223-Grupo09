using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    public static AudioControler Instance;
    private AudioSource _myAudio;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            

        }
        else
        {
            Destroy(gameObject);
        }

        _myAudio = GetComponent<AudioSource>();

    }

    public void PlaySound(AudioClip sound)
    {
        _myAudio.PlayOneShot(sound);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    private Slider soundSlider;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ChangeVolume()
    {
        soundSlider = GameObject.FindWithTag("SoundSlider").GetComponent<Slider>();

        audio.volume = soundSlider.value;
    }
}

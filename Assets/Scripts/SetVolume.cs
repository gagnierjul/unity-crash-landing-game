using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

// THIS SCRIPT HAS BEEN TAKEN FROM AN IN-CLASS ACTIVITY GIVEN BY MARC-ANDRE LAROUCHE (FALL 2019)

[RequireComponent(typeof(Slider))]
public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioM;
    [SerializeField] private string nameParameter;

    public void SetVol(float vol)
    {
        Slider slide = GetComponent<Slider>();
        audioM.SetFloat(nameParameter, vol);
        slide.value = vol;
        PlayerPrefs.SetFloat(nameParameter, vol);
        PlayerPrefs.Save();
    }
    // Start is called before the first frame update
    void Start()
    {
        Slider slide = GetComponent<Slider>();
        float v = PlayerPrefs.GetFloat(nameParameter, 0);
        slide.value = v;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

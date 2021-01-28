using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// THIS SCRIPT HAS BEEN TAKEN FROM AN IN-CLASS ACTIVITY GIVEN BY MARC-ANDRE LAROUCHE (FALL 2019)

public class SetGFX : MonoBehaviour
{
    [SerializeField] private TMP_Text txtGFX; 
    private string[] GFXNames; 


    public void SetGfx(float val)
    {
        Slider slide = GetComponent<Slider>();
        int v = (int)Mathf.Floor(val);
        slide.value = val;
        QualitySettings.SetQualityLevel(v, false);
        txtGFX.text = GFXNames[v];
    }
    // Start is called before the first frame update
    void Start()
    {
        GFXNames = QualitySettings.names; 
        Slider slide = GetComponent<Slider>();
        float v = QualitySettings.GetQualityLevel();
        slide.value = v; 
        txtGFX.text = GFXNames[(int)v];
    }

    // Update is called once per frame
    void Update()
    {

    }
}

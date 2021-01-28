using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercentage : MonoBehaviour
{

    Text percentage;
    // Start is called before the first frame update
    void Start()
    {
        percentage = GetComponent<Text>();
    }

    public void updateText(float value)
    {
        percentage.text = Mathf.RoundToInt(value * 100) + "%";
    }
}

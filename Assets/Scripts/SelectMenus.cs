using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// THIS SCRIPT HAS BEEN TAKEN FROM AN IN-CLASS ACTIVITY GIVEN BY MARC-ANDRE LAROUCHE (FALL 2019)

public class SelectMenus : MonoBehaviour
{
    [SerializeField] private GameObject[] panels; 
    [SerializeField] private Selectable[] defaultButtons; 

    public void PanelToggle()
    {
        PanelToggle(0); 
    }

    public void PanelToggle(int position)
    {
        Input.ResetInputAxes();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(position == i);
            if (position == i)
            {
                defaultButtons[i].Select(); 
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PanelToggle", 0.01f); 
    }

    // Update is called once per frame
    void Update()
    {

    }
}

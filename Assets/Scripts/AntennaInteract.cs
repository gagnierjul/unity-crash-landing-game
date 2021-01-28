using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AntennaInteract : MonoBehaviour
{
    private GameObject raycastedObject;
    private GameManager code;

    [SerializeField] private int rayLength = 5; // Must be 5 meters away from object in order to interact
    [SerializeField] private LayerMask layerMaskInteract; // We will seperate interactable objects into their own layer

    [SerializeField] private GameObject antennaInteractPanel;
    [SerializeField] private Text interactTxt;
    [SerializeField] private TMP_Text toolboxCounterText;
    [SerializeField] private GameObject gameWinPanel;

    void Start()
    {
        interactTxt.gameObject.SetActive(false);
        code = GameManager.instance;
        antennaInteractPanel.gameObject.SetActive(false);
        toolboxCounterText.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.tag == "Antenna")
            {
                raycastedObject = hit.collider.gameObject;
                interactTxt.gameObject.SetActive(true);

                if (Input.GetKeyDown("e"))
                {
                    if (code.AllToolboxesCollected() == true)
                    {
                        gameWinPanel.gameObject.SetActive(true);
                        Time.timeScale = 0.0f;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                    }
                    else if (code.AllToolboxesCollected() == false)
                    {
                        toolboxCounterText.gameObject.SetActive(true);
                        antennaInteractPanel.gameObject.SetActive(true);
                    }
                }
                
            }
        }
        else
        {
            interactTxt.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            antennaInteractPanel.gameObject.SetActive(false);
        }
    }
}

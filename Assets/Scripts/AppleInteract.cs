using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AppleInteract : MonoBehaviour
{
    private GameManager code;
    private GameObject raycastedObject;

    [SerializeField] private int rayLength = 2; // Must be 2 meter away from object in order to interact
    [SerializeField] private LayerMask layerMaskInteract; // We will seperate interactable objects into their own layer

    [SerializeField] private Text interactTxt;

    void Start()
    {
        interactTxt.gameObject.SetActive(false);
        code = GameManager.instance;
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.tag == "Apple")
            {
                raycastedObject = hit.collider.gameObject;
                interactTxt.gameObject.SetActive(true);

                if (Input.GetKeyDown("e"))
                {
                    code.EatApple();
                    raycastedObject.SetActive(false);
                }
            }
        }
        else
        {
            interactTxt.gameObject.SetActive(false);
        }
    }
}

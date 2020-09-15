using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject[] normalGroup;
    public GameObject[] transparentGroup;
    public Activator button;
    public Material normal;
    public Material transparent;
    public bool canPush;

    private void OnTriggerEnter(Collider collider)
    {
        if (canPush)
        {
            if (collider.CompareTag("Barrier") || collider.CompareTag("Player")) // + collider.CompareTag("Barrier")
            {
                foreach (GameObject first in normalGroup)
                {
                    first.GetComponent<Renderer>().material = normal;
                    first.GetComponent<Collider>().isTrigger = false;
                }

                foreach (GameObject second in transparentGroup)
                {
                    second.GetComponent<Renderer>().material = transparent;
                    second.GetComponent<Collider>().isTrigger = true;
                }

                GetComponent<Renderer>().material = transparent;
                button.GetComponent<Renderer>().material = normal;
                button.canPush = true;
            }
        }
    }
}

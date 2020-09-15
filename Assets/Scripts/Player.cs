using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] KeyCode keyOne;
    [SerializeField] KeyCode keyTwo;
    [SerializeField] Vector3 moveDirection;

    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }

        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(this.CompareTag("Player") && collider.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (this.CompareTag("Barrier") && collider.CompareTag("Barrier"))
        {
            foreach(Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = false;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (this.CompareTag("Barrier") && collider.CompareTag("Barrier"))
        {
            foreach (Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = true;
            }
        }
    }

}

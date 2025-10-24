using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
   public bool isInRange;

    public UnityEvent interactAction;


    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactAction.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}



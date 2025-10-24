using System.Collections;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public Animator animator;
    public float duration = 1.4f;

    void Start()
    {
       animator = GetComponent<Animator>();
    }
    
  

    public void ChestPickup()
    {
        animator.SetBool("isOpen",true);
        Destroy(gameObject,duration);
    }
}


using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(10);
            Debug.Log("Player hit by projectile!");
        }
    }
}

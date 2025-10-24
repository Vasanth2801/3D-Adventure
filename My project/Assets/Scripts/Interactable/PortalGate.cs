using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalGate : MonoBehaviour
{
    public bool isDoorOpen;

    public void OpenDoor(GameObject obj)
    {
        if(!isDoorOpen)
        {
            KeyManager keyManager = obj.GetComponent<KeyManager>();
            if (keyManager)
            {
                if (keyManager.keyCount > 0)
                {
                    isDoorOpen = true;
                    keyManager.keyCount--;
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}

using UnityEngine;

public class WinPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.gameManager.win = true;
            GameManager.gameManager.EndGame();
        }
    }
}

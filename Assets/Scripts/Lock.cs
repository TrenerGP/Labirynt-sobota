using System.Drawing;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public Door[] doors;
    public KeyColor myColor;
    bool canOpen;
    bool unlocked;
    Animator key;

    public Material red;
    public Material green;
    public Material blue;
    public Renderer myLock;

    private void Start()
    {
        key = GetComponent<Animator>();
        SetMyColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
            Debug.Log("You can open door");
            GameManager.gameManager.useInfo.text = "Press E to open lock";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
            Debug.Log("You cannot open door");
            GameManager.gameManager.useInfo.text = "";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !unlocked)
        {
            key.SetBool("useKey", CheckKey());
        }
    }

    public void UseKey()
    {
        foreach (var door in doors)
        {
            door.Open();
        }
    }

    public bool CheckKey()
    {
        if (GameManager.gameManager.redKey>0 && myColor==KeyColor.Red)
        {
            unlocked = true;
            GameManager.gameManager.redKey--;
            GameManager.gameManager.redKeyText.text = 
                GameManager.gameManager.redKey.ToString();
            return true;
        }
        else if (GameManager.gameManager.blueKey > 0 && myColor == KeyColor.Blue)
        {
            unlocked = true;
            GameManager.gameManager.blueKey--;
            GameManager.gameManager.blueKeyText.text =
                GameManager.gameManager.blueKey.ToString();
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myColor == KeyColor.Green)
        {
            unlocked = true;
            GameManager.gameManager.greenKey--;
            GameManager.gameManager.greenKeyText.text =
                GameManager.gameManager.greenKey.ToString();
            return true;
        }
        Debug.Log("You don't have a key!");
        return false;
    }

    void SetMyColor()
    {
        switch (myColor)
        {
            case KeyColor.Red:
                myLock.material = red;
                break;
            case KeyColor.Green:
                myLock.material = green;
                break;
            case KeyColor.Blue:
                myLock.material = blue;
                break;
        }
    }
}

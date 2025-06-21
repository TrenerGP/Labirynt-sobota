using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform closePosition;
    public Transform openPosition;
    public Transform door;

    public bool open;
    public float speed = 5;

    private void Start()
    {
        door.position = closePosition.position;
    }

    public void Open()
    {
        open = true;
    }

    private void Update()
    {
        if (open && Vector3.Distance(door.position, openPosition.position)>0.01f)
        {
            door.position = Vector3.MoveTowards(
                door.position, openPosition.position, speed*Time.deltaTime);
        }
    }
}

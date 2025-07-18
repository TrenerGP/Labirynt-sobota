using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Vector3 rotationSpeed;
    AudioClip pickClip;

    public virtual void Picked()
    {
        Debug.Log("Pickup collected");
        GameManager.gameManager.PlayClip(pickClip);
        Destroy(this.gameObject);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(
            rotationSpeed.x * Time.deltaTime,
            rotationSpeed.y * Time.deltaTime,
            rotationSpeed.z * Time.deltaTime));
    }

    private void Update()
    {
        Rotate();
    }
}

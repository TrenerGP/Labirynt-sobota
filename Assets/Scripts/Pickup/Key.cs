using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Blue
}

public class Key : Pickup
{
    public KeyColor color;

    public Material red;
    public Material green;
    public Material blue;

    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);
        base.Picked();
    }

    void SetMyColor()
    {
        switch(color)
        {
            case KeyColor.Red:
                GetComponent<Renderer>().material = red;
                break;
            case KeyColor.Green:
                GetComponent<Renderer>().material = green;
                break;
            case KeyColor.Blue:
                GetComponent<Renderer>().material = blue;
                break;
        }
    }
    private void Start()
    {
        SetMyColor();
    }
}

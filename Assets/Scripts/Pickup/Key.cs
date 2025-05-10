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

    public override void Picked()
    {
        GameManager.gameManager.AddKey(color);
        base.Picked();
    }
}

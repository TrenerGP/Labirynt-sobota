using UnityEngine;

public class AddTime : Pickup
{
    public int timeModifier;
    public override void Picked()
    {
        GameManager.gameManager.AddTime(timeModifier);
        base.Picked();
    }
}

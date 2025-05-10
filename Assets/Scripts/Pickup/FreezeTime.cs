using UnityEngine;

public class FreezeTime : Pickup
{
    public int freezeTime = 10;
    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        base.Picked();
    }
}

using UnityEngine;

public class Speed : Pickup
{
    public float speedModifier;
    public int timeDuration;

    public override void Picked()
    {
        GameManager.gameManager.SetSpeedModifier(speedModifier, timeDuration);
        base.Picked();
    }
}

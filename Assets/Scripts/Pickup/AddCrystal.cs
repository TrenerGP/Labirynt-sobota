using UnityEngine;

public class AddCrystal : Pickup
{
    public int points = 5;
    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        base.Picked();
    }
}

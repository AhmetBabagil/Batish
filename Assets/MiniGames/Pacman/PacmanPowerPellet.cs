using UnityEngine;

public class PacmanPowerPellet : PacmanPellet
{
    public float duration = 8f;

    protected override void Eat()
    {
        FindObjectOfType<PacmanGameManager>().PowerPelletEaten(this);
    }

}
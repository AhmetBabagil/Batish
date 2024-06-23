using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public PetController pet;
    public NeedsController needsController;
    public float petmovetimer, originalpetmovetimer;
  //  public Transform[] waypoints;

    public static PetManager instance;
    private void Awake()
    {
        originalpetmovetimer = petmovetimer;
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than 1 pet manager in the scene");
    }
    private void Update()
    {
        if (petmovetimer > 0)
        {
            petmovetimer -= Time.deltaTime;
        }
        else
        {
            MovePetToRandomMovePoint();

            petmovetimer = originalpetmovetimer;
        }
    }

    private void MovePetToRandomMovePoint()
    {
 //       int randomwaypoint = Random.Range(0, waypoints.Length);
 //       pet.Move(waypoints[randomwaypoint].position);
    }

    public void Die()
    {
        Debug.Log("DEAD");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidsAstreoidSpawner : MonoBehaviour
{
    public float spawndistance = 15.0f;
    public float trajectoraryvariance = 15.0f;
    public AstreoidsAstreoid AstreoidPrefab;
    public float spawnrate = 1.0f;
    public int spawnamount = 1;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnrate,this.spawnrate);
     
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnamount; i++){
            Vector3 spawndirection = Random.insideUnitCircle.normalized*this.spawndistance;
            Vector3 spawnpoint = this.transform.position+spawndirection;

            float variance = Random.Range(this.trajectoraryvariance, this.trajectoraryvariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);


        AstreoidsAstreoid astreoid = Instantiate(this.AstreoidPrefab, spawnpoint, rotation);
            astreoid.size=Random.Range(astreoid.minsize, astreoid.maxsize);
            astreoid.SetTrajectory(rotation * -spawndirection);
        }
    }
   
}

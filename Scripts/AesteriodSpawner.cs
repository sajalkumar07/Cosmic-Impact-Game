using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AesteriodSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float trajactoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;  
    public float spawnDistance = 15.0f;

    private void Start() 
    {

        InvokeRepeating(nameof(Spawn),this.spawnRate, this.spawnRate);

    }

    private void Spawn()
    {
        for(int i=0; i<this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance; 
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajactoryVariance, this.trajactoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation); 
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}

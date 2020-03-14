using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Asteroid;
    public GameObject Enemy;
    private float minDelay = 0.1f, maxDelay = 0.4f;

    //for Asteroid velosity
    public float velosity;
    [HideInInspector]public float AsterVelosity;
    private float StartTime;

    private float NextAster;
    private float DelayEnemy = 10f;
    private float NextEnemy;
    void Start()
    {
        StartTime = Time.time;
        NextAster = Time.time;
        NextEnemy = Time.time + DelayEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - StartTime)*velosity/100 > 1)
            AsterVelosity = (Time.time - StartTime) * velosity / 100;
        else
            AsterVelosity = 1;

        if (Time.time > NextAster)
        {
            NextAster = Time.time + Random.Range(minDelay, maxDelay);
            float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Vector3 NewPos = new Vector3(positionX, 0, transform.position.z);
            Instantiate(Asteroid, NewPos, Quaternion.identity);
        }
        if(Time.time > NextEnemy)
        {
            float positionX = Random.Range(-49, 49);
            Vector3 NewPos = new Vector3(positionX, 2.4f, 40);
            Instantiate(Enemy, NewPos, Quaternion.Euler(180, 0, 0));
            NextEnemy = Time.time + DelayEnemy;
        }
    }
}   
        
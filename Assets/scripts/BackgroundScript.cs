using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private float StartPosition;
    public float speed;
    float StartTime;

    void Start()
    {
        StartPosition = transform.position.z;
        StartTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movement = Mathf.Repeat((StartTime - Time.time) * speed * GameObject.Find("AsterSpawn").GetComponent<SpawnScript>().AsterVelosity, 162);
        
        transform.position = new Vector3(0, -10f, movement - 162);

    }
}

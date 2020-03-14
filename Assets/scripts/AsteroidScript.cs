using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotation;
    public float MaxSpeed, MinSpeed;
    public GameObject Explotion;
    public GameObject ExplotionPlayer;
    Rigidbody asteroid;



    void Start()
    {
        GameObject Spawn = GameObject.Find("AsterSpawn");
        transform.localScale = new Vector3(Random.Range(2f, 4f), 2f, Random.Range(2f, 4f));
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotation;
        asteroid.velocity = new Vector3(Random.Range(-1f, 1f), 0, -1f) * Random.Range(MinSpeed, MaxSpeed) * Spawn.GetComponent<SpawnScript>().AsterVelosity;
    }

    // Update is called once per frame
    void Update()
    {
        asteroid.velocity += new Vector3(Random.Range(-1f, 1f) * 0.01f, 0, 0.01f);     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Asteroid" || other.tag == "GameBox" || other.tag == "Enemy")
        {
            return;
        }
        Instantiate(Explotion, transform.position, Quaternion.identity);
        if(other.tag == "Player")
        {
            Instantiate(ExplotionPlayer, other.transform.position, Quaternion.identity);


        }
        //   Destroy(Explotion, 1f);

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}

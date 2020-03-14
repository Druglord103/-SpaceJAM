using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LaserScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 60f;

    void Start()
    {
        
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject score = GameObject.Find("Score");
        if (other.tag == "Asteroid")
        {
            score.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(score.GetComponent<Text>().text) + 10);
        }
        if (other.tag == "Enemy")
            score.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(score.GetComponent<Text>().text) + 50);

    }

}

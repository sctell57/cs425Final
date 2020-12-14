using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private playermovement player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
    }




    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);


            StartCoroutine(player.Knockback(.000005f, -100f, player.transform.position));
        }


    }
    
    
    
    // Update is called once per frame

    void Update()
    {
        
    }
}

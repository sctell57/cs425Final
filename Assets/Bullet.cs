using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private playermovement player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<playermovement>().Damage(1);
                StartCoroutine(player.Knockback(.0005f, -100f, player.transform.position));
                Destroy(gameObject);
            }
            if (col.CompareTag("ground"))
            {
                Destroy(gameObject);
            }
            
        }
    }
}

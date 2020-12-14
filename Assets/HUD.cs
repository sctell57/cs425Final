using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    public Sprite[] HealthBar;

    public Image HealthBarUI;

    private playermovement player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playermovement>();
    }

    void Update()
    {
        HealthBarUI.sprite = HealthBar[player.curHealth];
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public int LevelToLoad;

    private gameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gameMaster").GetComponent<gameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")){
            gm.InputText.text = ("[E] to Enter");
        }
        if (Input.GetKeyDown("e"))
        {
            Application.LoadLevel(LevelToLoad);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                Application.LoadLevel(LevelToLoad);
            }
        }
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.InputText.text = ("");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameMaster : MonoBehaviour
{

    public int points = 0;
    public Text pointsText;

    public Text InputText;

    void Update()
    {
        pointsText.text = "Points: " + points;
    }
}

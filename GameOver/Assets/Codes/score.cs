using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text txtScore;

    void Start()
    {
        
    }

    void Update()
    {
        txtScore.text = "Score: "+meteor.liveCount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceScript : MonoBehaviour
{
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.gameObject.tag == "meteor_tag")
        {

            Time.timeScale = 0;
            gameOver.SetActive(true);

        }
    }
}

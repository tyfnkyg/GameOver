using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ship : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameStart;
    public GameObject gamePlayer;

    Rigidbody2D rigitBody;
    public GameObject ship_obj;
    float speed = 2.0f;

    int hitLive = 0;
    public Text hitLiveTxt, startHitLiveTxt;

    void Start()
    {
        gamePlayer.SetActive(false);
        Time.timeScale = 0; // oyunu durdur
        hitLive = PlayerPrefs.GetInt("hitLive", 0);
        rigitBody = GetComponent<Rigidbody2D>();
        gameOver.SetActive(false);
        gameStart.SetActive(true);
        startHitLiveTxt.text = "Hit Score : " + hitLive;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D obj)
    {
        
        if (obj.gameObject.tag == "meteor_tag")
        {

            if (meteor.liveCount > hitLive) {
                // son score değerini vt yaz
                PlayerPrefs.SetInt("hitLive", meteor.liveCount);
            }

            Time.timeScale = 0; // oyunu bitir
            gameOver.SetActive(true);
            int writeCount = PlayerPrefs.GetInt("hitLive", 0);
            hitLiveTxt.text = "Hit Score : " + writeCount;

        }
    }


    // game start button
    public void startBtn() {
        gamePlayer.SetActive(true);
        //Debug.Log("Btn Call()");
        gameStart.SetActive(false);
        Time.timeScale = 1;
    }

    public void reStart()
    {
        gamePlayer.SetActive(false);
        // game refresh
        Time.timeScale = 0;
        meteor.live = 1;
        meteor.liveCount = 0;
        rocket.rocketCount = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void btn_left() {
        rigitBody.velocity = -transform.right * speed;
    }

    public void btn_right()
    {
        rigitBody.velocity = transform.right * speed;
    }

    public void btn_top()
    {
        rigitBody.velocity = transform.up * speed;
    }

    public void btn_down()
    {
        rigitBody.velocity = -transform.up * speed;
    }


    public void btn_rocket_fire()
    {

        if (rocket.createStatu == false)
        {
            rocket.createStatu = true;
            rocket.rocketCount--;
        }
    }



}

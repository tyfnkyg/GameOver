using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rocket : MonoBehaviour
{
    public Text txtRocketCount;
    public static bool createStatu = false;
    Rigidbody2D rigitBody;
    //float speed = 2.0f;
    public GameObject rocket_gost;
    public static int rocketCount = 100;
    public GameObject boomObj;
    public AudioClip boomSound;



    void Start()
    {
        rigitBody = GetComponent<Rigidbody2D>();
        //gameObject.SetActive(false);
        boomObj.SetActive(false);
    }



    void Update()
    {

        if (createStatu == false)
        {
            if (Input.GetKeyUp(KeyCode.Space) && rocketCount > 0)
            {
                rocketCount--;
                Debug.Log("Space call");
                //gameObject.SetActive(true);
                createStatu = true;
                //rigitBody.constraints = RigidbodyConstraints2D.FreezePositionX;
                //Instantiate(gameObject);
            }
        }

        //btn_rocket_fire();
        txtRocketCount.text = ""+rocketCount;
        if (createStatu == false)
        {
            transform.position = new Vector3(rocket_gost.transform.position.x, rocket_gost.transform.position.y, rocket_gost.transform.position.z);
            //Debug.Log("tetiklendi createStatu");
        }
    }




    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "gost_tag") {
            Invoke("deleteRocket", 0.0f);
        }


        if (obj.gameObject.tag == "meteor_tag") {
            //Debug.Log("çarpışma");
            meteor.rocket_live++;
            // puan artışı
            // meteor and roketi yok et
            //obj.gameObject.SetActive(false);
            meteor.liveCount = meteor.liveCount + 3;
            Destroy(obj.gameObject, 0.1f);
            //meteor.live--;
            //Instantiate(obj.gameObject);
            deleteRocket();
            AudioSource.PlayClipAtPoint(boomSound, transform.position);
            boomObj.SetActive(true);
            //Instantiate( boomObj, gameObject.transform.position, gameObject.transform.rotation);
            GameObject cloneBoomObj = (GameObject)Instantiate(boomObj, transform.position, Quaternion.identity);
            Destroy(cloneBoomObj, 1.0f);
        }
    }


    private void deleteRocket() {
        Destroy(gameObject, 0.1f);
        Instantiate(gameObject);
        createStatu = false;
        //Debug.Log("deleteRocket call");
        //transform.position = new Vector3(rocket_gost.transform.position.x, rocket_gost.transform.position.y, rocket_gost.transform.position.z);
    }

}

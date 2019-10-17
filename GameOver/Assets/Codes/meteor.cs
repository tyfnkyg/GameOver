using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{ 

    public static int rocket_live = 0;
    public static int live = 1;
    public static int liveCount = 0;
    //int i = 0;
    float random = 0f;
    float xRandom = 0f;
    float scale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Random ->
        random = Random.Range(1, 4);
        xRandom = Random.Range(-2.28f, 2.28f);
        scale = Random.Range(0.5f, 1.0f);
        transform.localScale = new Vector3(scale, scale, 1);
        transform.position = new Vector3(xRandom, 4.9f, -3);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Time.timeScale >= 1)
        {
            // Zamana göre animasyon
            //gameObject.SetActive(true);
            transform.Translate(0, -(random * Time.deltaTime), 0);

            /*
            i++;
            if (i == 200)
            {
                Invoke("fncCreate", 3.0f);
                i = 0;
            }
            */

            if (meteor.live < 5)
            {
                fncObjectCreate();
            }

            if ( meteor.rocket_live == 1 || meteor.rocket_live == 2)
            {
                fncObjectCreate();
                meteor.rocket_live = 0;
            }
        }
        
    }
    


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "bottom_tag")
        {
            //Debug.Log("Çarpışma gerçekleşti");
            meteor.liveCount++;
            // alt engel ile meteor çarpıştı
            fncObjectCreate();
            Invoke("fncObjectDeath", 0.0f);
        }
    }

    private void fncObjectCreate() {
        meteor.live++;
        Instantiate(gameObject); // yeni object oluştur
    }

    private void fncObjectDeath()
    {
        Destroy(gameObject, 0.0f); // eski objeyi öldür.
        meteor.live--;
    }

}

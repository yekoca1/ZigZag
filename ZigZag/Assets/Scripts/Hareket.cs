using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Hareket : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public float addSpeed;
    public Spawner spawner;
    public static bool fall;
    public GameObject restart;
    public GameObject quit;
    public GameObject next;
    public int lastPoint;
    public AudioSource back;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;


    void Start()
    {
        back = GameObject.Find("BackMusic").GetComponent<AudioSource>();
        Time.timeScale = 1;
        next.SetActive(false);
        restart.SetActive(false);
        quit.SetActive(false);
        fall = false;
        direction = Vector3.forward; //z ekseninde ileri doğru gider
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        control();
        if(transform.position.y <= 0)
        {
            fall = true;
        }

        if(fall == true)
        {
            back.Stop();
            restart.SetActive(true);
            quit.SetActive(true);
            loseText.gameObject.SetActive(true);
            return;  //fonksiyonu bitir aşağı inmesin
        }

       if(Input.GetMouseButtonDown(0))
       {
        speed += addSpeed*Time.deltaTime;

        if(direction.x == 0)
        {
            direction = Vector3.left;  //eğer ileri gidiyorsa soldan devam etsin
        }

        else{
            direction = Vector3.forward; //eğer soldan devam ediyorsa ilerden devam etsin
        }
       } 

    }

    void FixedUpdate()
    {
        Vector3 move = direction*Time.deltaTime*speed;
        transform.position += move;
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "zemin")
        {
            Skor.skor += 5;
            collision.gameObject.AddComponent<Rigidbody>();
            spawner.create();
            StartCoroutine(delete(collision.gameObject)); // oluşturulan coroutine yani IE yi çağırırken kullanılır 
        }
    }

    IEnumerator delete(GameObject deletedObject)  // zaman içeren fonksiyonların başında IE kullanılır
    {
        yield return new WaitForSeconds(3f);
        Destroy(deletedObject);
    }
    public void control()
    {
        if(Skor.skor == lastPoint)
        {
            back.Stop();
            Time.timeScale = 0;
            next.SetActive(true);
            quit.SetActive(true);
            winText.gameObject.SetActive(true);
        }
    }
    
}

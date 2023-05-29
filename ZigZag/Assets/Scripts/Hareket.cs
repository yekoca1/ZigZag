using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    Vector3 direction;
    public float speed;
    public float addSpeed;
    public Spawner spawner;
    public static bool fall;
    void Start()
    {
        fall = false;
        direction = Vector3.forward; //z ekseninde ileri doğru gider
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0)
        {
            fall = true;
        }

        if(fall == true)
        {
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
}

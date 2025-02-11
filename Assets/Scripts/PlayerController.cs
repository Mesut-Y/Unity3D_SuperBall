
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.DeviceSimulation;
#endif
using TouchPhase = UnityEngine.TouchPhase;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    CurrentDirection cr;
    public bool isPlayerDead;
    private GameManager gameManager; //Hierarchy GameManager nesnesini kullanmak için
    public ParticleSystem deadEffect; //instantiate yaparak efekt için

    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start çalıştı!");
        rb = GetComponent<Rigidbody>();
        cr = CurrentDirection.right;
        isPlayerDead = false;
        gameManager = FindObjectOfType<GameManager>(); //Hierarchy gamemanager nesnesi degiskene atandi.
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update çalıştı!");
        if (!isPlayerDead)
        {
            RayCastDedector(); //surekli zemin kotnrol olsun

            /*if (Input.GetKeyDown("space")) //pc icin
            {
                PlayerStop();
                ChangedDirection();
            }*/
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
            {
                //if (Input.GetTouch(0).phase == TouchPhase.Began) //mobil cihazlar için
                //{
                ChangedDirection();
                PlayerStop();
                    
                //}
            }
            else
                return;
        }
      
    }
    private void RayCastDedector()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit)) //zemin varsa hareket
        {
            MovePlayer();
        }
        else //zemin yoksa dur
        {
            PlayerStop();
            isPlayerDead= true; 
            this.gameObject.SetActive(false); // oyuncu false yapldý.
            gameManager.LevelEnd(); //tabana deðmeyince panel gözüksün.
            Instantiate(deadEffect, transform.position, Quaternion.identity); //nesne kaybolduðu anda efekt görünsün.
        }
    }

    private enum CurrentDirection
    {
        right,
        left
    }
    private void ChangedDirection()
    {
        MovePlayer();
        if (cr==CurrentDirection.right)
        {
            cr= CurrentDirection.left;
        }
        else if (cr==CurrentDirection.left)
        {
            cr= CurrentDirection.right;
        }
    }
    private void MovePlayer()
    {
        if (cr==CurrentDirection.left)
        {
            rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.right){
            rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    private void PlayerStop()
    {
        rb.velocity = Vector3.zero; //karakteri durdurup ters yöne göndermek için
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel(); // sonraki bölüm için ekran açýlýr.
            PlayerStop(); //öncedur sonra false
            this.gameObject.SetActive(false); // oyuncu false yapldý.
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArtFact : MonoBehaviour
{

    public int minScore, maxScore;
    private GameManager gameManager;
    public ParticleSystem collectEffect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Gamemanager objesi de�i�kene aktar�ld�. metod ve de�i�kenleri kullan�labilir.
    }

    private void Update()
    {
        transform.Rotate(180f * Time.deltaTime, 0f, 0f); //nesnenin kendi etraf�nda d�nmesini sa�lar.
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore, maxScore));
            collectEffect.Play();
            Destroy(this.gameObject,0.5f); // toplan�lan objenin yok olmas�, efektle yok olmas� i�in 0.5f delay ekledik.
        }
        
    }
}

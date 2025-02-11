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
        gameManager = FindObjectOfType<GameManager>(); // Gamemanager objesi deðiþkene aktarýldý. metod ve deðiþkenleri kullanýlabilir.
    }

    private void Update()
    {
        transform.Rotate(180f * Time.deltaTime, 0f, 0f); //nesnenin kendi etrafýnda dönmesini saðlar.
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.AddScore(Random.Range(minScore, maxScore));
            collectEffect.Play();
            Destroy(this.gameObject,0.5f); // toplanýlan objenin yok olmasý, efektle yok olmasý için 0.5f delay ekledik.
        }
        
    }
}

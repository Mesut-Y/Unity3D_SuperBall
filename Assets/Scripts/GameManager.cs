using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject LoseUI;
    public GameObject WinUI;

    public int score;

    public Text loseScoreText, winScoreText;  //UnityEngine.IU eklendi.
    public Text inGameScoreText; // oyun içi skor texti


    // Start is called before the first frame update
    void Start()
    {
        LoseUI.SetActive(false); // oyun basinda pasif
        WinUI.SetActive(false); // oyun basinda pasif
    }

    public void LevelEnd()
    {
        LoseUI.SetActive(true);
        loseScoreText.text = "Toplam Puan: " + score;
        inGameScoreText.gameObject.SetActive(false); // oyun bitince yazý kaybolsun.
    }

    public void WinLevel()
    {
        WinUI.SetActive(true);
        winScoreText.text = "Toplam Puan: " + score;
        inGameScoreText.gameObject.SetActive(false); // oyun bitince yazý kaybolsun.
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //var olan scene 1 arttýrýlýrak sonraki sahne açýlýr.
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        inGameScoreText.text= "Toplam Puan: " + score;
    }

    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // aktif sahneyi tekrar yükler
    }

    public void AppQuit()
    {
        Application.Quit(); // çýkýþ yapýlýr.
    }

}

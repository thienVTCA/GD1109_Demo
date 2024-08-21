using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager uIManagerInstance;
    int killedNumber = 0;
    [SerializeField]
    Text killedNumberText;
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    GameObject panelInGame, panelEndGame;
    // Start is called before the first frame update
    private void Awake()
    {
        uIManagerInstance = this;
    }
    void Start()
    {
        panelInGame.SetActive(true);
        panelEndGame.SetActive(false);
        killedNumber = 0;
        killedNumberText.text = "0";
    }

    public void UpdateEnemiesKilledNumber()
    {
        killedNumber++;
        killedNumberText.text = "" + killedNumber;
    }

    public void UpdatePlayerHealthSlider(float valueInput)
    {
        healthSlider.value = valueInput;
    }

    public void GameOver()
    {
        panelInGame.SetActive(false);
        panelEndGame.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

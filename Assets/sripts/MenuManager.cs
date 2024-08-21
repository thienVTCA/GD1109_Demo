using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject panelMainMenu, panelStartGame;
    [SerializeField]
    Slider sliderLoadSceneProcess;
    [SerializeField]
    Animator menuAnimator;
    // Start is called before the first frame update
    void Start()
    {
        panelMainMenu.SetActive(true);
        panelStartGame.SetActive(false);
    }

    public void StartGame()
    {
        //panelMainMenu.SetActive(false);
        //panelStartGame.SetActive(true);
        //SceneManager.LoadScene("GamePlay");
        StartCoroutine(IELoadSceneAsync());
    }

    IEnumerator IELoadSceneAsync()
    {
        menuAnimator.SetBool("StartGame", true);
        yield return new WaitForSeconds(1);
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GamePlay");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            sliderLoadSceneProcess.value = asyncLoad.progress;
            yield return new WaitForEndOfFrame();
        }
    }

    public void Setting()
    {

    }

    public void ChooseTheme()
    {

    }
}

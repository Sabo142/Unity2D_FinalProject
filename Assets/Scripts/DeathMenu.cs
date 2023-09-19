using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Image backgroundIMG;
    private bool isShown = false;
    private float transition = 0f;
    [SerializeField] private GameObject DeathMenuHolder;
    [SerializeField] private CanvasGroup canvasGroup;
    
    

    
    void Update()
    {

        if (!isShown)
        {
            return;
        }
        else
        {
            transition += Time.deltaTime;
            canvasGroup.alpha = transition/2;
        }
        
    }

    public void ToggleDeathMenu()
    {
        DeathMenuHolder.SetActive(true);
        isShown = true;
        
    }

    public void restart()
    {
        GameManager.Instance.SetGameState(GameState.Play);
        
        SceneManager.LoadScene("SampleScene");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

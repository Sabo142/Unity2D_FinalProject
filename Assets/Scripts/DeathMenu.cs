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
    
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    
    void Update()
    {

        if (!isShown)
        {
            return;
        }
        else
        {
            transition += Time.deltaTime;
            backgroundIMG.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
        }
        
    }

    public void ToggleDeathMenu()
    {
        gameObject.SetActive(true);
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

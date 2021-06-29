using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public static bool gameover = false;
    [SerializeField] GameObject painel;

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            painel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
    public void SairJogo()
    {
        Application.Quit();

    }
    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        painel.SetActive(false);
        gameover = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

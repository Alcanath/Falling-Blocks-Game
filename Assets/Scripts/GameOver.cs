using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour


{
    public GameObject gameUI;
    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    public Text bulletsLeftUI;
    public Text timer;
    bool gameOver;




    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerControler>().OnPlayerDeath += OnGameOver;

        }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene(0);
                }
        }
        if (!gameOver) {
            bulletsLeftUI.text = FindObjectOfType<PlayerControler>().bullets.ToString();
            timer.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
            }
        }

    void OnGameOver() {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;

        gameUI.SetActive(false);
        }
}

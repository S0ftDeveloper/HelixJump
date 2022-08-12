using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


    public class GameManager : MonoBehaviour
    {
        public static bool gameOver;
        public static bool levelCompleted;
        public static bool mute;
        public static bool isGameStarted;
        public GameObject GameOverPanel;
        public GameObject MainMenuPanel;
        public GameObject levelCompletedpanel;
        public GameObject GamePlaypanel;
        public GameObject StartMenupanel;
        public static int currentLevelIndex;
        public Slider gameProgressSlider;
        public TextMeshProUGUI currentLevelText;
        public TextMeshProUGUI nextLevelText;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highScoreText;
        public static int numberOfPassedRings;
        public static int score = 0;
  


        private void Awake()
        {
            
            currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);

        }
        private void Start()
        {
            
            

            isGameStarted = gameOver = levelCompleted = false;
            Time.timeScale = 1;
            numberOfPassedRings = 0;
            highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);


        }
        private void Update()
        {
            currentLevelText.text = currentLevelIndex.ToString();
            nextLevelText.text = (currentLevelIndex + 1).ToString();
            int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
            gameProgressSlider.value = progress;
            scoreText.text = score.ToString();
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    return;
                isGameStarted = true;
                GamePlaypanel.SetActive(true);
                StartMenupanel.SetActive(false);
            }
            if (gameOver)
            {
                Time.timeScale = 0;
                GamePlaypanel.SetActive(false);
                GameOverPanel.SetActive(true);

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (score > PlayerPrefs.GetInt("highScore", 0))
                    {
                        PlayerPrefs.SetInt("HighScore", score);
                    }
                    score = 0;
                    SceneManager.LoadScene("Level 1");
                }
            }
            if (levelCompleted)
            {

                levelCompletedpanel.SetActive(true);
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                    SceneManager.LoadScene("Level 1");
                }
            }


        }
   }

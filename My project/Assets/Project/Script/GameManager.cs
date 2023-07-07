using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverUi = default;
    public Text scoreText = default;
    public Text recordText = default;
    public Text playerHpT = default;
    PlayerController controller;

    public float score = default;
    private bool isGameOver = default;
    public GameManager healthModel;
    // 오디오 소스 생성해서 추가
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.mute = false;

// 루핑: true일 경우 반복 재생
    audioSource.loop = false;

// 자동 재생: true일 경우 자동 재생
    audioSource.playOnAwake = true;
        score = 0;
        isGameOver = false;
        controller = GameObject.FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.Play();
        if (isGameOver == false)
        {
            
            scoreText.text="SCORE :" + score;
            playerHpT.text = "HP :" + controller.playerHp;
            //timeText.text = string.Format("Time : {0}", (int)surviveTime);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("SampleScene");

            }
        }

    }
    public void EndGame()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        float highScore = PlayerPrefs.GetFloat("HighScore");

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        recordText.text="highscore :"+highScore;
        //recordText.text = string.Format("Best Time : {0}", (int)bestTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform pauseScreen = null;
    public bool isPaused = false;
    public Transform bunny;
    public Transform min;
    public Transform max;
    float minx, minz, maxx, maxz, y;
    float timer = 0f;
	float maxtime = .5f;
    float timerS = 0f;
    public float score = 1320f;
    public float maxPlantScore = 0f;
    public TextMeshProUGUI time;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI remainingPlants;
    float seconds = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        minx = min.transform.position.x;
        minz = min.transform.position.z;
        maxx = max.transform.position.x;
        maxz = max.transform.position.z;
        y = min.transform.position.y;
        Time.timeScale = 1f;
        pauseScreen.gameObject.SetActive(false);
        time.SetText("Time: " + 0);
        scoreText.SetText("Score: " + score);
        remainingPlants.SetText("Remaining Plants: " + maxPlantScore/20 + " " + 1320/20);
    }

    // Update is called once per frame
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused) //&& !player.GetComponent<PlayerController>().victory && !player.GetComponent<PlayerController>().truevictory && !player.GetComponent<PlayerController>().crashed)
        Pause();
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)// && !player.GetComponent<PlayerController>().victory && !player.GetComponent<PlayerController>().truevictory && !player.GetComponent<PlayerController>().crashed)
        UnPause();
        if(timer <= 0f){
			timer = maxtime;
			Instantiate(bunny,new Vector3(UnityEngine.Random.Range(minx,maxx),y,UnityEngine.Random.Range(minz,maxz)), Quaternion.Euler(0, UnityEngine.Random.Range(0, 4) * 90, 0));
		}else{
			timer -= Time.deltaTime;
		}
        seconds += Time.deltaTime;
        time.SetText("Time: " + Math.Round(seconds,2));
        scoreText.SetText("Score: " + score);
        remainingPlants.SetText("Remaining Plants: " + maxPlantScore/20 + " / " + 1320/20);
    }
    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        pauseScreen.gameObject.SetActive(true); //turn on the pause menu
        Time.timeScale = 0f; //pause the game
    }

    public void UnPause()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        pauseScreen.gameObject.SetActive(false); //turn off pause menu
        Time.timeScale = 1f; //resume game
    }

    // public void dispLoss(){
    //     Cursor.visible = true;
    //     Cursor.lockState = CursorLockMode.None;
    //     VictoryScreen.gameObject.SetActive(true);
    //     Time.timeScale = 0f;
    // }    
    public void QuitToMainScreen(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Garden");
        Time.timeScale = 1f;
    }
}

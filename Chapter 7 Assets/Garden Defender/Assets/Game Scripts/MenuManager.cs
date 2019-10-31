using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Transform Instructions = null;
    // Start is called before the first frame update
    void Start()
    {   
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Instructions.localScale = new Vector3(0,0,0);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(){
        SceneManager.LoadScene("Garden");
        Time.timeScale = 1f;
    }
    public void GetInstructions(){
        Instructions.localScale = new Vector3(1,1,1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoBack(){
        Instructions.localScale = new Vector3(0,0,0);
    }
}
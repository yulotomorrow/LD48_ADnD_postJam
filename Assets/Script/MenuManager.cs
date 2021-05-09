using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitGame() { 

        Application.Quit();
        //Debug.Log("Quit");
    
    }

    public void GotoStart()
    {

        SceneManager.LoadScene("Title_v2", LoadSceneMode.Single);
    }

    public void GotoEnd()
    {

        SceneManager.LoadScene("EndingScreen_success", LoadSceneMode.Single);
    }

    public void StartGame()
    {

        SceneManager.LoadScene("Scene1_castle", LoadSceneMode.Single);
        //BreadCounter.counterNum = 0;
        //Feed.hungryTime = 0;
        //HungryText.textCounter = 0;
    }

    public void StartGameFromTutorial()
    {
       
        SceneManager.LoadScene("Plot", LoadSceneMode.Single);
       // BreadCounter.counterNum = 0;
       // Feed.hungryTime = 0;
       // HungryText.textCounter = 0;
    }

    public void GotoGame()
    {

        SceneManager.LoadScene("BreadBakingV2", LoadSceneMode.Single);
    }

    public void GotoTutorial()
    {

        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }



}

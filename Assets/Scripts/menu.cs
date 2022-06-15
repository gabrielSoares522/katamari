using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public Transform menuScreen;
    public Transform gameScreen;
    public Transform stickBall;
    public Transform gameCamera;

    private int screenIndex = 0;
    private const int MENU_INDEX = 0;
    private const int GAME_INDEX = 1;
    private const int END_INDEX = 2;
    
    public void startGame()
    {
        OpenScreen(GAME_INDEX);
    }

    public void OpenScreen(int index)
    {
        screenIndex = index;
        switch (screenIndex)
        {
            case(MENU_INDEX):
                menuScreen.gameObject.SetActive(true);
                gameScreen.gameObject.SetActive(false);
                stickBall.GetComponent<stickBall>().enabled = false;
                gameCamera.gameObject.SetActive(false);

                break;            
            case(GAME_INDEX):
                menuScreen.gameObject.SetActive(false);
                gameScreen.gameObject.SetActive(true);
                stickBall.GetComponent<stickBall>().enabled = true;
                gameCamera.gameObject.SetActive(true);
                transform.GetComponent<Camera>().enabled = false;
                break;
            default:
                menuScreen.gameObject.SetActive(true);
                gameScreen.gameObject.SetActive(false);
                stickBall.GetComponent<stickBall>().enabled = false;
                gameCamera.gameObject.SetActive(false);
                break;
        }
    }

    void Start()
    {
        OpenScreen(MENU_INDEX);
    }
}

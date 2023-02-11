using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void Exit(){
        Application.Quit();
    }

    public void OpenPlay(){
        SceneManager.LoadScene("Chess");
    }

    public void OpenInventory(){
        SceneManager.LoadScene("Inventory");
    }

    public void OpenSelection(){
        SceneManager.LoadScene("Selection");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    
}

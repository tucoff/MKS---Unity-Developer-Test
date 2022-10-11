using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostDeathController : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

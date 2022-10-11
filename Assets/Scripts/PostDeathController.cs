using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PostDeathController : MonoBehaviour
{
    public void Update() 
    {
        transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = 
        GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>().text;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGameDuraction : MonoBehaviour
{
    public void ChangeTimeDuraction()
    {
        PlayerPrefs.SetFloat("Time", transform.GetComponent<Slider>().value);
    }

    public void ChangeSpawnFrequency()
    {
        PlayerPrefs.SetFloat("SpawnTime", transform.GetComponent<Slider>().value);
    }
}

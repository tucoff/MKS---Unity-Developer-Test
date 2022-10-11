using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBeetweenSpawn = 1;
    [SerializeField] GameObject shooterBoat;
    [SerializeField] GameObject chaserBoat;
    [SerializeField] float spawnRange = 0;

    void Start()
    {
        StartCoroutine("TimerToSpawn");
        timeBeetweenSpawn = PlayerPrefs.GetFloat("SpawnTime");
    }

    void Spawn()
    {
        transform.Translate(Vector2.zero);
        transform.Translate(new Vector2(Random.Range(-3f, 3f)*spawnRange,Random.Range(-2f,2f)*spawnRange));

        if(Random.Range(0f, 100f) > 50f) { GameObject.Instantiate(chaserBoat, this.transform.position, this.transform.rotation, null); }
        else { GameObject.Instantiate(shooterBoat, this.transform.position, this.transform.rotation, null); }
        
        StartCoroutine("TimerToSpawn");
    }

    IEnumerator TimerToSpawn()
    {
        yield return new WaitForSeconds(timeBeetweenSpawn);
        if(GameObject.FindGameObjectWithTag("Player") && GameObject.FindGameObjectWithTag("GameController").GetComponent<CanvasController>().TimeLeft > 0){ Spawn(); }
    }
}

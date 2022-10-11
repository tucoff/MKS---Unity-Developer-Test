using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatLifeContoller : MonoBehaviour
{
    [SerializeField] int healthPoints = 3;
    [SerializeField] Sprite[] boatSprites;
    [SerializeField] GameObject deadBoat;

    public void Damage(int n)
    {
        healthPoints-=n;
        if(healthPoints < 0) { healthPoints = 0; }
        
        this.gameObject.GetComponent<SpriteRenderer>().sprite = boatSprites[healthPoints];

        switch(healthPoints)
        {
            case 2:
                transform.GetChild(3).gameObject.SetActive(false);
            break;
            
            case 1:
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
            break;

            case 0:
                transform.GetChild(3).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
            break;
        }

        if(healthPoints <= 0)
        {
            if(this.gameObject.tag == "Enemy" && GameObject.FindGameObjectWithTag("Player")) 
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCounter>().AddScore();
            }
            
            if(this.gameObject.tag == "Player") { GameObject.FindGameObjectWithTag("DeathMenu").transform.GetChild(0).gameObject.SetActive(true); }

            deadBoat.GetComponent<SpriteRenderer>().sprite = boatSprites[0];
            GameObject.Instantiate(deadBoat,this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }

}

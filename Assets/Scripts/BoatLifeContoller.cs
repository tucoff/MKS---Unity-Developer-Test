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
        
        this.gameObject.GetComponent<SpriteRenderer>().sprite = boatSprites[healthPoints];

        if(healthPoints <= 0)
        {
            //Lose
            deadBoat.GetComponent<SpriteRenderer>().sprite = boatSprites[0];
            GameObject.Instantiate(deadBoat,this.transform.position, this.transform.rotation);

            Destroy(this.gameObject);
        }
    }

}

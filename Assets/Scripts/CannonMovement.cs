using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{

    [SerializeField] float cannonSpeed = 1;

    void Start() { Destroy(this.gameObject, 10f); if(transform.parent != null){ Destroy(this.transform.parent.gameObject, 10f); } }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.GetChild(0).position, cannonSpeed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if((this.gameObject.tag == "CannonBall" && col.gameObject.tag == "Enemy") || (this.gameObject.tag == "EnemyCannonBall" && col.gameObject.tag == "Player"))
        {
            col.gameObject.GetComponent<BoatLifeContoller>().Damage(1);
            Destroy(this.gameObject);
        }
    }
}

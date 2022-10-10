using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserMovement : MonoBehaviour
{
    [SerializeField] float chaserSpeed = 1;
    [SerializeField] GameObject ExplosionGIF;
    private Vector2 targetPos;
    private Vector2 auxPos;
    private Vector2 thisPos;
    private float angle;

    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {    
            Movement();
            Rotation();
        }
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, chaserSpeed*Time.deltaTime);
    }

    void Rotation()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        thisPos = transform.position;
        auxPos.x = targetPos.x - thisPos.x;
        auxPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(auxPos.y, auxPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameObject.Instantiate(ExplosionGIF, transform.position, transform.rotation, transform.parent);
            col.gameObject.GetComponent<BoatLifeContoller>().Damage(2);            
            this.gameObject.GetComponent<BoatLifeContoller>().Damage(3);
        }
    }
}

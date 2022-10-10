using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{

    [SerializeField] float playerSpeed;
    [SerializeField] GameObject cannonBall;
    [SerializeField] GameObject tripleCannon;
    [SerializeField] float cdFrontalShot;
    [SerializeField] float cdSideShots;
    bool canShoot = true;
    bool canTripleShoot1 = true;
    bool canTripleShoot2 = true;

    void FixedUpdate()
    {
        Movement();
        FrontalShot();
        SideShot();
    }

    void Movement() 
    {
        
        float vInput = Input.GetAxis("Vertical");
     
        if(vInput >= 0) { transform.position = Vector2.MoveTowards(transform.position, transform.GetChild(0).position, vInput*playerSpeed*Time.deltaTime); }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.parent.RotateAround(this.transform.position, Vector3.forward, 100*Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.parent.RotateAround(this.transform.position, -Vector3.forward, 100*Time.deltaTime);
        } 

    }

    void FrontalShot()
    {
        if(Input.GetKey(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            GameObject.Instantiate(cannonBall,transform.position, Quaternion.Euler(0f,0f,180f+transform.parent.eulerAngles.z));
            StartCoroutine(CooldownFS());
        }
    }

    IEnumerator CooldownFS()
    {
        yield return new WaitForSeconds(cdFrontalShot);
        canShoot = true;
    }

    void SideShot()
    {
        if(Input.GetKey(KeyCode.Q) && canTripleShoot1)
        {
            canTripleShoot1 = false;
            GameObject.Instantiate(tripleCannon,transform.position, Quaternion.Euler(0f,0f,270f+transform.parent.eulerAngles.z));
            StartCoroutine(CooldownTS1());
        }
        
        if(Input.GetKey(KeyCode.E) && canTripleShoot2)
        {
            canTripleShoot2 = false;
            GameObject.Instantiate(tripleCannon,transform.position, Quaternion.Euler(0f,0f,90f+transform.parent.eulerAngles.z));
            StartCoroutine(CooldownTS2());
        }

    }

    IEnumerator CooldownTS1()
    {
        yield return new WaitForSeconds(cdSideShots);
        canTripleShoot1 = true;
    }

    IEnumerator CooldownTS2()
    {
        yield return new WaitForSeconds(cdSideShots);
        canTripleShoot2 = true;
    }
}

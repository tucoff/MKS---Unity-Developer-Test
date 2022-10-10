using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterMovement : MonoBehaviour
{
    
    [SerializeField] float requiredDistance;
    [SerializeField] float cdShot;
    [SerializeField] float shooterSpeed;
    [SerializeField] GameObject cannonBall;
    private Vector2 targetPos;
    private Vector2 auxPos;
    private Vector2 thisPos;
    private float angle;
    bool canShoot = true;

    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Player"))
        {    
            Rotation();
            Movement();
            FrontalShot();
        }
    }

    void Movement()
    {
        if(Vector2.Distance(thisPos, targetPos) > requiredDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, shooterSpeed*Time.deltaTime);
        }
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

    void FrontalShot()
    {
        if(GameObject.FindGameObjectsWithTag("Player") != null && Vector2.Distance(thisPos, targetPos) <= requiredDistance && canShoot)
        {
            canShoot = false;
            GameObject.Instantiate(cannonBall, transform.position, Quaternion.Euler(0f,0f,180f+transform.eulerAngles.z));
            StartCoroutine(CooldownFS());
        }
    }

    IEnumerator CooldownFS()
    {
        yield return new WaitForSeconds(cdShot);
        canShoot = true;
    }
}

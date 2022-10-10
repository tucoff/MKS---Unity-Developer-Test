using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadObjectDisappear : MonoBehaviour
{
    float n = 100f;
    void Start() { Destroy(this.gameObject, 5f); }
    void FixedUpdate()
    {
        this.transform.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,n/100f); 
        n--;
    }
}

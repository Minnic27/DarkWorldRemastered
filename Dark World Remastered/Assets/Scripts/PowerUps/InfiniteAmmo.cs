using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteAmmo : MonoBehaviour
{
    
    public GunAR arScript;
    private GunSMG smgScript;
    private GunSG sgScript;
    private GunPistol pistolScript;


    // Start is called before the first frame update
    void Start()
    {
        arScript = GameObject.FindObjectOfType<GunAR>();
        smgScript = GameObject.FindObjectOfType<GunSMG>();
        sgScript = GameObject.FindObjectOfType<GunSG>();
        pistolScript = GameObject.FindObjectOfType<GunPistol>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Infinite Ammo");
            arScript.infinitebullet = true;
            //Destroy(other.gameObject);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private GameUI uiScript;

    void Start()
    {
        uiScript = GameObject.FindObjectOfType<GameUI>();
    }


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Restore Health");

            if(uiScript.playerHealth < 100) 
            {
                uiScript.playerHealth += 20;
                uiScript.healthUI.text = "" + uiScript.playerHealth + "%";
            }
            else
            {
                uiScript.playerHealth = 100;
                uiScript.healthUI.text = "" + uiScript.playerHealth + "%";
            }
            
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}

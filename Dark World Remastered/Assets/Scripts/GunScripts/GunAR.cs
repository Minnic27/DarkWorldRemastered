using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunAR : MonoBehaviour
{
    public int damage = 20;
    private float range = 100f;
    public int ammo = 20;

    private float fireRate = 6f;
    
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public Camera tpsCam;
    
    private float nextTimeToFire = 0f;
    public PlayerController playerScript;
    private GameUI uiScript;

    public bool infinitebullet = false;

    void Start()
    {
        uiScript = GameObject.FindObjectOfType<GameUI>();
        uiScript.ammoUI.text = ammo + "/20";

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            
            if(!playerScript.isRunning)
            {
                if(ammo <= 0)
                {
                    uiScript.ammoUI.text = "'R' to Reload";
                }
                else
                {
                    if(infinitebullet == true)
                    {
                        InfiniteAmmo();
                    }
                    else
                    {
                        Shoot();
                    }
                    
                }
                
            }
        }

        GunReload();
    }

    void Shoot()
    {
        muzzleFlash.Play();
        SoundManager.PlaySound("AR1");
        RaycastHit hit;
        
        if(Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyBehavior target = hit.transform.GetComponent<EnemyBehavior>();
            GreaterDemonBehavior target2 = hit.transform.GetComponent<GreaterDemonBehavior>();
            AswangBehavior target3 = hit.transform.GetComponent<AswangBehavior>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }
            else if(target2 != null)
            {
                target2.TakeDamage(damage);
            }
            else if(target3 != null)
            {
                target3.TakeDamage(damage);
            }
        }

        GameObject bulletImpact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bulletImpact, 0.5f);
        ammo--;
        uiScript.ammoUI.text = ammo + "/20";
    }

    public void GunReload()
    {
        if ((Input.GetKey(KeyCode.R)) && (ammo == 0)) // checks if gun is out of ammo
        {
            ammo = 20;
            uiScript.ammoUI.text = ammo + "/20";
            SoundManager.PlaySound("Reload");
        }
    }

    void InfiniteAmmo()
    {
        muzzleFlash.Play();
        SoundManager.PlaySound("AR1");
        RaycastHit hit;
        
        if(Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyBehavior target = hit.transform.GetComponent<EnemyBehavior>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }

        GameObject bulletImpact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bulletImpact, 0.5f);
    }

}

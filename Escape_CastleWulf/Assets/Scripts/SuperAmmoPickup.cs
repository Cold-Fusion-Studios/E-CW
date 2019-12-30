﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAmmoPickup : MonoBehaviour {
    void Update ()
    {
        FaceTarget();
    }

    void OnTriggerEnter(Collider other)
    {
        //  Debug.Log("Collision");
        if (other.gameObject.tag == "Player")
        {
            if (KnifeAnimation.ammoMinigun < 1000 || KnifeAnimation.ammoMP < 500 || KnifeAnimation.ammoPistol < 100)
            {
                Debug.Log("Ammo Taken");

                KnifeAnimation.ammoMinigun += 1000;
                KnifeAnimation.ammoMP += 500;
                KnifeAnimation.ammoPistol += 100;
                KnifeAnimation.Ammo();


                this.gameObject.SetActive(false);
            }
        }
    }
    void FaceTarget()
    {
        Transform target = PlayerManager.instance.player.transform;
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
}

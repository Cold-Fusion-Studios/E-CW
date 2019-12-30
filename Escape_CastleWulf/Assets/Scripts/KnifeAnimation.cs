using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour {
    public Camera camera;
    public float range = 1f;
    public static float health = 200;
    public float fireRate = 15f;
    public static int ammoOut;
    public static float ammoMP;
    public static float ammoMinigun;
    public static float ammoPistol;
    public static bool mpFull;
    public static bool minigunFull;
    public static bool pistolFull;
    bool minigunFiring;
    //  private float nextTimeToFire = 0f;
    float damage;
    static int x = 1;
    static bool firing;
    int y;
    private EnemyAnimations MP40target;
    // Update is called once per frame
    static Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();

        Knife();
        firing = false;
        y = 0;
        ammoMP = 500;
        ammoMinigun = 1000;
        ammoPistol = 10;
        ammoOut = 1000000;
    }
    void Update () {
                Ammo();
                Health();
        if (health > 0)
        {
            if (Input.GetButtonDown("Fire1") && (x == 3) && ammoMinigun > 0)
            {
                anim.SetBool("MinigunHeldDown", true);
                //  ammoOut = (int)ammoMinigun / 5;
                //    Debug.Log("Minigun");
                MP40Start();
                RaycastHit hit;
                //If statement if we hit something
                if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 200))
                {
                    EnemyAnimations target = hit.transform.GetComponent<EnemyAnimations>();
                    MP40(target);
                }
                minigunFiring = true;

            }

            if (Input.GetKey("mouse 0") && minigunFiring && ((ammoMinigun > 0 && x == 3) || (x == 4 && ammoMP > 0)))
            {
                anim.SetBool("MinigunHeldDown", true);
                RaycastHit hit;
                //If statement if we hit something
                if (x == 3)
                {
                    if (ammoMinigun > 0)
                    {
                        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 200))
                        {
                            EnemyAnimations target = hit.transform.GetComponent<EnemyAnimations>();
                            MP40(target);
                        }
                    }
                }
                else if (x == 4)
                {
                    if (ammoMP > 0)
                    {
                        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 200))
                        {
                            EnemyAnimations target = hit.transform.GetComponent<EnemyAnimations>();
                            Minigun(target);
                        }
                    }
                }
            }



            /////



            if (Input.GetKey("mouse 0") && (x == 4) && ammoMP > 0)
            {
                anim.SetBool("MinigunHeldDown", true);
                //   Debug.Log("Minigun");
                //  ammoOut = (int)ammoMinigun / 5;
                MinigunStart();
                RaycastHit hit;
                //If statement if we hit something
                if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 200))
                {
                    EnemyAnimations target = hit.transform.GetComponent<EnemyAnimations>();
                    Minigun(target);
                }
                minigunFiring = true;

            }

            //     if(Input.GetKey("mouse 0") && minigunFiring && ammoMP > 0)
            {
                //     anim.SetBool("MinigunHeldDown", true);
                //      RaycastHit hit;
                // /     //If statement if we hit something
                //      if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 200))
                {
                    //         EnemyAnimations target = hit.transform.GetComponent<EnemyAnimations>();
                    //         Minigun(target);
                }
            }

            if (Input.GetButtonUp("Fire1"))
            {
                //  ammoOut = (int)ammoMinigun / 5;
                anim.SetBool("MinigunHeldDown", false);
                minigunFiring = false;
                anim.SetTrigger("MinigunStopFiring");
                anim.SetTrigger("MP40StopFiring");
            }








            if (Input.GetKeyDown("2") && firing == false)
            {
                ammoOut = (int)ammoPistol;
                firing = false;
                x = 2;
                //   Debug.Log("Pistol");
                //    Animator anim = GetComponent<Animator>();
                anim.SetTrigger("SwitchPistol");

            }

            if (Input.GetKeyDown("4") && firing == false)
            {
                ammoOut = (int)ammoMP / 5;
                x = 3;
                //     Debug.Log("MP40");
                //    Animator anim = GetComponent<Animator>();
                anim.SetTrigger("SwitchMP40");

            }

            if (Input.GetKeyDown("3") && firing == false)
            {
                ammoOut = (int)ammoMinigun / 10;
                firing = false;
                x = 4;
                //    Debug.Log("Minigun");
                //    Animator anim = GetComponent<Animator>();
                anim.SetTrigger("SwitchMinigun");


            }

            if (Input.GetKeyDown("1") && firing == false)
            {
                ammoOut = 1000000;
                //1 million
                firing = false;
                x = 1;
                //    Debug.Log("Knife");
                //   Animator anim = GetComponent<Animator>();
                anim.SetTrigger("SwitchKnife");

            }
            if (Input.GetButtonDown("Fire1") && x == 2 && ammoPistol > 0)
            {
                ammoPistol--;
                //  damage = 60;
                //  range = 15;
                Gun();
            }


            if (Input.GetButtonDown("Fire1") && x == 1)
            {
                //   damage = 30;
                //   range = 1;
                Knife();
            }
        }

    }

    void Health()
    {
        if (health <= 0)
        {
            health = 0;
            PlayerManager.EndGame();
        }
    }


    void MP40Start()
    {   
      //  Animator anim = GetComponent<Animator>();
        anim.SetTrigger("ToKnife");
    }

    void MinigunStart()
    {
      //  Animator anim = GetComponent<Animator>();
        anim.SetTrigger("ToKnife");
    }




    void Knife()
    {
        damage = 500/1.5f;
        range = 10;
    //    Animator anim = GetComponent<Animator>();
            anim.SetTrigger("ToKnife");
            RaycastHit hit;
            //If statement if we hit something
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
            {
             //   Debug.Log(hit.transform.name);

                EnemyAnimations target = hit.transform.GetComponent<EnemyAnimations>();

             y++;


            if (target != null)
            {
                if (y % 2 == 0)
                {
                    //  Debug.Log("Can damage");
                    target.takeDamage(damage * Random.Range(0.5f, 1.5f));
                }
            }
            }
        }
    
   public static void Ammo()
    {   //Overload management
        if (ammoMinigun > 1000)
        {
            ammoMinigun = 1000;
            minigunFull = true;
        }
        else
        {
            minigunFull = false;
        }

        if (ammoMP > 500)
        {
            ammoMP = 500;
            mpFull = true;
        }

        else
        {
            mpFull = false;
        }

        if (ammoPistol > 100)
        {
            ammoPistol = 100;

            pistolFull = true;

        }

        else
        {
            pistolFull = false;
        }

        if (x == 1)
        {
            ammoOut = 1000000;
        }
        else if (x == 2)
        {
            ammoOut = (int) ammoPistol;
        }
        else if (x == 3)
        {
            ammoOut = (int)ammoMinigun / 10;
        }
        else if (x == 4)
        {
            ammoOut = (int)ammoMP / 5;
        }
       
        //Refuse Pickup on Overload

        if(ammoMinigun <= 0)
        {
       
         //       Animator anim = GetComponent<Animator>();
            anim.SetTrigger("MP40StopFiring");
            anim.SetBool("MinigunHeldDown", false);
            firing = false;
                
        }

        if (ammoMP <= 0)
        {

         //   Animator anim = GetComponent<Animator>();
            anim.SetTrigger("MinigunStopFiring");
            anim.SetBool("MinigunHeldDown", false);
            firing = false;

        }




    }

    void Gun()
    {
        damage = 400;
        range = 100;
      //  Animator anim = GetComponent<Animator>();
            anim.SetTrigger("ToKnife");
            RaycastHit hit;
            //If statement if we hit something
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 100))
            {
            //    Debug.Log(hit.transform.name);

                EnemyAnimations target = hit.transform.GetComponent<EnemyAnimations>();
            y++;


            if (target != null)
            {
            //    if (y % 2 == 0)
                {
                    //  Debug.Log("Can damage");
                    target.takeDamage(400 * Random.Range(0.5f, 1.5f));
                }
            }


        }

    }
    void MP40(EnemyAnimations meme)
    {
        damage = 150;
        range = 100;

        
        //If statement if we hit something

        y++;

        if (ammoMinigun <= 0)
        { //      Animator anim = GetComponent<Animator>();
            anim.SetTrigger("MinigunStopFiring");
            firing = false;
        }
        else
        {
            //Debug.Log("Can damage");
            if (y % 2 == 0)
            {
                ammoMinigun--;
                ammoMinigun--;
                ammoMinigun--;
              
            
                if (meme != null)

                {
                    meme.takeDamage(150 * Random.Range(0.5f, 1.5f));
                }
            }
        }
            
            }

    void Minigun(EnemyAnimations meme)
    {
        damage = 250;
        range = 70;


        //If statement if we hit something
     //   Debug.Log("Minigun");
        y++;
        if (ammoMP <= 0)
        {
       //     Animator anim = GetComponent<Animator>();
            anim.SetTrigger("MP40StopFiring");
            firing = false;

        }
       else{
           
           

                // Debug.Log("Can damage");
                if (y % 8 == 0)
                {
                    ammoMP--;
                    ammoMP--;
                    ammoMP--;
                  if (meme != null)
                {
                    meme.takeDamage(damage * Random.Range(0.5f, 1.5f));
                }
            }
        }


    }


    public static void takeDamage(float damage)
    {
        health -=  damage;
  //     Debug.Log("Your Health is: " + health);
    }
}

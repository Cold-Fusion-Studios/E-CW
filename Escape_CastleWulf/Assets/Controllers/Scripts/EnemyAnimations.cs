using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.UI;
public class EnemyAnimations : MonoBehaviour {
    public Transform sprite;
    public int toWalk = 0;
    Collider m_Collider;
    public float lookRadius;
    Transform target;
    NavMeshAgent agent;
    public Animator animator;
    public  float health;
    bool alive = true;
    public int x = 0;
    public int y;
    bool firing = false;
    public float stoppingDistance;
    public float stopDistance;
    float distance;
    bool anotherLife = false;
    public Slider memes;
    public int damage;
    // Use this for initialization
    void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        FaceTarget();
        sprite = GetComponent<Transform>();
        stoppingDistance = agent.stoppingDistance * Random.Range(1f, 2.4f);
        if(y == 1)
        {
            damage = 25;
            stoppingDistance = 20;
            memes.value = health;
        }
           stopDistance = lookRadius + 7;

        if(damage == 15)
        {
            lookRadius = 30;
            stoppingDistance = 15;
            stopDistance = 13;
        }
         }






    void Update() {

        if(y == 1)
        {
            damage = 25;
            memes.value = health;
            

        }

        if(y == 2)
        {
            damage = 50;
            memes.value = health;
        }


        if(anotherLife)
        {
            damage = 20;
            anotherLife = false;
            y = 2;
            stoppingDistance = 15;
        }

        FaceTarget();
      //  Debug.Log(firing);
        distance = Vector3.Distance(target.position, transform.position);

        //First check if within lookradius
        //If not, do ToIdle

        if(health <= 0)
        {
            ToDie();
        }

       else if (distance > lookRadius)
        {
            ToIdle();
        }
        else if (distance < lookRadius)
        {
            ToAnimate();
        }
        if(!alive)
        {
          //  agent.SetDestination(sprite.position);
        }

}

    void ToAnimate()
    {
        //Know I'm within look radius
        if(distance < stoppingDistance)
        {
            ToAttack();
        }

        else if (distance > stoppingDistance+5)
        {
            ToWalk();
        }

    }

    void ToIdle()
    {
        firing = false;
        agent.SetDestination(sprite.position);
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("ToIdle");
    }

    void ToAttack()
    {
        if(distance > lookRadius)
        {
            ToIdle();
        }
        //Am shooting now
        firing = true;

        agent.SetDestination(sprite.position);
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("ToAttack");

        x++;

        

            //    Debug.Log("Attack sent!");
            RaycastHit hit;
            //If statement if we hit something
            if (Physics.Raycast(sprite.transform.position, sprite.transform.forward, out hit, 200))
            {
                //   Debug.Log("All before");
                Transform meme = hit.transform;
                if (meme.gameObject.tag == "Player")
                {
                if (x % 50 == 0)
                {
                    //     Debug.Log("BEFORE");
                    KnifeAnimation.takeDamage(damage * Random.Range(0.5f, 1.5f));
                    //    Debug.Log("Attack");
                    x = 0;
                }
            }
        }

        else if (y == 2 || y == 1)
        {
          
                RaycastHit hits;
                //If statement if we hit something
                if (Physics.Raycast(sprite.transform.position, sprite.transform.forward, out hits, 200))
                {
                    //    Debug.Log("All before");
                    Transform meme = hits.transform;
                    if (meme.gameObject.tag == "Player")
                {
                    if (x % 30 == 0)
                    {
                        //   Debug.Log("BEFORE");
                        KnifeAnimation.takeDamage(damage * Random.Range(0.5f, 1.5f));
                        //   Debug.Log("Attack");
                        x = 0;
                    }
                }
            }
        }

        
    }

    void ToWalk()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("ToWalk");
        agent.SetDestination(target.position);
        firing = false;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

    }

    public void takeDamage(float damage1)
    {
        health -= damage1;
     //   Debug.Log("Damage is: " + damage1);
       //   Debug.Log(health);
        //  ToIdle();
        if (health <= 0)
        {
            agent.SetDestination(sprite.position);

            ToDie();
           
            
        }
        firing = false;
    }

    public void ToDie()
    {
        //     agent.SetDestination(sprite.position);
        firing = false;
        // Debug.Log("Dead!");
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("ToDie");
        m_Collider = GetComponent<Collider>();
        alive = false;
        m_Collider.enabled = false;
        agent.enabled = false;
        if(y == 2)
        {
           // transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);

    }


 /*


        if(distance > lookRadius)
        {
            firing = false;
          //  ToIdle();
        }
        if(distance > stopDistance)
        {
            ToIdle();
        }

        
        if(health <= 0)
        {
            ToDie();
        }
      
        if (distance < lookRadius && !firing)
        {
            if(distance > stoppingDistance)
          ToWalk();

        }

        else if (distance > lookRadius && firing)
        {
            ToIdle();

        }
        if (distance <= lookRadius)
        {
            //x++;

            //   if (toWalk == 0)
            // {// toWalk = 1; }


            if (alive)
            {
                if (!firing)
                {
                    agent.SetDestination(target.position);
                }


                if (distance < stoppingDistance)
                {
                    toAttack();
                }
            }
        }
        else
        {


            // if (toWalk == 2)
            //     toWalk = 3;
        }

           
           if (toWalk == 3)
            {
             //   ToIdle();
            }

            if (health <= 0)
            {
                ToDie();
            }
        }
	

 //   void toAttack()
    {
        
        

       
    }


  //  void ToWalk()
    {

        
    }

 //   void ToIdle()
    {
        
    }*/

   
}

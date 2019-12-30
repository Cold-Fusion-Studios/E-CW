using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthGive;

    private void Update()
    {
        FaceTarget();
    }


    void OnTriggerEnter(Collider other)
    {
        //  Debug.Log("Collision");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Aid taken");

            if (KnifeAnimation.health < 200)
            {
                if (KnifeAnimation.health + healthGive <= 200)
                {
                    KnifeAnimation.health += healthGive;

                    this.gameObject.SetActive(false);
                }

                else if (KnifeAnimation.health + healthGive > 200 && KnifeAnimation.health < 200)
                {
                    KnifeAnimation.health = 200;
                    this.gameObject.SetActive(false);
                }
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
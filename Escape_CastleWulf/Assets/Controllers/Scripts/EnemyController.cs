using UnityEngine;
using UnityEngine.Animations;
public class EnemyController : MonoBehaviour
{
    public Transform sprite;

    private void Update()
    {
       // transform.position = sprite.position;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 20);
       
    }
}   

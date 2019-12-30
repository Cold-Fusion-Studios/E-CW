
using UnityEngine;

public class EndGame : MonoBehaviour {

    public EnemyAnimations hitler;

    static bool hasEnded = false;

	void Update () {
		if(hitler.health <= 0 && !hasEnded)
        {
            PlayerManager.Finish();
        }
	}
}

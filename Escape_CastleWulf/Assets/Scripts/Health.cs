using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public float player;

    public Text healthText;
	
	void Update () {
        player = KnifeAnimation.health;
        player = player - player % 1;
        healthText.text = player.ToString();  
	}
}

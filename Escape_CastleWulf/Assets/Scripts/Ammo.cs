using UnityEngine;
using UnityEngine.UI;
public class Ammo : MonoBehaviour {
    public int ammo;
    string percent;
    public Text displayAmmo;
    private void Start()
    {
        percent = "%";
    }
    // Update is called once per frame
    void Update()
    {
        ammo = KnifeAnimation.ammoOut;
        if (ammo == 1000000)
        {
            displayAmmo.text = "∞";
        }
        else
        {
            displayAmmo.text = ammo.ToString() + " %";
        }
    }
}

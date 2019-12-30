using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {
   
    #region Singleton
    public static PlayerManager instance;
   

    private void Awake()
    {
        instance = this;
    }

    #endregion
    public GameObject player;
    static bool hasEnded = false;


    public static void EndGame()
    {
        if (!hasEnded)
        {
            hasEnded = true;
            Restart();

        }
    }

    public static void Finish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        hasEnded = true;
    }

    static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        KnifeAnimation.health = 200;
        KnifeAnimation.ammoMinigun = 1000;
        KnifeAnimation.ammoMP = 500;
        KnifeAnimation.ammoPistol = 10;
        KnifeAnimation.ammoOut = 1000000;
        hasEnded = false;
    }


   

    


}

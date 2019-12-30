using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour {

	// Use this for initialization
	public void Quit ()
    {
        Application.Quit();
    }

    public void Start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}

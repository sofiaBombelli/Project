using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string actualSceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onEnable()
    {
        actualSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}

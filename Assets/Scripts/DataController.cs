using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public int puntajeObtenidoMemo = 100;
    public int puntajeObtenidoFuego = 100;
    public int etapaActual = 1;
    public Bomberos tipoBombero;

    public string actualSceneName;
    public enum Bomberos
    {
        bombero = 0,
        camion = 1,
        helicopter = 2,
        none
    }

    public static DataController Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != actualSceneName)
        {
            actualSceneName = scene.name;
            TestingSceneSwitching(actualSceneName);
        }

    }

    public void TestingSceneSwitching(string _scene)
    {
        switch (_scene)
        {
            case "Intro":
                Debug.Log("Scene Intro");
                break;
            case "MapaInteractivo":
                break;
            case "MemoTest":
                Debug.Log("Scene MemoTest");
                break;
            case "MinijuegoFuego":
                break;
            case "PantallaResultadosFuego":
                //puntajeObtenidoMemo
                break;
            case "PantallaFinal":
                break;
            default:
                Debug.Log("Scene not recognized");
                break;
        }
    }

}

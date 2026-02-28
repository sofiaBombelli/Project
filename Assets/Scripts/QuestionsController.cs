using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionsController : MonoBehaviour
{
    [Header("Respuestas")]
    public string nombre;
    public string mail;
    public string genero;
    public int colorPiel;
    public int colorPelo;
    public Sprite piel;
    public Sprite pelo;

    public int[] respuestas;
    public int[] respuestasTiempo;
    public string respuestaPelo;
    public string respuestaPiel;
    public int tiempoDeAmbigrama;
    public string nombreAmbigrama;

    [Header("Gemas")]
    public int GemasRecolectadas;
    public Text GemasHud;
    public static QuestionsController Instance { get; private set; }

    [Header("Tiempo")]
    public float startTime;
    private bool isCounting;
    private float elapsedTime;

    [Header("Sound clips")]
    public AudioSource gemaSound;
    public AudioSource failSound;
    public AudioSource ambience;
    public AudioClip themeScene1;
    public AudioClip ambience1;
    public AudioClip juegotheme1;
    public AudioClip themeScene2;
    public AudioClip ambience2;
    public AudioClip juegotheme2;
    public AudioClip themeScene3;
    public AudioClip ambience3;
    public AudioClip juegotheme3;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        // Si hay una instancia y no soy yo, destrúyeme.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        ResetTimer();
    }

    public void setCounterOn(bool _isCounting)
    {
        isCounting = _isCounting;
    }
    void Update()
    {
        if (isCounting)
        {
            // Contar el tiempo transcurrido desde el inicio
            elapsedTime = Time.time - startTime;
           
            Debug.Log("Tiempo transcurrido: " + elapsedTime.ToString("F2") + " segundos");
        }

        if (SceneManager.GetActiveScene().name == "Game1A" || SceneManager.GetActiveScene().name == "Game1B" || SceneManager.GetActiveScene().name == "Game1C")
        {
            if (GemasHud == null)
            {
                GemasHud = GameObject.FindGameObjectWithTag("GemasHud").GetComponent<Text>();
            }
        }
    }

    public void sumarGemas()
    {
        GemasRecolectadas++;
        GemasHud.text = GemasRecolectadas.ToString();
        gemaSound.Play();
    }

    public void sumarGemas(int gemas)
    {
        GemasRecolectadas += gemas;
        if (GemasHud != null)
        {
            GemasHud.text = GemasRecolectadas.ToString();
            gemaSound.Play();
        }
    }

    public void failCollision()
    {
        failSound.Play();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reiniciar el contador cuando se carga una nueva escena
        setCounterOn(false);
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            this.GetComponent<AudioSource>().clip = themeScene1;
            this.GetComponent<AudioSource>().Play();
            ambience.clip = ambience1;
            ambience.Play();
            
        }

        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            this.GetComponent<AudioSource>().clip = themeScene2;
            this.GetComponent<AudioSource>().Play();
            ambience.clip = ambience2;
            ambience.Play();
        }

        if (SceneManager.GetActiveScene().name == "Game2A" || SceneManager.GetActiveScene().name == "Game2B" || SceneManager.GetActiveScene().name == "Game2C")
        {
            this.GetComponent<AudioSource>().clip = juegotheme2;
            this.GetComponent<AudioSource>().Play();
        }

        if (SceneManager.GetActiveScene().name == "Scene3")
        {
            this.GetComponent<AudioSource>().clip = themeScene3;
            this.GetComponent<AudioSource>().Play();
            ambience.clip = ambience3;
            ambience.Play();
        }

        if (SceneManager.GetActiveScene().name == "Game3A")
        {
            this.GetComponent<AudioSource>().clip = juegotheme3;
            this.GetComponent<AudioSource>().Play();
        }
    }

    public void guardarRespuestaTiempo(int Nivel)
    {
        // Guardar el tiempo transcurrido en respuestasTiempo cuando se guarda una respuesta
        respuestasTiempo[Nivel] = (int)elapsedTime;
        Debug.Log("elapsedTime: " + elapsedTime);

    }

    public void ResetTimer()
    {
        startTime = Time.time;
        elapsedTime = 0f;
        isCounting = true;
    }

    public void Reset()
    {
        // Inicializar valores por defecto
        nombre = string.Empty;
        mail = string.Empty;
        genero = string.Empty;
        colorPiel = 0;
        colorPelo = 0;
        piel = null;
        pelo = null;

        respuestas = new int[0];
        respuestasTiempo = new int[0];
        respuestaPelo = string.Empty;
        respuestaPiel = string.Empty;
        tiempoDeAmbigrama = 0;
        nombreAmbigrama = string.Empty;

        GemasRecolectadas = 0;
        GemasHud = null;

        startTime = 0f;
        isCounting = false;
        elapsedTime = 0f;

        themeScene1 = null;
        ambience1 = null;
        juegotheme1 = null;
        themeScene2 = null;
        ambience2 = null;
        juegotheme2 = null;
        themeScene3 = null;
        ambience3 = null;
        juegotheme3 = null;

    }
}

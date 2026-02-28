using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game1_1AController : MonoBehaviour
{
    [SerializeField]
    [Header("Items")]
    int totalItems = 0;
    public int CorrectItems = 0;
    [Header("Tiempo")]
    public float durationTime;
    private float time;
    public GoToNextScene go;
    public Text timeText;
    bool countTime = true;
    [Header("Dialogues")]
    public GameObject dialogo1;
    public GameObject dialogo2;
    public GameObject bluredBackground;
    public GameObject Bombera;
    public DialogueController dialogoController;

    [Header("Win Condition")]
    public GameObject WinPanel;
    public Text WinPanelText;
    public Text gemasbonus;
    bool doOnce = true;
    bool iniciarTiempo;

    [Header("Audiosources")]
    AudioSource Monedas;
    public AudioSource SFXBolsa;
    public AudioSource SFXMonedas;

    public static Game1_1AController Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        time = durationTime;
        Monedas = this.GetComponent<AudioSource>();
        dialogo1.SetActive(true);
        bluredBackground.SetActive(true);
    }
    public void Update()
    {
        if (iniciarTiempo)
        {
           
            if (CorrectItems >= totalItems)
            {
                Debug.Log("WIN");
                countTime = false;
                finishLevel();
            }

            if (time > 1 && countTime == true)
            {
                timeText.text = Mathf.FloorToInt(time).ToString() + " s";
                time -= Time.deltaTime;
            }
            else
            {
                if (doOnce == true)
                {
                    finishLevel();
                }
            }
        }
    }
    public void CorrectItemsPlus()
    {
        CorrectItems++;
        Monedas.Play();
    }
    int gemasganadas;
    private void finishLevel()
    {
        if (doOnce)
        {
            doOnce = false;
            // First, give bonus
            gemasganadas = CorrectItems;//CalculateCoins();
            //TENGO QUE ACTIVAR ESTO UNA VEZ QUE LO TERMINE 
            QuestionsController.Instance.sumarGemas(gemasganadas);

            StartCoroutine(giveBonus());

        }
    }
    public void iniciarMinijuego()
    {
        iniciarTiempo = true;
        bluredBackground.SetActive(false);
        QuestionsController.Instance.ResetTimer();
    }
    private IEnumerator giveBonus()
    {
        yield return new WaitForSecondsRealtime(2);
        WinPanel.SetActive(true);
        setResultText();
        gemasbonus.text = gemasganadas.ToString();
        SFXBolsa.Play();
        yield return new WaitForSecondsRealtime(0.5f);
        SFXMonedas.Play();

        yield return new WaitForSecondsRealtime(4);
        activeDialogue2();

    }
    public void activeDialogue2()
    {
        WinPanel.SetActive(false);
        dialogo2.SetActive(true);
        dialogoController.loadCharacter();
        Bombera.SetActive(true);
        bluredBackground.SetActive(true);
    }

    public void goToNext()
    {
        go.GoToNext();
    }
    private void setResultText()
    {
        if (CalculateCoins() >= 0 && CalculateCoins() <= 2)
        {
            WinPanelText.text = "¡Casi lo logras!";
        }
        if (CalculateCoins() > 2 && CalculateCoins() <= 4)
        {
            WinPanelText.text = "¡Bien hecho!";
        }
        if (CalculateCoins() >= 5)
        {
            WinPanelText.text = "¡Excelente!";
        }
    }
    private int CalculateCoins()
    {
        // Mapea el tiempo restante al rango de monedas
        float t = Mathf.Clamp01(time / durationTime);
        return Mathf.RoundToInt(Mathf.Lerp(2, 7, t));
    }
}

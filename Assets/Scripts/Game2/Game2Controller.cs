using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game2Controller : MonoBehaviour
{
    [SerializeField]
    [Header("Piezas")]
    int totalQuads = 0;
    public int totalCorrectQuads1 = 0;
    public int totalCorrectQuads2 = 0;
    public GameObject blockGamePanel;
    [Header("Tiempo")]
    public float durationTime;
    private float time;
    public GoToNextScene go;
    public Text timeText;
    bool countTime = true;
    [Header("Win Condition")]
    public GameObject WinPanel;
    public Text WinPanelText;
    public Text gemasbonus;
    bool doOnce = true;
    bool iniciarTiempo;

    [Header("Audiosources")]
    public AudioSource SFXBolsa;
    public AudioSource SFXMonedas;
    public AudioSource SFXPuzzleComplete;

    [Header("Dialogues")]
    public GameObject dialogo1;
    public GameObject bluredBackground;
    public static Game2Controller Instance { get; private set; }
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
    }
    public void Update()
    {
        if (iniciarTiempo) { 
            if (totalCorrectQuads1 >= totalQuads)
            {
                if (doOnce == true)
                {
                    Debug.Log("WIN");
                    countTime = false;
                    QuestionsController.Instance.nombreAmbigrama = "forma 2 - casas separadas";
                    SFXPuzzleComplete.Play();
                    finishLevel();
                }
            }
            if (totalCorrectQuads2 >= totalQuads)
            {
                if (doOnce == true)
                {
                    Debug.Log("WIN");
                    countTime = false;
                    QuestionsController.Instance.nombreAmbigrama = "forma 1 - una casa" ;
                    SFXPuzzleComplete.Play();
                    finishLevel();

                }
                
            }

            if (time >= 0 && countTime == true)
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
    int gemasganadas;
    public void iniciarMinijuego()
    {
        iniciarTiempo = true;
        bluredBackground.SetActive(false);
        blockGamePanel.SetActive(false);
        QuestionsController.Instance.ResetTimer();
    }
    private void finishLevel()
    {
        blockGamePanel.SetActive(true);
        if (doOnce)
        {
            doOnce = false;
            // First, give bonus
            gemasganadas = CalculateCoins();
            QuestionsController.Instance.sumarGemas(gemasganadas);
            float timeToCompletePuzzle = 15 - time;
            //Debug.Log("timeToCompletePuzzle: " + timeToCompletePuzzle);
            QuestionsController.Instance.tiempoDeAmbigrama = (int)timeToCompletePuzzle;
            StartCoroutine(giveBonus());
            
        }
    }
    private IEnumerator giveBonus()
    {
        SFXMonedas.Play();
        //yield return new WaitForSecondsRealtime(2);
        for (int i = 0; i < this.GetComponent<GridAligner>().quads.Length; i++)
        {
            this.GetComponent<GridAligner>().quads[i].gameObject.SetActive(false);
        }
        
        WinPanel.SetActive(true);
        gemasbonus.text = gemasganadas.ToString();
        setResultText();
        SFXBolsa.Play();
        yield return new WaitForSecondsRealtime(0.5f);
        SFXMonedas.Play();
      
        yield return new WaitForSecondsRealtime(4);
        
    }
    public void finishGame()
    {
        WinPanel.SetActive(false);

        bluredBackground.SetActive(true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game3Controller : MonoBehaviour
{
    [SerializeField]
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
    public static Game3Controller Instance { get; private set; }
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
       // iniciarMinijuego();
    }
    public void Update()
    {
        if (iniciarTiempo)
        {

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
    int gemasganadas;
    public void WinLevel()
    {
        Debug.Log("WIN");
        countTime = false;
        finishLevel();
    }
    public void iniciarMinijuego()
    {
        iniciarTiempo = true;
        QuestionsController.Instance.ResetTimer();
    }
    private void finishLevel()
    {
        if (doOnce)
        {
            doOnce = false;
            // First, give bonus
            gemasganadas = CalculateCoins();
            QuestionsController.Instance.sumarGemas(gemasganadas);
            StartCoroutine(giveBonus());
            
        }
    }
    public void finishLevelClick()
    {
        go.GoToNext();

    }
    private IEnumerator giveBonus()
    {
        WinPanel.SetActive(true);
        setResultText();
        gemasbonus.text = gemasganadas.ToString();
       
        SFXBolsa.Play();
        yield return new WaitForSecondsRealtime(0.5f);
        SFXMonedas.Play();
        //yield return new WaitForSecondsRealtime(4);
        // go.GoToNext();

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

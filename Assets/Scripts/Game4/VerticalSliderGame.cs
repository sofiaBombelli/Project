using UnityEngine;
using UnityEngine.UI;

public class VerticalSliderGame : MonoBehaviour
{
    public Slider slider;
    public float speed = 2.0f;
    private bool goingUp = true;
    private bool gameActive = true;
    public float targetZoneMin = 0.45f;
    public float targetZoneMax = 0.55f;
    public Image targetZoneImage;
    public int intentos = 3;
    public Text intentosText;
    public GameObject Win;
    public Text WinMonedas;
    public int monedasConseguidas;

    
    void Start()
    {
        slider.value = 0;
        UpdateTargetZone();
        intentosText.text = "Intentos: " + intentos.ToString();
    }

    void Update()
    {
        if (!gameActive) return;

        // Mueve el slider hacia arriba o hacia abajo
        if (goingUp)
        {
            slider.value += speed * Time.deltaTime;
            if (slider.value >= 1)
            {
                goingUp = false;
            }
        }
        else
        {
            slider.value -= speed * Time.deltaTime;
            if (slider.value <= 0)
            {
                goingUp = true;
            }
        }

        // Check for player input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSliderPosition();
        }
    }

    public void CheckSliderPosition()
    {
        if (slider.value >= targetZoneMin && slider.value <= targetZoneMax)
        {
            Debug.Log("¡Acierto! El valor del slider está en la zona objetivo.");
            gameActive = false;
            Win.SetActive(true);
            if(intentos> 0 && intentos <= 2)
            {
                monedasConseguidas = 2;
                
            }
            if (intentos > 2 && intentos <= 4)
            {
                monedasConseguidas = 3;
            }
            if (intentos > 4)
            {
                monedasConseguidas = 5;
            }
            WinMonedas.text = monedasConseguidas.ToString();
            //QuestionsController.Instance.sumarGemas(monedasConseguidas);
        }
        else
        {
            Debug.Log("Fallo. El valor del slider está fuera de la zona objetivo.");
            intentos--;
        }
        intentosText.text = "Intentos: " + intentos.ToString();
    }

    void UpdateTargetZone()
    {
        
        if (targetZoneImage != null)
        {
            // Ajustar la posición y el tamaño de la imagen de la zona objetivo
            RectTransform rectTransform = targetZoneImage.GetComponent<RectTransform>();
            float sliderHeight = slider.GetComponent<RectTransform>().rect.height;

            float minAnchor = targetZoneMin;
            float maxAnchor = targetZoneMax;

            // Mantener el ancho original y ajustar solo la altura y posición vertical
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, minAnchor);
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, maxAnchor);

            // Ajustar los offsets verticales y mantener los offsets horizontales
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, 0);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, 0);
        }
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MemotestGame : MonoBehaviour
{
    public RectTransform panel;
    public RectTransform[] quads; // Array de los elementos Quad ya definidos
    public Sprite[] cardImages; // Array de imágenes para las cartas
    public Sprite cardBack; // Imagen del reverso de la carta
    public float revealDuration = 0.5f; // Duración para revelar las cartas
    public float resetDelay = 0.5f; // Tiempo de espera antes de ocultar cartas incorrectas
    public Text messageText; // Texto para mostrar mensajes (opcional)
    public AudioSource audio;

    private int pairsFound = 0;
    private RectTransform firstSelected = null;
    private RectTransform secondSelected = null;
    private bool isWaiting = false;

    

    private void Start()
    {
        if (quads.Length != cardImages.Length * 2)
        {
            Debug.LogError("La cantidad de quads debe ser el doble de la cantidad de imágenes de cartas.");
            return;
        }
        InitializeGame();


    }

    public void InitializeGame()
    {
        // Asignar imágenes a las cartas
        int[] cardIndices = GenerateCardIndices();
        for (int i = 0; i < quads.Length; i++)
        {
            quads[i].GetComponent<Image>().sprite = cardBack;
            quads[i].GetComponent<Image>().preserveAspect = true;
            quads[i].GetComponent<Card>().cardIndex = cardIndices[i];
            int index = i; // Crear una copia local de i
            quads[i].GetComponent<Button>().onClick.AddListener(() => OnCardClicked(quads[index]));
        }
    }

    private int[] GenerateCardIndices()
    {
        int[] cardIndices = new int[quads.Length];
        for (int i = 0; i < cardIndices.Length; i++)
        {
            cardIndices[i] = i / 2;
        }
        // Barajar el array
        for (int i = 0; i < cardIndices.Length; i++)
        {
            int temp = cardIndices[i];
            int randomIndex = Random.Range(0, cardIndices.Length);
            cardIndices[i] = cardIndices[randomIndex];
            cardIndices[randomIndex] = temp;
        }
        return cardIndices;
    }

    private void OnCardClicked(RectTransform card)
    {
        if (isWaiting || card == firstSelected || card.GetComponent<Card>().isMatched)
            return;

        if (firstSelected == null)
        {
            firstSelected = card;
            RevealCard(card);
        }
        else
        {
            secondSelected = card;
            RevealCard(card);
            StartCoroutine(CheckMatch());
        }
        audio.Play();
    }

    private void RevealCard(RectTransform card)
    {
        int cardIndex = card.GetComponent<Card>().cardIndex;
        card.GetComponent<Image>().sprite = cardImages[cardIndex];
        card.GetComponent<Image>().preserveAspect = true;
    }

    private IEnumerator CheckMatch()
    {
        isWaiting = true;
        yield return new WaitForSeconds(revealDuration);

        if (firstSelected.GetComponent<Card>().cardIndex == secondSelected.GetComponent<Card>().cardIndex)
        {
            pairsFound++;
            firstSelected.GetComponent<Card>().isMatched = true;
            secondSelected.GetComponent<Card>().isMatched = true;

            if (pairsFound == cardImages.Length)
            {
                // messageText.text = "¡Has ganado!";
                Game3Controller.Instance.WinLevel();
            }
        }
        else
        {
            yield return new WaitForSeconds(resetDelay);
            HideCard(firstSelected);
            HideCard(secondSelected);
        }

        firstSelected = null;
        secondSelected = null;
        isWaiting = false;
    }

    private void HideCard(RectTransform card)
    {
        card.GetComponent<Image>().sprite = cardBack;
    }
}

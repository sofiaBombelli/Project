using UnityEngine;

public class GridAligner : MonoBehaviour
{
    public int rows = 3;
    public int columns = 3;
    public RectTransform panel;
    public RectTransform[] quads; // Array de los elementos Quad ya definidos

    private void Start()
    {
        AdjustGrid();
    }

    private void Update()
    {
        // Ensure the panel remains square
        AdjustPanelSize();
        AdjustGrid();
    }

    private void AdjustPanelSize()
    {
        // Get the smaller dimension of the screen
        float minScreenDimension = Mathf.Min(Screen.width, Screen.height);

        // Adjust the size of the panel to be a square based on the smaller dimension
        panel.sizeDelta = new Vector2(minScreenDimension, minScreenDimension);
    }

    private void AdjustGrid()
    {
        if (quads.Length != rows * columns)
        {
            Debug.LogError("La cantidad de quads no coincide con filas x columnas");
            return;
        }

        float panelWidth = panel.rect.width;
        float panelHeight = panel.rect.height;

        float cellWidth = panelWidth / columns;
        float cellHeight = panelHeight / rows;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int index = i * columns + j;
                RectTransform quadRect = quads[index];

                // Set the size of each quad
                quadRect.anchorMin = new Vector2(j / (float)columns, i / (float)rows);
                quadRect.anchorMax = new Vector2((j + 1) / (float)columns, (i + 1) / (float)rows);
                quadRect.offsetMin = Vector2.zero;
                quadRect.offsetMax = Vector2.zero;
            }
        }
    }

    private void OnRectTransformDimensionsChange()
    {
        AdjustGrid();
    }
}

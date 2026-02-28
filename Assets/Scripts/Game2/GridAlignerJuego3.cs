using UnityEngine;

public class GridAlignerJuego3 : MonoBehaviour
{
    public int rows = 3;
    public int columns = 3;
    public RectTransform panel;
    public RectTransform[] quads; // Array de los elementos Quad ya definidos
    public float margin = 5f; // Espacio entre quads
    public float panelMargin = 10f; // Margen alrededor del panel

    private void Start()
    {
        AdjustGrid();
    }

    private void Update()
    {
        AdjustPanelSize();
        AdjustGrid();
    }

    private void AdjustPanelSize()
    {
     /*   // Get the dimensions of the screen with margins taken into account
        float screenWidth = Screen.width - 2 * panelMargin;
        float screenHeight = Screen.height - 2 * panelMargin;

        // Adjust the size of the panel to fit within the screen margins
        panel.sizeDelta = new Vector2(screenWidth, screenHeight);*/
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

        // Adjust cell size to account for margins
        float totalMarginWidth = margin * (columns - 1);
        float totalMarginHeight = margin * (rows - 1);
        float cellWidth = (panelWidth - totalMarginWidth) / columns;
        float cellHeight = (panelHeight - totalMarginHeight) / rows;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int index = i * columns + j;
                RectTransform quadRect = quads[index];

                // Calculate the position with margins
                float xMin = j * (cellWidth + margin);
                float yMin = i * (cellHeight + margin);
                float xMax = xMin + cellWidth;
                float yMax = yMin + cellHeight;

                // Set the size and position of each quad
                quadRect.anchorMin = new Vector2(xMin / panelWidth, yMin / panelHeight);
                quadRect.anchorMax = new Vector2(xMax / panelWidth, yMax / panelHeight);
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

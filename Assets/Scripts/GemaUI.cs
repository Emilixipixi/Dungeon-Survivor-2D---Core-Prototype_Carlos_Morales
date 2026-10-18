using UnityEngine;
using TMPro;

public class GemaUI : MonoBehaviour
{
    [Header("Referencias")]
    public TMP_Text textoGemas; // El texto "Gemas: 0" del Canvas

    private int ultimoValor = -1;

    void Start()
    {
        // Reinicia el contador al empezar el nivel.
        // Es necesario porque una variable static NO se reinicia sola al recargar la escena.
        Gema.totalGemas = 0;
    }

    void Update()
    {
        // Solo actualiza el texto cuando el valor cambia
        if (Gema.totalGemas == ultimoValor) return;
        ultimoValor = Gema.totalGemas;

        textoGemas.text = "Gemas: " + ultimoValor;
    }
}
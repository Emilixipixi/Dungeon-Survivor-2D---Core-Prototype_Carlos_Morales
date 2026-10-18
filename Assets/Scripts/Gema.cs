using UnityEngine;

public class Gema : MonoBehaviour
{
    // Contador compartido por todas las gemas (static = una sola variable para todas)
    public static int totalGemas = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            totalGemas++;
            Destroy(gameObject);
        }
    }
}
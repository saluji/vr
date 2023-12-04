using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Logik für Basketballkorb um Punkte zu zählen
/// </summary>
public class Hoop : MonoBehaviour
{
    // Textfeld für Punkteanzeige
    public Text label;

    // Aktuell erzielte Punkte
    private int points;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball")) 
        {
            AddPoint();
        }
    }

    /// <summary>
    /// Punkt addieren und UI aktualisieren
    /// </summary>
    private void AddPoint() 
    {
        points++;
        label.text = "Points: " + points;
    }
}

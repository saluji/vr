using UnityEngine;


/// <summary>
/// Setzt ein Objekt nach einer Wartezeit 
/// wieder auf seine Ursprungsposition zurück
/// </summary>
public class AutoReset : MonoBehaviour
{
    // Dauer bis das Objekt zurückgesetzt wird
    public float timeTillRespawn;

    // Zeit die bereits vergangen ist
    private float elapsedTime;

    // Altert das Objekt gerade?
    private bool isResetting;

    // Initiale Position und Rotation
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Awake()
    {
        // Initial Position und Rotation merken
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Zeit addieren oder abziehen
        elapsedTime = !isResetting ? elapsedTime -= Time.deltaTime : elapsedTime += Time.deltaTime;

        // Sicherstellen das die vergangene Zeit nicht unter 0 fällt
        elapsedTime = Mathf.Clamp(elapsedTime, 0f, float.MaxValue);

        // Zeit abgelaufen?
        if (elapsedTime >= timeTillRespawn)
        {
            Respawn();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isResetting = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isResetting = false;
        }
    }

    private void Respawn() 
    {
        transform.position = startPosition;
        transform.rotation = startRotation;

        // Etwaige noch wirkende Kräft zurücksetzen
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }        
    }
}

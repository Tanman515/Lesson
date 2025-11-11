using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float bounceForce = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        // Используем TryGetComponent для безопасной проверки наличия PlayerController
        if (collision.gameObject.TryGetComponent<PlayerController>(out var player))
        {
            Rigidbody rb = collision.rigidbody;
            if (rb != null)
            {
                rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
            }
        }
    }
}
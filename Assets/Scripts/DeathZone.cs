using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(0, 0, 7);

            // Минусуем сердечко через HUDController
            HUDController hud = FindObjectOfType<HUDController>();
            if (hud != null)
            {
                hud.TakeDamage(1);
            }
        }
    }
}
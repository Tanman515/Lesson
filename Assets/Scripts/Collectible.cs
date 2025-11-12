using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Проверяем, что это игрок
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            // Находим HUDController и обновляем счетчик
            FindObjectOfType<HUDController>().AddCoin();

            // Уничтожаем текущий объект
            Destroy(gameObject);
        }
    }
}
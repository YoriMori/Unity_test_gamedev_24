using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPush : MonoBehaviour
{
    public float pushForce = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, что столкновение произошло с арбузом
        if (collision.gameObject.CompareTag("Watermelon"))
        {
            Rigidbody watermelonRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            if (watermelonRigidbody != null)
            {
                // Направление отталкивания - от персонажа к арбузу
                Vector3 pushDirection = collision.transform.position - transform.position;
                pushDirection.y = 0; // Исключаем вертикальную составляющую

                // Применяем силу отталкивания к арбузу
                watermelonRigidbody.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);
            }
        }
    }
}

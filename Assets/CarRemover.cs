using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fabrikademo.PlayerMovement;

public class CarRemover : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(TAGS.car))
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            AIController.instance.cars.Remove(collision.gameObject.transform);
            Destroy(collision.gameObject.GetComponent<AIMovement>());
            Destroy(collision.gameObject, 2f);
        }

        if (collision.gameObject.CompareTag(TAGS.player))
        {
            collision.gameObject.GetComponent<PlayerMovementController>().isFall = true;
            AIController.instance.cars.Remove(collision.gameObject.transform);
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);

        Time.timeScale = 0f;

        print("Game Over");
    }
}

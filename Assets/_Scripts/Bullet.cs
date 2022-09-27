using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 5);
    }
    private void OnCollisionEnter(Collision hit)
    {
        Destroy(gameObject); //Destroys the Bullet on collision with an object

        if (hit.collider.tag == "Box")
        {
            Destroy(hit.gameObject);
        }
        if (hit.collider.tag == "Enemy")
        {
            Destroy(hit.gameObject);
            ScoreManager.instance.ChangeScore(1);
        }
    }
}

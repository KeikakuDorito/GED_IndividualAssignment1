using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.GainHealth(1);
        }
    }
}
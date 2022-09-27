using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private float walkSpeed = 1f;
    private bool inRange;

    Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyAnimator.ResetTrigger("Attack");
            GameManager.instance.TakeDamage(); //Damage the Player
            enemyAnimator.SetTrigger("Attack");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed, Space.Self);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterMovement : MonoBehaviour
{
    public float speed;

    public Transform PlayerHead;

    public Transform Target;

    public float air = 100;

    private float timeTillDrown = 1;
    private float timeTillLoseAir = 1;
    void Start()
    {

    }


    void Update()
    {
        if (BossHealth.health <= 0)
        {
            moveWater();
            Drowning();
            if (transform.position.y < PlayerHead.position.y)
            {
                air = 100;
            }
            if (MeleeAttack.Health <= 0)
            {
                SceneManager.LoadScene("loseScene");
            }
        }
        
    }

    void moveWater()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);

        transform.position = newPosition;
    }
    void Drowning()
    {
        if (transform.position.y > PlayerHead.position.y)
        {
            timeTillLoseAir -= Time.deltaTime;
            if (timeTillLoseAir <= 0)
            {
                air = air - 20;
                timeTillLoseAir = 1;
                Debug.Log(air);
            }

            if (air <= 0)
            {
                timeTillDrown -= Time.deltaTime;
                if (timeTillDrown <= 0)
                {
                    MeleeAttack.Health = MeleeAttack.Health - 10;
                    timeTillDrown = 1;
                    Debug.Log(MeleeAttack.Health);
                }

            }
        }
    }
}

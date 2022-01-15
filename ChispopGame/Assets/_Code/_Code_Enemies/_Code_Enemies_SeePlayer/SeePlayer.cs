using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    public float distance;
    public GameObject Player;

    public BoolVariable Hidden;

    public void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (distance > 10)
        {
            if (Hidden.Value == true)
            {
                Debug.Log("Enemy can't see player");
            }
        }

        if (distance < 10)
        {
            if (Hidden.Value == true)
            {
                FindPlayer();
                Debug.Log("Enemy can see player");
            }
        }

        if (Hidden.Value == false)
        {
            FindPlayer();
            Debug.Log("Enemy can see player");
        }
    }

    public void FindPlayer()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, Player.gameObject.transform.position);
    }
}

using UnityEngine;

public class Destructible_Objects : MonoBehaviour
{
    public GameObject BoxDestroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(BoxDestroyed, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

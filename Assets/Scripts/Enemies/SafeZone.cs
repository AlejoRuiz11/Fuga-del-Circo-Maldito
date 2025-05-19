using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public EnemyController enemyController;
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            enemyController.enZonaSegura = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SafeZone")
        {
            enemyController.enZonaSegura = false;
        }
    }

}

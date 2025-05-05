using UnityEngine;

public class JumpScareZone: MonoBehaviour
{
    public EnemyController enemyController;
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JumpScareZone")
        {
            enemyController.enZonaJumpScare = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "JumpScareZone")
        {
            //enemyController.enZonaJumpScare = false;
        }
    }
}

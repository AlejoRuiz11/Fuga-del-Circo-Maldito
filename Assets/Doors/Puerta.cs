using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator puerta;
    private bool enZona;
    private bool puertaActiv;
    private bool activa;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enZona == true) 
        {
            activa = !activa;

            if(activa == true)
            {
                puerta.SetBool("PuertaActiv", true);
            }

            if(activa == false)
            {
                puerta.SetBool("PuertaActiv", false);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enZona = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enZona = false;
        }
    }
}

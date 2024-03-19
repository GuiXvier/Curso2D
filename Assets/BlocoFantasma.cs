using UnityEngine;

public class BlocoFantasma : MonoBehaviour
{
    void Start()
    {
        // Desativa a renderização do GameObject no início
        GetComponent<Renderer>().enabled = false;
    }

    // Este método é chamado quando um objeto entra no colisor (trigger)
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Detected");
        // Ativa a renderização do GameObject quando o jogador entra no colisor
        GetComponent<Renderer>().enabled = true;
    }
}

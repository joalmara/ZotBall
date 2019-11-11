using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour
{
    public GameObject complete;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        Invoke("Restart", 2);
        GameObject alert = Instantiate(complete, new Vector3(0.5f, 0.5f, 0), transform.rotation) as GameObject;
        Destroy(player.GetComponent<Rigidbody>());
    }

    void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

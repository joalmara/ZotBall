using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("LOSE");
            GetComponent<AudioSource>().Play();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


  
        
}

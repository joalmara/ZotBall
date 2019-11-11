using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Banana"))
        {
            other.gameObject.SetActive(false);
        }

        else if (other.gameObject.CompareTag("Sea"))
        {
            Debug.Log("LOSE");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (other.gameObject.CompareTag("Portal"))
        {
            Destroy(rb);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }



    }
}

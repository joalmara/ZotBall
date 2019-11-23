using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
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
            count += 1;
            SetCountText();
        }

        else if (other.gameObject.CompareTag("Sea"))
        {
            Debug.Log("LOSE");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        else if (other.gameObject.CompareTag("Portal"))
        {
            Destroy(rb);
            SceneManager.LoadScene(2);

        }



    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}

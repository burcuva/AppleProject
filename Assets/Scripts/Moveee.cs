using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveee : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 100f;
    [SerializeField] public float jumpForce = 100f;
    Rigidbody rb;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        // Hareket vektörünü oluştur
        Vector3 movement = new Vector3(xValue, 0.0f, zValue) * moveSpeed * Time.deltaTime;

        // Yatay (sağa veya sola) hareket kontrolü
        if (xValue > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Sağa doğru yüz
        }
        else if (xValue < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Sola doğru yüz
        }

        // Dikey (yukarı veya aşağı) hareket kontrolü
        if (zValue > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f); // Yukarı doğru yüz
        }
        else if (zValue < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f); // Aşağı doğru yüz
        }

        // Rigidbody ile hareket ettir
        rb.MovePosition(transform.position + movement);
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
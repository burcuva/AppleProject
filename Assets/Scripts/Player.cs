using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour


{   
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI  homeText;
    public int elma_sayisi;
    public Transform collectPoint;
  
    private List<GameObject>  collectedApples = new List<GameObject>();
    private int totalScore =0;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        if(collectPoint==null)
        {
            Debug.Log("toplandı.");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tree"))
        {
            CollectApplesFromTree(other.transform);
        }
        if(other.CompareTag("DropZone"))
        {
            DropApples();

        }
    }
    void CollectApplesFromTree(Transform treeTransform)
    {
        foreach(Transform child in treeTransform)
    {
        if(child.CompareTag("Apple"))

        {
            Rigidbody appleRb = child.GetComponent<Rigidbody>();
            if(appleRb != null){
           
              appleRb.isKinematic = true;
              appleRb.useGravity = false;
            }
            else{
                    Debug.LogWarning("Rigidbody bileşeni bulunamadı: " + child.gameObject.name);
                }
           float randomX = Random.Range(-0.4f, 0.4f);
            float randomZ = Random.Range(-0.3f, 0.3f);

            // Elmaları collectPoint'e yerleştirirken yükseklikte bir artış sağlayarak sepette düşecek şekilde ayarlıyoruz
            Vector3 dropPosition = collectPoint.position + new Vector3(randomX, 0.3f, randomZ);
            
            if(collectedApples.Count<=20)
          {

            child.SetParent(collectPoint);
            child.position = dropPosition;
            collectedApples.Add(child.gameObject);
            UpdateScoreText();
            Debug.Log("Toplanan elma Sayisi= " + collectedApples.Count);
          }
          else
          {
            Debug.Log("Sepet doldu");
           
           
            break;
            

          }
        }
    }
}
   private void DropApples()
    {
        Debug.Log("DropApples çağrildi.");
        foreach (GameObject apple in collectedApples){

          Rigidbody appleRb = apple.GetComponent<Rigidbody>();
          if(appleRb != null){

            appleRb.useGravity = true;
            appleRb.isKinematic = false;

          

          }
          else
            {
                Debug.LogWarning("Rigidbody bileşeni bulunamadi: " + apple.gameObject.name);
            }
           
          apple.transform.SetParent(null);
          apple.transform.position = new Vector3(transform.position.x + UnityEngine.Random.Range(-1f, 1f), transform.position.y, transform.position.z + UnityEngine.Random.Range(-1f, 1f));

          
        }
        totalScore += collectedApples.Count;
         UpdateHomeText();

        collectedApples.Clear();
        UpdateScoreText();
}
   private void UpdateScoreText()
   {
    if(scoreText != null)
     
     scoreText.text = "Score:" + collectedApples.Count;

   }

   private void UpdateHomeText()
   {
    if(homeText != null)
     homeText.text = "Home:" + totalScore;

   }
}


    

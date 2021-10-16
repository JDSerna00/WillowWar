using UnityEngine;

public class healthSystem : MonoBehaviour{
    public GameObject heartPrefab;
    public GameObject brokenHeartPrefab;

    public void DrawHearts (int hearts, int maxHearts){
        foreach (Transform child in transform){
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHearts; i++)
        {
            if (i + 1 <= hearts)
            {
                GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
            else 
            {
                GameObject heart = Instantiate(brokenHeartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
        }
    }

}

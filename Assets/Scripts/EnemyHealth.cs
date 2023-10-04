using UnityEngine;

public class EnemyHealth : Health
{ 
    public GameObject itemPrefab;

    protected override void Die()
    {
        IsDead = true;
        
        var droppedItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        droppedItem.SetActive(true);
        droppedItem.GetComponentInChildren<Animation>().Play();

        gameObject.GetComponent<EnemyMovement>().enabled = false;
        gameObject.SetActive(false);


    }

}

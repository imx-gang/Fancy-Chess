using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryUI : MonoBehaviour
{
    public NFT_Example[] nfts; 
    public Transform contentBox;
    public GameObject inventoryItem;

    // Start is called before the first frame update
    void Start()
    {
        foreach(NFT_Example nft in nfts){
            GameObject item = Instantiate(inventoryItem, contentBox);
            item.transform.GetChild(0).GetComponent<Image>().sprite = nft.image;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu(){
        SceneManager.LoadScene("Menu");
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using GameObject = UnityEngine.GameObject;

public class Shop : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public Sprite image;
        public int price;
        public bool isPurchased;
        
    }

    [SerializeField] private GameObject shopItemPrefab; // Prefab for the shop item
    [SerializeField] private Transform content; // Reference to the Content object
    [SerializeField] private List<ShopItem> shopItemsList; // List of shop items


    void Start()
    {
        int i = 0;
        foreach (ShopItem item in shopItemsList)
        {
            // Instantiate shop item UI based on the shopItemsList
            GameObject shopItemUI= Instantiate(shopItemPrefab, content);
            
            // Access UI elements of shopItemUI and set their properties
            Image iconImage = shopItemUI.transform.Find("icon")?.GetComponent<Image>();
            Text priceText = shopItemUI.transform.Find("price")?.GetComponent<Text>();
            Button purchaseButton = shopItemUI.transform.Find("Button")?.GetComponent<Button>();

            if (iconImage != null && priceText != null && purchaseButton != null)
            {
                iconImage.sprite = item.image;
                priceText.text = item.price.ToString();
                purchaseButton.interactable = !item.isPurchased;
            }
        }
    }


}
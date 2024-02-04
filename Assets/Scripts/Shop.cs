using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private GameObject ItemTemplate;
    private GameObject g;
    [SerializeField] Transform ShopScrollView;
    

    private void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
        for (int i = 0; i < 10; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
        }
        Destroy(ItemTemplate);
    }
}

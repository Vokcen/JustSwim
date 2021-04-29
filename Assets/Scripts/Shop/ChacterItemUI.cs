using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;
using DG.Tweening;

public class ChacterItemUI : MonoBehaviour
{
    [SerializeField] Color itemNotSelectedColor;
    [SerializeField] Color itemSelectedColor;


    [Space(20f)] 
    [SerializeField] Image chacterImage;
    [SerializeField] TMP_Text chacterNameText;
    [SerializeField] Image chacterSpeedFill;
    [SerializeField] Image chacterPowerFill;
    [SerializeField] TMP_Text chacterPriceText;
    [SerializeField] Button  chacterPurchasedButton;

    [Space(20f)]
    [SerializeField] Button  itemButton;
    [SerializeField] Image itemImage;
    [SerializeField] Outline itemOutline;


    //--------------------------------------------------------
    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition +=pos;

    }
    public void SetChacterImage(Sprite sprite)
    {
        chacterImage.sprite = sprite;
    }
    public void SetChacterName(string name)
    {
        chacterNameText.text = name;
    }
    public void SetChacterSpeed(float speed)
    {
        chacterSpeedFill.fillAmount = speed/100;
    }
    public void SetChacterPower(float power)
    {
        chacterPowerFill.fillAmount = power / 100;
    }
    public void SetChacterPrice(int price)
    {
        chacterPriceText.text = price.ToString();
    }
    public void SetChacterasPurchased()
    {
        chacterPurchasedButton.gameObject.SetActive(false);
        itemButton.interactable = true;

        itemImage.color = itemNotSelectedColor;
    }
    public void OnItemPurchase(int itemIndex, UnityAction<int> action)
    {
        chacterPurchasedButton.onClick.RemoveAllListeners();
        chacterPurchasedButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }
    public void OnItemSelect(int itemIndex, UnityAction<int> action)
    {
        itemButton.interactable = true;
        itemButton.onClick.RemoveAllListeners();
        itemButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }
    public void SelectItem()
    {
        itemOutline.enabled = true;
        itemImage.color = itemSelectedColor;
        itemButton.interactable = false;
    }
    public void DeSelectItem()
    {
        itemOutline.enabled = false;
        itemImage.color = itemNotSelectedColor;
        itemButton.interactable = true;
    }
    public void AnimateShakeItem()
    {
        transform.DOComplete();
        transform.DOShakePosition(1f, new Vector3(8f, 0, 0), 10, 0).SetEase(Ease.Linear);
    }
}

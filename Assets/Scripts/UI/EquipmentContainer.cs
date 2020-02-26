using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipmentContainer : MonoBehaviour
{

    public Equipment ownedEquipment;//container中盛放的装备






    /// <summary>
    /// 设置container盛有的装备
    /// </summary>
    /// <param name="equipment"></param>
    public void SetEquipment(Equipment equipment) {
        if (ownedEquipment != null) return;

        ownedEquipment = equipment;

        transform.GetChild(0).gameObject.SetActive(true);

        //从文件中读取sprite信息，赋予container的子物体的image
        Sprite sprite = Resources.LoadAll<Sprite>("FreePixelGear/Gear")[12];

        transform.GetChild(0).GetComponent<Image>().sprite = sprite;
      

    }


    /// <summary>
    /// 从container中移除装备
    /// </summary>
    public void RemoveEquipment() {
        if (ownedEquipment == null) return;

        ownedEquipment = null;
        transform.GetChild(0).GetComponent<Image>().sprite = null;
        transform.GetChild(0).gameObject.SetActive(false);


    }


}

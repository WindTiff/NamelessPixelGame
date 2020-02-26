using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystemInfo : MonoBehaviour
{
    //存储所有装备信息的文件路径
    public static string AllEquipmentsInfoFilePath;

    //存储所有目前与角色相关的的装备信息的文件路径，包括装备栏中的装备信息以及装备背包中的装备信息
    public static string RoleEquipmentsInfoFilePath;
    
    //存储当前装备的equipments//存储方式：字典
    public static Dictionary<EquipmentType, Equipment> EquipmentField_Dic;

    //存储当前装备背包中的equipments//存储方式：列表
    public static List<Equipment> Equipment_List;
    


    /// <summary>
    /// 从文件中读取与角色相关的装备信息
    /// </summary>
    public static void ReadRoleEquipmentsInfo() {
        //从 RoleEquipmentsInfoFilePath 中读取角色相关的装备信息，存储到EquipmentField_Dic、Equipment_List中



    }


    /// <summary>
    /// 存储当前与角色相关的装备信息
    /// </summary>
    public void SaveRoleEquipmentsInfo() {
        //将EquipmentField_Dic、Equipment_List中的临时信息存储到RoleEquipmentsInfoFilePath文件当中



    }

    /// <summary>
    /// 从装备栏信息中移除装备
    /// </summary>
    /// <param name="equipment"></param>
    public static void RemoveEquipmentFromSlot(Equipment equipment) {
        EquipmentField_Dic[equipment.type] = null;

    }
    /// <summary>
    /// 向装备栏信息中加入装备
    /// </summary>
    /// <param name="equipment"></param>
    public static void AddEquipmentToSlot(Equipment equipment) {
        EquipmentField_Dic[equipment.type] = equipment;
    }
    /// <summary>
    /// 向装备背包信息中加入装备
    /// </summary>
    /// <param name="equipment"></param>
    public static void AddEquipmentToList(Equipment equipment) {
        Equipment_List.Add(equipment);

    }
    /// <summary>
    /// 从装备背包信息中移除装备
    /// </summary>
    /// <param name="equipment"></param>
    public static void RemoveEquipmentFromList(Equipment equipment) {
        Equipment_List.Remove(equipment);

    }

   
}

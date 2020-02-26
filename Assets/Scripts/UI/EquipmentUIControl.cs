using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制装备栏UI
/// </summary>

public class EquipmentUIControl : MonoBehaviour
{
    [Header("左侧装备显示栏")]
    public GameObject equipmentState;
    [Header("可滑动装备栏")]
    public GameObject equipmentContent;
    [Header("选择光标")]
    [SerializeField]
    public EquipCursor equipmentCursor;
    [Header("左侧装备栏列表")]
    public EquipmentContainer[] equipmentsSlots;


    void Update()
    {
        CursorControl();//控制光标移动


        if (Input.GetKeyDown(KeyCode.Space)) {
            SwitchCursorArea();
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            if (equipmentCursor.inRightArea) {
                  Equip();

            }
            else
            {
                Unload();
            }
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            Drop();
        }

    }



    /// <summary>
    /// 初始化与装备相关的UI
    /// </summary>
    public void InitEquipmentsUI() {
        //初始化装备栏EquipmentContainers
        for (int i = 0; i < EquipmentSystemInfo.Equipment_List.Count; i++)
        {
            equipmentContent.transform.GetChild(i).GetComponent<EquipmentContainer>().SetEquipment(EquipmentSystemInfo.Equipment_List[i]);
        }

        //初始化装备背包UIEquipmentContainers
        foreach (KeyValuePair<EquipmentType,Equipment> type_equipment in EquipmentSystemInfo.EquipmentField_Dic)
        {
            equipmentsSlots[(int)type_equipment.Key].SetEquipment(type_equipment.Value);
        }

    }

    /// <summary>
    /// 装备
    /// </summary>
    public void Equip() {
        if (equipmentCursor.selectedEquipment == null) return;
        equipmentCursor.cursorImage.transform.parent.GetComponent<EquipmentContainer>().RemoveEquipment();//背包container remove//UI
        EquipmentSystemInfo.RemoveEquipmentFromList(equipmentCursor.selectedEquipment);//背包信息remove//信息
        equipmentsSlots[(int)equipmentCursor.selectedEquipment.type].SetEquipment(equipmentCursor.selectedEquipment);//装备栏container set//UI
        EquipmentSystemInfo.AddEquipmentToSlot(equipmentCursor.selectedEquipment);//装备栏信息 add//信息
        equipmentCursor.selectedEquipment = null;//设定光标未选定任何装备

    }
    /// <summary>
    /// 卸下
    /// </summary>
    public void Unload() {
        equipmentCursor.cursorImage.transform.parent.GetComponent<EquipmentContainer>().RemoveEquipment();//装备栏container remove//UI
        EquipmentSystemInfo.RemoveEquipmentFromSlot(equipmentCursor.selectedEquipment);//装备栏信息remove//信息
        //////////////////////////////////////////////////////////////////////////
        equipmentsSlots[(int)equipmentCursor.selectedEquipment.type].SetEquipment(equipmentCursor.selectedEquipment);//装备背包信息container set//UI
        ////////////////////////////////////////////////////////////////////////
        EquipmentSystemInfo.AddEquipmentToList(equipmentCursor.selectedEquipment);//装备栏信息 add//信息
        equipmentCursor.selectedEquipment = null;//设定光标未选定任何装备
    }


    /// <summary>
    /// 丢弃装备
    /// </summary>
    public void Drop() {
        //

    }


    /// <summary>
    /// 每当光标移动时调用该方法，更新显示选定的装备信息
    /// </summary>
    public void UpdateSelectionInfo() {


    }

    /// <summary>
    /// 重新排列装备列表（暂时未开发）
    /// </summary>
    public void ArrangeEquipments() {


    }

    /// <summary>
    /// 改变光标的移动范围（左侧装备栏<--->右侧装备列表）
    /// </summary>
    public void SwitchCursorArea() {
        equipmentCursor.CursorSet(equipmentCursor.inRightArea ? equipmentState : equipmentContent, 0);
        equipmentCursor.inRightArea = !equipmentCursor.inRightArea;
        equipmentCursor.currentIndex = 0;
        equipmentCursor.cursorPos = Vector2.zero;


    }

    /// <summary>
    /// 光标控制
    /// </summary>
    public void CursorControl()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (equipmentCursor.inRightArea)
            {
                equipmentCursor.MoveTowards(new Vector2(-1, 0));
                equipmentCursor.CursorSet(equipmentContent, equipmentCursor.currentIndex);

            }
            else {
                equipmentCursor.RotateBy(true);
                equipmentCursor.CursorSet(equipmentState, equipmentCursor.currentIndex);

            }


        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (equipmentCursor.inRightArea)
            {
                equipmentCursor.MoveTowards(new Vector2(1, 0));
                equipmentCursor.CursorSet(equipmentContent, equipmentCursor.currentIndex);
            }
            else
            {
                equipmentCursor.RotateBy(false);
                equipmentCursor.CursorSet(equipmentState, equipmentCursor.currentIndex);

            }

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (equipmentCursor.inRightArea)
            {
                equipmentCursor.MoveTowards(new Vector2(0, -1));
                equipmentCursor.CursorSet(equipmentContent, equipmentCursor.currentIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (equipmentCursor.inRightArea)
            {
                equipmentCursor.MoveTowards(new Vector2(0, 1));
                equipmentCursor.CursorSet(equipmentContent, equipmentCursor.currentIndex);
            }
        }

    }


}







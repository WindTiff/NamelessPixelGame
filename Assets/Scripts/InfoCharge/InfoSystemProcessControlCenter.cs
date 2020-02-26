using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSystemProcessControlCenter : MonoBehaviour
{
    public EquipmentUIControl equipmentUI;


    void Awake()
    {
        //初始化游戏系统的所有信息/////

        //装备信息
        ///EquipmentSystemInfo.ReadRoleEquipmentsInfo();
        //属性信息
        //角色基本信息
        //技能信息
        //任务信息
        //日志信息

        //根据游戏系统的信息初始化游戏系统的UI/////

        //装备系统UI
        ///equipmentUI.InitEquipmentsUI();
        //属性系统UI
        //物品系统UI
        //技能系统UI
        //任务系统UI
        //日志系统UI
    }

    void Start()
    {
        
    }

    /// <summary>
    /// 存储当前游戏进度
    /// </summary>
    public void SaveGame() {


    }


}

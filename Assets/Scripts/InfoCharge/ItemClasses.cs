using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public enum EquipmentType {
    HEAD_WEAR,
    SHOULDER_ARMOR,
    HOLD,
    SHOES,
    TROUSERS,
    BELT,
    BREASTPLATE

}

/// <summary>
/// 所有游戏世界中可实体化的道具
/// </summary>
public class Item
{
    public string name;
    public string sprite_name;
    public float weight;

}

/// <summary>
/// 装备类
/// </summary>
public class Equipment:Item
{
    public EquipmentType type;

}

/// <summary>
/// 武器类
/// </summary>
public class Weapon:Equipment
{
    public int aggressivity;
    public float speed;
    public string[] combos;




}

/// <summary>
/// 防具类
/// </summary>
public class Armor : Equipment
{
    public int armor_value;
    

}


/// <summary>
/// 装备栏中可以移动的选择光标类
/// </summary>
[Serializable]
public class EquipCursor
{
    public Image cursorImage;
    public Vector2 moveRange;
    public int rotateRange;
    public Vector2 cursorPos;
    public Equipment selectedEquipment;
    public int currentIndex;
    public bool inRightArea;

    public EquipCursor()
    {
        cursorPos = Vector2.zero;
        currentIndex = 0;
        selectedEquipment = null;
        inRightArea = true;

    }

    public void RotateBy(bool left) {
        if (left)
        {
            currentIndex = (currentIndex - 1) < 0 ? rotateRange : (currentIndex - 1);
        }
        else {
            currentIndex = (currentIndex +1) > rotateRange ? 0 : (currentIndex + 1);
        }

    }
    /// <summary>
    /// 控制光标移动
    /// </summary>
    /// <param name="direction"></param>
    public void MoveTowards(Vector2 direction)
    {

        cursorPos = cursorPos + direction;

        if ((cursorPos.x) > moveRange.x)
        {
            cursorPos.x = 0;
        }
        if ((cursorPos.x) < 0)
        {
            cursorPos.x = moveRange.x;
        }

        if ((cursorPos.y) > moveRange.y)
        {
            cursorPos.y = 0;
        }
        if ((cursorPos.y) < 0)
        {
            cursorPos.y = moveRange.y;
        }
        currentIndex = (int)(cursorPos.y * (moveRange.x + 1) + cursorPos.x);
    }

    /// <summary>
    /// 设置光标父物体和位置
    /// </summary>
    /// <param name="content"></param>
    /// <param name="targetIndex"></param>
    public void CursorSet(GameObject content, int targetIndex)
    {
        cursorImage.transform.SetParent(content.transform.GetChild(targetIndex));
        selectedEquipment = cursorImage.transform.parent.GetComponent<EquipmentContainer>().ownedEquipment;
        cursorImage.transform.localPosition = Vector3.zero;

    }


}
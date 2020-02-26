using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CombatSystemControl : MonoBehaviour
{
    [Header("形成连招预留时间")]
    public float MovementTime;
    [Header("输入有效性判断")]
    public bool inputEffective;


    private PlayerInputControl PIC;//输入控制器
    private List<ComboSkill> MasteredComboSkills;//已经掌握的技能
    private List<ComboSkill> tempPossibleComboSkills;//暂存可能会释放的技能
    private  List<string> InputedMovements;//已经输入的招式


    //测试用临时变量
    ComboSkill c1 = new ComboSkill("combo1", "旋风斩", "^^^^", 1, "旋风斩动画", 1, "Fist,Kick,Kick");
    ComboSkill c2 = new ComboSkill("combo2", "回旋踢", "^^^^", 1, "旋风斩动画", 1, "Fist,Kick");

    void Start()
    {
        //变量初始化
        PIC = GetComponent<PlayerInputControl>();
        inputEffective = true;
        InputedMovements = new List<string>();
        MasteredComboSkills = new List<ComboSkill>();
        MasteredComboSkills.Add(c1);
        MasteredComboSkills.Add(c2);
        tempPossibleComboSkills = new List<ComboSkill>(MasteredComboSkills);

    }


    void Update()
    {
        if (MovementTime >= 0) {
            MovementTime -= Time.deltaTime;
        }

        if (PIC.IsFist) {

            if (!inputEffective) {
                return;
            }

            if (MovementTime <= 0) {
                InputedMovements.Clear();
                tempPossibleComboSkills = new List<ComboSkill>(MasteredComboSkills);
            }

            Movement movement = new Movement("Fist", "拳动画", 0.8f);
            ReleaseMovement(movement);
            MovementCheckUp(movement);

        }
        if (PIC.IsKick)
        {
            if (!inputEffective)
            {
                return;
            }
            if (MovementTime <= 0)
            {
                InputedMovements.Clear();
                tempPossibleComboSkills = new List<ComboSkill>(MasteredComboSkills);
            }
            Movement movement = new Movement("Kick", "踢动画", 0.8f);
            ReleaseMovement(movement);
            MovementCheckUp(movement);

        }
    }

    /// <summary>
    /// 释放招式
    /// </summary>
    /// <param name="movement"></param>
    void ReleaseMovement(Movement movement) {
        //播放movement动画

        print(movement.name);

        StartCoroutine("MovementPostBack",movement.animation_time);

    }


    /// <summary>
    /// 释放连击技能
    /// </summary>
    /// <param name="combo"></param>
    void ReleaseComboSkill(ComboSkill combo) {
        //播放combo动画

        print(combo.name);

    }


    /// <summary>
    ///输入招式后开启的协程 
    /// </summary>
    /// <param name="ani_time"></param>
    /// <returns></returns>
    IEnumerator MovementPostBack(float ani_time) {
        inputEffective = false;
        yield return new WaitForSeconds(ani_time-0.5f);
        inputEffective = true;
        MovementTime = 2;

    }

    /// <summary>
    /// 输入检测，检测输入的招式是否可以形成连击技能
    /// </summary>
    /// <param name="currentMovement"></param>
    void MovementCheckUp(Movement currentMovement) {
        List<ComboSkill> list_for_remove = new List<ComboSkill>();

        foreach (ComboSkill combo in tempPossibleComboSkills)//遍历所有连击技能
        {
            if (combo.movement_names[InputedMovements.Count] != currentMovement.name)
            {
                list_for_remove.Add(combo);
            }
            else {
                if (combo.movement_names.Length == InputedMovements.Count + 1) {
                    //释放该combo
                    ReleaseComboSkill(combo);
                    //删掉该combo
                    list_for_remove.Add(combo);
                }

            }
        }
        //删除所有在当前出入的招式序列中不会产生的combo
        foreach (ComboSkill combo in list_for_remove)
        {
            tempPossibleComboSkills.Remove(combo);
        }

        //如果有可能释放的技能列表为空
        if (tempPossibleComboSkills.Count == 0)
        {
            InputedMovements.Clear();
            tempPossibleComboSkills = new List<ComboSkill>(MasteredComboSkills);
        }
        //将新输入的招式添加到输入序列中
        InputedMovements.Add(currentMovement.name);
    }


}




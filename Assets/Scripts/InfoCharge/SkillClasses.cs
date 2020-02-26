using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/// <summary>
/// 技能基类
/// </summary>
public class Skill {
    public string id;
    public string name;
    public string description;


    public Skill(string ID,string Name,string Description) {
        id = ID;
        name = Name;
        description = Description;
    }


}

/// <summary>
/// 基本操作（招式）类
/// </summary>
public class Movement {
    public string name;
    public string animation_name;
    public float animation_time;
    public Movement(string Name,string AnimationName,float AnimationTime) {
        name = Name;
        animation_name = AnimationName;
        animation_time = AnimationTime;

    }

}

/// <summary>
/// 连击技能类
/// </summary>
public class ComboSkill :Skill{
    public int energy_consume;
    public string animation_name;
    public float animation_time;
    public string[] movement_names;

    public ComboSkill(string ID, string Name, string Description, int EnergyConsume,string AnimationName,float AnimationTime,string MovementSequence) : base(ID,Name,Description)
    {
        energy_consume = EnergyConsume;
        animation_name = AnimationName;
        animation_time = AnimationTime;
        movement_names = MovementSequence.Split(',');
    }

}


/// <summary>
/// 主动技能类
/// </summary>
public class ActiveSkill : Skill {
    public string animation_name;
    public int mana_consume;
    public float cooldown;
    public float animation_time;

    public ActiveSkill(string ID, string Name, string Description, int mana_consume, string AnimationName, float AnimationTime) : base(ID, Name, Description)
    {

    }
}


﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace DungeonSlayers.Models
{
    public abstract class Identifiable
    {
        [Key]
        public int Id { get; set; }
    }
    public abstract class Entity : Identifiable
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
        public string Note { get; set; }
    }
    public class Companion : Entity
    {
        public Character Master { get; set; }
    }
    public class Character : Entity
    {
        public ApplicationUser Owner { get; set; }
        public string Race { get; set; }
        public int Level { get; set; }
        [NotMapped]
        public int TotalPP { get; set; }
        public int PP { get; set; }
        [NotMapped]
        public int TotalTP { get; set; }
        public int TP { get; set; }
        public string ClassName { get; set; }
        public string HeroClassName { get; set; }
        public int ExperiencePoints { get; set; }
        public Size Size { get; set; }

        public Gender Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; } 
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Special { get; set; }
        public string Languages { get; set; }
        public string Alphabets { get; set; }
        
        public ICollection<RacialAbility> RacialAbilities { get; set; }
        
        public ICollection<Spell> Spells { get; set; }
        
        public ICollection<CharacterTalent> Talents { get; set; }
        
        public ICollection<CharacterEquipment> Weapons { get; set; }
        
        public ICollection<CharacterArmor> Armors { get; set; }
        
        public ICollection<CharacterEquipment> Equipment { get; set; }

        public ICollection<Companion> Companions { get; set;}
    }
    public enum Size { Tiny, Small, Normal, Large, Huge, Colossal}
    public enum Gender { Male, Female, Other }
    public class CharacterTalent
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int TalentId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Talent Talent { get; set; }
        public int Rank { get; set; }
    }
    public class CharacterEquipment
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int EquipmentId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Equipment Equipment { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Modifier> Modifiers { get; set; }
    }
    public class CharacterArmor
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int ArmorId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Armor Armor { get; set; }
        public virtual ICollection<Modifier> Modifiers { get; set; }
    }
    public class CharacterWeapon
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int WeaponId { get; set; }

        public virtual Character Character { get; set; }
        public virtual Weapon Weapon { get; set; }
        public bool Equipped { get; set; }
        public int Quantity { get; set; }
        public virtual ICollection<Modifier> Modifiers { get; set; }
    }
    public abstract class Modifier : Identifiable
    {
        public string Description { get; set;}
        public int BonusValue { get; set; }
    }
    public class PropertyModifier : Modifier
    {
        public PropertyName AttributeBonus { get; set; }
    }
    public class CheckModifier : Modifier
    {
        public string Check{ get; set; }
    }
    public enum PropertyName { Body, Mobility, Mind, Strength, Constitution, Agility, Dexterity, Intellect, Aura, HitPoints, Defense, Initiative, MovementRate, MeleeAttack, RangedAttack, Spellcasting, TargetedSpellcasting }
    public class Property : Identifiable
    {
        public Character Character { get; set; }
        public PropertyName Name { get; set; }
        public string Acronym { get; set; }
        public float Value { get; set; }
        public bool Derived { get; set; }
        public string Equation { get; set; }
    }
    ////Body, Mobility, Mind
    //public class Attribute : Characteristic
    //{

    //}
    ////Strength, Constitution, Agility, Dexterity, Intellect, Aura
    //public class Trait : Characteristic
    //{

    //}
    ////HitPoints, Defense, Initiative,MovementRate,MeleeAttack,RangedAttack,Spellcasting,TargetedSpellcasting
    //public class CombatValues : Characteristic
    //{

    //}
}
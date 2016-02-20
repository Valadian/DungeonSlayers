using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DungeonSlayers.Models
{
    public abstract class KoEntity
    {
        [NotMapped]
        public bool _destroy { get; set; }
        [NotMapped]
        public bool _new { get; set; }
    }
    public abstract class Identifiable : KoEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || obj.GetType() != GetType())
        //    {
        //        return false;
        //    }

        //    return Id == (obj as Identifiable)?.Id;
        //}
    }
    public abstract class NamedIdentifiable : Identifiable
    {
        public string Name { get; set; }
    }
    public abstract class Being : NamedIdentifiable
    {
        //public List<Property> Properties { get; set; }
        public string Note { get; set; }
        
        public int BOD { get; set; }
        public int MOB { get; set; }
        public int MND { get; set; }
        public int ST { get; set; }
        public int CO { get; set; }
        public int AG { get; set; }
        public int DX { get; set; }
        public int IN { get; set; }
        public int AU { get; set; }
    }
    public class Companion : Being
    {
        public Character Master { get; set; }
    }
    public class Character : Being
    {
        public ApplicationUser Owner { get; set; }
        public string Race { get; set; }
        public int Level { get; set; } = 1;
        [NotMapped]
        public int TotalPP { get; set; }
        public int PP { get; set; } = 0;
        [NotMapped]
        public int TotalTP { get; set; }
        public int TP { get; set; } = 0;
        public string ClassName { get; set; }
        public string HeroClassName { get; set; }
        public int ExperiencePoints { get; set; } = 0;
        public Size Size { get; set; } = Size.Small;

        public Gender Gender { get; set; } = Gender.Male;
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

        [NotMapped]
        public Property AV { get; set; }
        [NotMapped]
        public Property HitPoints { get; set; }
        [NotMapped]
        public Property Defense { get; set; }
        [NotMapped]
        public Property Initiative { get; set; }
        [NotMapped]
        public Property Movement { get; set; }
        [NotMapped]
        public Property MeleeAttack { get; set; }
        [NotMapped]
        public Property RangedAttack { get; set; }
        [NotMapped]
        public Property SpellCast { get; set; }
        [NotMapped]
        public Property TargettedSpellCast { get; set; }
        public int Gold { get; set; }
        public int Silver { get; set; }
        public int Copper { get; set; }

        public virtual ICollection<RacialAbility> RacialAbilities { get; set; } = new List<RacialAbility>();

        public virtual ICollection<CharacterSpell> Spells { get; set; } = new List<CharacterSpell>();

        public virtual ICollection<CharacterTalent> Talents { get; set; } = new List<CharacterTalent>();
        
        public virtual ICollection<CharacterWeapon> Weapons { get; set; } = new List<CharacterWeapon>();

        public virtual ICollection<CharacterArmor> Armors { get; set; } = new List<CharacterArmor>();

        public virtual ICollection<CharacterEquipment> Equipments { get; set; } = new List<CharacterEquipment>();
        public virtual ICollection<MagicEquipment> MagicEquipments { get; set; } = new List<MagicEquipment>();

        public virtual ICollection<Companion> Companions { get; set; } = new List<Companion>();
    }
    public enum Size { Tiny, Small, Normal, Large, Huge, Colossal}
    public enum Gender { Male, Female, Other }
    public abstract class Equippable : KoEntity
    {

        public virtual bool Equipped { get; set; }
        public virtual ICollection<Modifier> Modifiers { get; set; }
        public string Note { get; set; }
    }
    public abstract class IdentifiableEquippable : Identifiable
    {
        public virtual bool Equipped { get; set; }
        public virtual ICollection<Modifier> Modifiers { get; set; }
        public string Note { get; set; }
    }
    public class CharacterTalent : Equippable
    {
        [Key, ForeignKey("Character"), Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, ForeignKey("Talent"), Column(Order = 1)]
        public int TalentId { get; set; }
        public override bool Equals(object obj)
        {
            return (CharacterId == (obj as CharacterTalent)?.CharacterId) &&
                   (TalentId == (obj as CharacterTalent)?.TalentId);
        }

        public virtual Character Character { get; set; }
        public virtual Talent Talent { get; set; }
        public int Rank { get; set; }
        //[NotMapped]
        //public override bool Equipped { get; set; } = true;
    }
    public class CharacterEquipment : Equippable
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int EquipmentId { get; set; }
        public override bool Equals(object obj)
        {
            return (CharacterId == (obj as CharacterEquipment)?.CharacterId) &&
                   (EquipmentId == (obj as CharacterEquipment)?.EquipmentId);
        }

        public virtual Character Character { get; set; }
        public virtual Equipment Equipment { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
    }
    public class MagicEquipment : IdentifiableEquippable
    {
        public Character Character { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
    }
    public class CharacterSpell : Equippable
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int SpellId { get; set; }
        public override bool Equals(object obj)
        {
            return (CharacterId == (obj as CharacterSpell)?.CharacterId) &&
                   (SpellId == (obj as CharacterSpell)?.SpellId);
        }

        public virtual Character Character { get; set; }
        public virtual Spell Spell { get; set; }
    }
    public class CharacterArmor : Equippable
    {
        [Key, Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, Column(Order = 1)]
        public int ArmorId { get; set; }
        public override bool Equals(object obj)
        {
            return (CharacterId == (obj as CharacterArmor)?.CharacterId) &&
                   (ArmorId == (obj as CharacterArmor)?.ArmorId);
        }

        public virtual Character Character { get; set; }
        public virtual Armor Armor { get; set; }
    }
    public class CharacterWeapon : Equippable
    {
        [Key, ForeignKey("Character"), Column(Order = 0)]
        public int CharacterId { get; set; }
        [Key, ForeignKey("Weapon"), Column(Order = 1)]
        public int WeaponId { get; set; }
        public override bool Equals(object obj)
        {
            return (CharacterId == (obj as CharacterWeapon)?.CharacterId) &&
                   (WeaponId == (obj as CharacterWeapon)?.WeaponId);
        }
        [JsonIgnore]
        public virtual Character Character { get; set; }
        public virtual Weapon Weapon { get; set; }
        public int Quantity { get; set; }
    }
    public class Modifier : Identifiable
    {
        public string Name { get; set; }
        public string Description { get; set;}
        public double Value { get; set; }
    }
    //public class PropertyModifier : Modifier
    //{
    //    public PropertyName AttributeBonus { get; set; }
    //}
    //public class CheckModifier : Modifier
    //{
    //    public string Check{ get; set; }
    //}
    public enum PropertyName { Body, Mobility, Mind, Strength, Constitution, Agility, Dexterity, Intellect, Aura, HitPoints, Defense, Initiative, MovementRate, MeleeAttack, RangedAttack, Spellcasting, TargetedSpellcasting, ArmorValue, WeaponBonus, SpellModifier }
    public enum PropertyType { Attribute, Trait, CombatValue, Misc}
    public class Property : Identifiable
    {
        public Character Character { get; set; }
        public float Base { get; set; }
        public PropertyDef Definition { get; set; }
    }
    public class PropertyDef : Identifiable
    {
        public PropertyName Name { get; set; }
        public PropertyType PropType { get; set; }
        public string Acronym { get; set; }
        public string DisplayName { get; set; }
        public bool Derived { get; set; } = false;
        public string Equation { get; set; } = "";
        public string DataBinding { get; set; } = "";
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
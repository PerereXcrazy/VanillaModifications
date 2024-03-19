using System;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using NCMS.Utils;

namespace VanillaModifications
{
	public class Actors
    {
		public static void init()
        {
            //testing sync again
            ActorAsset dragon = AssetManager.actor_library.get(SA.dragon);
            dragon.traits.Add("super_health");
            dragon.base_stats[S.knockback_reduction] = 1f;
            dragon.canLevelUp = false;

            ActorAsset unit_human = AssetManager.actor_library.get("unit_human");
            unit_human.color_sets.Add(S_SkinColor.dwarf_default);
            unit_human.color_sets.Add(S_SkinColor.elf_default);
            unit_human.color_sets.Add(S_SkinColor.orc_default);

            ActorAsset baby_human = AssetManager.actor_library.get("baby_human");
            baby_human.color_sets.Add(S_SkinColor.dwarf_default);
            baby_human.color_sets.Add(S_SkinColor.elf_default);
            baby_human.color_sets.Add(S_SkinColor.orc_default);

            ActorAsset unit_elf = AssetManager.actor_library.get("unit_elf");
            unit_elf.color_sets.Add(S_SkinColor.human_default);
            unit_elf.color_sets.Add(S_SkinColor.dwarf_default);
            unit_elf.color_sets.Add(S_SkinColor.orc_default);
            unit_elf.setBaseStats(100, 15, 40, 0, 5, 92, 0);
            unit_elf.traits.Remove("weightless");
            unit_elf.traits.Remove("moonchild");

            ActorAsset baby_elf = AssetManager.actor_library.get("baby_elf");
            baby_elf.color_sets.Add(S_SkinColor.human_default);
            baby_elf.color_sets.Add(S_SkinColor.dwarf_default);
            baby_elf.color_sets.Add(S_SkinColor.orc_default);
            baby_elf.setBaseStats(100, 15, 40, 0, 5, 92, 0);
            baby_elf.traits.Remove("weightless");
            baby_elf.traits.Remove("moonchild");

            ActorAsset unit_orc = AssetManager.actor_library.get("unit_orc");
            unit_orc.color_sets.Add(S_SkinColor.human_default);
            unit_orc.color_sets.Add(S_SkinColor.dwarf_default);
            unit_orc.color_sets.Add(S_SkinColor.elf_default);
            unit_orc.setBaseStats(100, 15, 40, 0, 5, 92, 0);
            unit_orc.traits.Remove("regeneration");
            unit_orc.traits.Remove("nightchild");
            unit_orc.traits.Remove("savage");

            ActorAsset baby_orc = AssetManager.actor_library.get("baby_orc");
            baby_orc.color_sets.Add(S_SkinColor.human_default);
            baby_orc.color_sets.Add(S_SkinColor.dwarf_default);
            baby_orc.color_sets.Add(S_SkinColor.elf_default);
            baby_orc.setBaseStats(100, 15, 40, 0, 5, 92, 0);
            baby_orc.traits.Remove("regeneration");
            baby_orc.traits.Remove("nightchild");
            baby_orc.traits.Remove("savage");

            ActorAsset unit_dwarf = AssetManager.actor_library.get("unit_dwarf");
            unit_dwarf.color_sets.Add(S_SkinColor.human_default);
            unit_dwarf.color_sets.Add(S_SkinColor.elf_default);
            unit_dwarf.color_sets.Add(S_SkinColor.orc_default);
            unit_dwarf.setBaseStats(100, 15, 40, 0, 5, 92, 0);
            unit_dwarf.base_stats[S.attack_speed] = 60f;
            unit_dwarf.traits.Remove("miner");

            ActorAsset baby_dwarf = AssetManager.actor_library.get("baby_dwarf");
            baby_dwarf.color_sets.Add(S_SkinColor.human_default);
            baby_dwarf.color_sets.Add(S_SkinColor.elf_default);
            baby_dwarf.color_sets.Add(S_SkinColor.orc_default);
            baby_dwarf.setBaseStats(100, 15, 40, 0, 5, 92, 0);
            baby_dwarf.traits.Remove("miner");

            var Angel = AssetManager.actor_library.clone("angel", "_mob");
            Angel.nameLocale = "Anjo";
            Angel.nameTemplate = "fairy_name";
            Angel.flying = true;
            Angel.hovering = true;
            Angel.hovering_min = 0f;
            Angel.hovering_max = 0f;
            Angel.body_separate_part_head = false;
            Angel.body_separate_part_hands = false;
            Angel.defaultWeapons = List.Of<string>(new string[]
            {
            "angel_weapon"
            });
            Angel.defaultWeaponsMaterial = List.Of<string>(new string[]
            {
             "base"
            });
            Angel.use_items = true;
            Angel.shadow = false;
            Angel.race = SK.good;
            Angel.kingdom = SK.good;
            Angel.canBeKilledByDivineLight = false;
            Angel.base_stats[S.damage_range] = 0f;
            Angel.base_stats[S.health] = 222f;
            Angel.base_stats[S.speed] = 22f;
            Angel.base_stats[S.attack_speed] = 1f;
            Angel.base_stats[S.damage] = 22f;
            Angel.base_stats[S.knockback] = 1f;
            Angel.damagedByOcean = false;
            Angel.damagedByRain = false;
            Angel.dieInLava = false;
            Angel.icon = "iconDemon";
            Angel.needFood = false;
            Angel.color = Toolbox.makeColor("#ffffff", -1f);
            Angel.canTurnIntoZombie = false;
            Angel.canLevelUp = false;
            Angel.job = "move_mob";
            Angel.texture_path = "t_angel";
            Angel.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4";
            Angel.animation_idle = "idle_0,idle_1,idle_2,idle_3";
            Angel.disableJumpAnimation = true;
            Angel.actorSize = ActorSize.S14_Cow;
            Angel.ignoreBlocks = true;
            Angel.specialDeadAnimation = true;
            Angel.traits.Add("immortal");
            Angel.traits.Add("fire_proof");
            Angel.traits.Add("blessed");
            Angel.traits.Add("light_lamp");
            Angel.traits.Add("shiny");
            Angel.fmod_spawn = "event:/SFX/DROPS/DropBlessing";
            Angel.fmod_attack = "event:/SFX/UNITS/Fairy/FairyAttack";
            Angel.fmod_idle = "event:/SFX/POWERS/Blessing";
            Angel.fmod_death = "event:/SFX/DROPS/DropBlessing";
            Angel.fmod_theme = "Units_Fairy";
            Angel.action_get_hit = new GetHitAction(AngelReact);
            Angel.action_dead_animation = (WorldAction)Delegate.Combine(Angel.action_dead_animation, new WorldAction(angelDeath));
            Localization.addLocalization(Angel.id, Angel.nameLocale);
        }
        public static bool angelDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            BaseSimObject attackedBy = pTarget.a.attackedBy;
            pTarget.a.startColorEffect(ActorColorEffect.White);
            pTarget.a.colorEffect = 10f;
            pTarget.a.forceVector.z = 2f;
            pTarget.a.stats[S.scale] = 0f;
            pTarget.a.target_scale = 0f;
            if (pTarget.a.actor_scale > 0f)
            {
                pTarget.a.updateChangeScale(World.world.elapsed);
                return false;
            }
            pTarget.a.killHimself(true, AttackType.None, false, true, true);
            return true;
        }
        public static bool AngelReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            int regeneration = (int)pSelf.a.getMaxHealth() / 40;
            pSelf.a.restoreHealth(regeneration);
            pSelf.a.spawnParticle(Toolbox.color_white_32);
            pSelf.a.startColorEffect(ActorColorEffect.White);
            pSelf.a.colorEffect = 1f;
            if (pAttackedBy != null && pAttackedBy.isActor() && pAttackedBy.isAlive() && pSelf.a.data.health <= pAttackedBy.a.stats[S.damage] * 5 || pAttackedBy == null && pSelf.a.data.health <= pSelf.getMaxHealth() / 10)
            {
                Traits.DivineLightFX(pTile);
            }
            return true;
        }
    }
}

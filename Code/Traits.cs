using System;
using System.Threading;
using System.Reflection;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ai;
using HarmonyLib;

namespace VanillaModifications
{
    class Traits
    {
        public static void init()
        {
            float inherit = 62.5f;

            ActorTrait blessed = AssetManager.traits.get("blessed");
            blessed.group_id = TraitGroup.miscellaneous;
            blessed.inherit = inherit;
            blessed.action_attack_target = new AttackAction(BlessedAttack);
            blessed.action_special_effect = new WorldAction(BlessedConditions);
            blessed.action_death = new WorldAction(BlessedDeath);
            string[] oppositeArrCE = new string[] { "cursed", "evil" };
            blessed.oppositeArr = oppositeArrCE;
            blessed.special_effect_interval = 0;
            PlayerConfig.unlockTrait(blessed.id);

            ActorTrait cursed = AssetManager.traits.get("cursed");
            cursed.inherit = inherit;
            cursed.action_get_hit = new GetHitAction(CursedReact);
            cursed.action_special_effect = new WorldAction(CursedConditions);
            cursed.action_death = new WorldAction(CursedDeath);
            string[] oppositeArrBE = new string[] { "blessed", "evil" };
            cursed.oppositeArr = oppositeArrBE;
            cursed.special_effect_interval = 0;
            PlayerConfig.unlockTrait(blessed.id);

            ActorTrait energized = AssetManager.traits.get("energized");
            energized.group_id = TraitGroup.miscellaneous;
            energized.inherit = inherit;
            energized.action_get_hit = new GetHitAction(LightningReact);
            energized.action_attack_target = new AttackAction(LightningAttack);
            energized.action_special_effect = new WorldAction(LightningConditions);
            energized.action_death = new WorldAction(LightningDeath);
            energized.special_effect_interval = 0;
            PlayerConfig.unlockTrait(energized.id);

            ActorTrait mega_heartbeat = AssetManager.traits.get("mega_heartbeat");
            mega_heartbeat.group_id = TraitGroup.miscellaneous;
            mega_heartbeat.inherit = inherit;
            mega_heartbeat.base_stats[S.knockback_reduction] = 1f;
            mega_heartbeat.action_get_hit = new GetHitAction(ForceReact);
            mega_heartbeat.action_special_effect = new WorldAction(ForceConditions);
            mega_heartbeat.action_death = new WorldAction(ForceDeath);
            mega_heartbeat.special_effect_interval = 0;
            PlayerConfig.unlockTrait(mega_heartbeat.id);

            ActorTrait whirlwind = AssetManager.traits.get("whirlwind");
            whirlwind.group_id = TraitGroup.miscellaneous;
            whirlwind.inherit = inherit;
            whirlwind.base_stats[S.knockback_reduction] = 1f;
            whirlwind.action_special_effect = new WorldAction(TornadoConditions);
            whirlwind.action_death = new WorldAction(TornadoDeath);
            PlayerConfig.unlockTrait(whirlwind.id);

            ActorTrait fire_blood = AssetManager.traits.get("fire_blood");
            fire_blood.group_id = TraitGroup.miscellaneous;
            fire_blood.inherit = inherit;
            fire_blood.action_special_effect = new WorldAction(FireUltimato);
            fire_blood.action_death = (WorldAction)Delegate.Combine(fire_blood.action_death, new WorldAction(FireDeath));
            string[] oppositeArrIce = new string[] { "cold_aura" };
            fire_blood.oppositeArr = oppositeArrIce;
            PlayerConfig.unlockTrait(fire_blood.id);

            ActorTrait cold_aura = AssetManager.traits.get("cold_aura");
            cold_aura.group_id = TraitGroup.miscellaneous;
            cold_aura.inherit = inherit;
            cold_aura.action_special_effect = new WorldAction(IceConditions);
            cold_aura.action_death = new WorldAction(IceDeath);
            string[] oppositeArrFire = new string[] { "fire_blood" };
            cold_aura.oppositeArr = oppositeArrFire;
            PlayerConfig.unlockTrait(cold_aura.id);

            ActorTrait acid_blood = AssetManager.traits.get("acid_blood");
            acid_blood.group_id = TraitGroup.miscellaneous;
            acid_blood.inherit = inherit;
            acid_blood.action_special_effect = new WorldAction(AcidConditions);
            acid_blood.action_death = (WorldAction)Delegate.Combine(acid_blood.action_death, new WorldAction(AcidDeath));
            string[] oppositeArrNature = new string[] { "flower_prints" };
            acid_blood.oppositeArr = oppositeArrNature;
            PlayerConfig.unlockTrait(acid_blood.id);

            ActorTrait venomous = AssetManager.traits.get("venomous");
            venomous.group_id = TraitGroup.miscellaneous;
            venomous.inherit = inherit;
            venomous.action_get_hit = new GetHitAction(PoisonReact);
            venomous.action_special_effect = new WorldAction(PoisonConditions);
            venomous.action_death = new WorldAction(PoisonDeath);
            venomous.special_effect_interval = 0;
            PlayerConfig.unlockTrait(venomous.id);

            ActorTrait flower_prints = AssetManager.traits.get("flower_prints");
            flower_prints.group_id = TraitGroup.miscellaneous;
            flower_prints.inherit = inherit;
            flower_prints.action_get_hit = new GetHitAction(NatureReact);
            flower_prints.action_special_effect = new WorldAction(NatureConditions);
            flower_prints.action_death = new WorldAction(NatureDeath);
            string[] oppositeArrAcid = new string[] { "acid_blood" };
            flower_prints.oppositeArr = oppositeArrAcid;
            flower_prints.special_effect_interval = 0;
            PlayerConfig.unlockTrait(flower_prints.id);

            ActorTrait dragonslayer = AssetManager.traits.get("dragonslayer");
            dragonslayer.group_id = TraitGroup.miscellaneous;
            dragonslayer.base_stats[S.knockback_reduction] = 0.5f;
            dragonslayer.base_stats[S.mod_armor] = 1f;
            dragonslayer.base_stats[S.mod_speed] = -0.125f;
            dragonslayer.base_stats[S.mod_damage] = 0.75f;
            dragonslayer.base_stats[S.mod_attack_speed] = -0.75f;
            dragonslayer.inherit = inherit;
            dragonslayer.action_special_effect = new WorldAction(DragonbornConditions);
            dragonslayer.action_get_hit = new GetHitAction(DragonbornReact);
            dragonslayer.action_death = new WorldAction(DragonbornDeath);
            dragonslayer.special_effect_interval = 0;
            string[] oppositeArrMage = new string[] { "mageslayer" };
            dragonslayer.oppositeArr = oppositeArrMage;
            PlayerConfig.unlockTrait(dragonslayer.id);

            ActorTrait mageslayer = AssetManager.traits.get("mageslayer");
            mageslayer.group_id = TraitGroup.miscellaneous;
            mageslayer.inherit = inherit;
            mageslayer.action_get_hit = new GetHitAction(MageReact);
            mageslayer.action_special_effect = new WorldAction(MagicConditions);
            mageslayer.action_attack_target = new AttackAction(MageAttack);
            mageslayer.action_death = new WorldAction(MageDeath);
            string[] oppositeArrDragonBorn = new string[] { "dragonslayer" };
            mageslayer.oppositeArr = oppositeArrDragonBorn;
            PlayerConfig.unlockTrait(mageslayer.id);

            ActorTrait aa = AssetManager.traits.get("voices_in_my_head");
            aa.birth = 0f;
            aa.inherit = 25f;

            ActorTrait ab = AssetManager.traits.get("lustful");
            ab.birth = 0f;
            ab.inherit = inherit;

            ActorTrait ac = AssetManager.traits.get("long_liver");
            ac.birth = 0f;
            ac.base_stats[S.max_age] = 250f;
            ac.inherit = inherit;

            ActorTrait ad = AssetManager.traits.get("golden_tooth");
            ad.birth = 0f;
            ad.inherit = 100f;
            ad.action_special_effect = new WorldAction(Golden_tooth);

            ActorTrait ae = AssetManager.traits.get("moonchild");
            ae.birth = 0f;
            ae.inherit = inherit;

            ActorTrait af = AssetManager.traits.get("nightchild");
            af.birth = 0f;
            af.inherit = inherit;

            ActorTrait ag = AssetManager.traits.get("light_lamp");
            ag.birth = 0f;
            ag.inherit = inherit;
            ag.group_id = TraitGroup.fun;

            ActorTrait ah = AssetManager.traits.get("flesh_eater");
            ah.birth = 0f;
            ah.inherit = inherit;
            ah.action_special_effect = new WorldAction(ReactiveChildren);

            ActorTrait ai = AssetManager.traits.get("shiny");
            ai.birth = 0f;
            ai.inherit = inherit;
            ai.group_id = TraitGroup.fun;

            ActorTrait aj = AssetManager.traits.get("super_health");
            aj.birth = 0f;
            aj.inherit = inherit;
            aj.base_stats[S.mod_health] = 9f;
            aj.base_stats[S.health] = 0;
            aj.base_stats[S.knockback_reduction] = 0.25f;

            ActorTrait ak = AssetManager.traits.get("death_nuke");
            ak.birth = 0f;
            ak.inherit = inherit;

            ActorTrait al = AssetManager.traits.get("death_bomb");
            al.birth = 0f;
            al.inherit = inherit;

            ActorTrait am = AssetManager.traits.get("death_mark");
            am.birth = 0f;
            am.special_effect_interval = 2.5f;

            ActorTrait an = AssetManager.traits.get("miracle_born");
            an.birth = 0f;
            an.base_stats[S.max_age] = 150f;
            an.base_stats[S.health] = 0;
            an.can_be_given = true;
            an.can_be_removed = true;

            ActorTrait ao = AssetManager.traits.get("healing_aura");
            ao.birth = 0f;
            ao.inherit = inherit;

            ActorTrait ap = AssetManager.traits.get("savage");
            ap.birth = 0f;
            ap.inherit = inherit;
            ap.action_special_effect = new WorldAction(ReactiveChildren);

            ActorTrait aq = AssetManager.traits.get("miner");
            aq.birth = 0f;
            aq.inherit = inherit;

            ActorTrait ar = AssetManager.traits.get("strong_minded");
            ar.birth = 0f;
            ar.inherit = inherit;

            ActorTrait ass = AssetManager.traits.get("scar_of_divinity");
            ass.base_stats[S.max_age] = 150f;
            ass.birth = 0f;
            ass.base_stats[S.health] = 0;
            ass.can_be_given = true;
            ass.can_be_removed = true;

            ActorTrait at = AssetManager.traits.get("kingslayer");
            at.birth = 0f;
            at.action_special_effect = new WorldAction(Kingslayer);
            at.special_effect_interval = 0;

            ActorTrait au = AssetManager.traits.get("crippled");
            au.base_stats[S.speed] = 0;
            au.base_stats[S.attack_speed] = 0;
            au.base_stats[S.mod_speed] -= 0.15f;
            au.base_stats[S.mod_attack_speed] -= 0.15f;

            ActorTrait av = AssetManager.traits.get("evil");
            av.birth = 0f;
            av.inherit = inherit;
            string[] oppositeArrBC = new string[] { "blessed", "cursed" };
            av.oppositeArr = oppositeArrBC;
            av.action_special_effect = new WorldAction(ReactiveChildren);

            ActorTrait aw = AssetManager.traits.get("giant");
            aw.birth = 0f;
            aw.inherit = inherit;
            string[] oppositeTD = new string[] { "tiny" };
            aw.oppositeArr = oppositeTD;

            ActorTrait ax = AssetManager.traits.get("tiny");
            ax.birth = 0f;
            ax.inherit = inherit;
            string[] oppositeGD = new string[] { "giant" };
            ax.oppositeArr = oppositeGD;

            ActorTrait ay = AssetManager.traits.get("immortal");
            ay.birth = 0f;
            ay.inherit = inherit;

            ActorTrait az = AssetManager.traits.get("eyepatch");
            az.base_stats[S.attack_speed] = 0;
            az.base_stats[S.mod_attack_speed] -= 0.15f;

            ActorTrait ba = AssetManager.traits.get("tough");
            ba.birth = 0f;
            ba.inherit = inherit;

            ActorTrait bb = AssetManager.traits.get("strong");
            bb.birth = 0f;
            bb.inherit = inherit;

            ActorTrait bc = AssetManager.traits.get("stupid");
            bc.birth = 0f;
            bc.inherit = inherit;

            ActorTrait bd = AssetManager.traits.get("genius");
            bd.birth = 0f;
            bd.inherit = inherit;

            ActorTrait be = AssetManager.traits.get("regeneration");
            be.birth = 0f;
            be.inherit = inherit;

            ActorTrait bf = AssetManager.traits.get("ugly");
            bf.birth = 0f;
            bf.inherit = inherit;

            ActorTrait bg = AssetManager.traits.get("fat");
            bg.birth = 0f;
            bg.inherit = inherit;

            ActorTrait bh = AssetManager.traits.get("attractive");
            bh.birth = 0f;
            bh.inherit = inherit;

            ActorTrait bi = AssetManager.traits.get("fast");
            bi.birth = 0f;
            bi.inherit = inherit;

            ActorTrait bj = AssetManager.traits.get("slow");
            bj.birth = 0f;
            bj.inherit = inherit;

            ActorTrait bk = AssetManager.traits.get("gluttonous");
            bk.birth = 0f;
            bk.inherit = inherit;
            bk.action_special_effect = new WorldAction(Gluttonous);

            ActorTrait bl = AssetManager.traits.get("burning_feet");
            bl.birth = 0f;
            bl.inherit = inherit;

            ActorTrait bm = AssetManager.traits.get("acid_touch");
            bm.birth = 0f;
            bm.inherit = inherit;

            ActorTrait bn = AssetManager.traits.get("ratKing");
            bn.action_death = new WorldAction(plagueDeath);

            ActorTrait bo = AssetManager.traits.get("rat");
            bo.action_death = new WorldAction(plagueDeath);

            ActorTrait bp = AssetManager.traits.get("acid_proof");
            bp.birth = 0f;
            bp.inherit = inherit;

            ActorTrait br = AssetManager.traits.get("fire_proof");
            br.birth = 0f;
            br.inherit = inherit;

            ActorTrait bs = AssetManager.traits.get("freeze_proof");
            bs.birth = 0f;
            bs.inherit = inherit;

            ActorTrait bt = AssetManager.traits.get("wise");
            bt.action_special_effect = new WorldAction(Wise);

            ActorTrait bv = AssetManager.traits.get("thorns");
            bv.birth = 0f;
            bv.inherit = inherit;

            ActorTrait bw = AssetManager.traits.get("bubble_defense");
            bw.birth = 0f;
            bw.inherit = inherit;
            bw.action_get_hit = new GetHitAction(accuratebubbleDefense);

            ActorTrait bx = AssetManager.traits.get("bomberman");
            bx.birth = 0f;
            bx.inherit = inherit;

            ActorTrait by = AssetManager.traits.get("pyromaniac");
            by.birth = 0f;
            by.inherit = inherit;

            ActorTrait bz = AssetManager.traits.get("eagle_eyed");
            bz.birth = 0f;
            bz.inherit = inherit;

            ActorTrait ca = AssetManager.traits.get("short_sighted");
            ca.birth = 0f;
            ca.inherit = inherit;

            ActorTrait cb = AssetManager.traits.get("infertile");
            cb.birth = 0f;
            cb.inherit = inherit;

            ActorTrait cc = AssetManager.traits.get("fertile");
            cc.birth = 0f;
            cc.inherit = inherit;

            ActorTrait cd = AssetManager.traits.get("lucky");
            cd.birth = 0f;
            cd.inherit = inherit;

            ActorTrait ce = AssetManager.traits.get("unlucky");
            ce.birth = 0f;
            ce.inherit = inherit;

            ActorTrait cf = AssetManager.traits.get("immune");
            cf.birth = 0f;
            cf.inherit = inherit;

            ActorTrait cg = AssetManager.traits.get("agile");
            cg.birth = 0f;
            cg.inherit = inherit;

            ActorTrait ch = AssetManager.traits.get("deceitful");
            ch.birth = 0f;
            ch.inherit = inherit;

            ActorTrait ci = AssetManager.traits.get("pacifist");
            ci.birth = 0f;
            ci.inherit = inherit;

            ActorTrait cj = AssetManager.traits.get("ambitious");
            cj.birth = 0f;
            cj.inherit = inherit;

            ActorTrait ck = AssetManager.traits.get("content");
            ck.birth = 0f;
            ck.inherit = inherit;

            ActorTrait cl = AssetManager.traits.get("honest");
            cl.birth = 0f;
            cl.inherit = inherit;

            ActorTrait cm = AssetManager.traits.get("paranoid");
            cm.birth = 0f;
            cm.inherit = inherit;

            ActorTrait cn = AssetManager.traits.get("greedy");
            cn.birth = 0f;
            cn.inherit = inherit;

            ActorTrait co = AssetManager.traits.get("weightless");
            co.birth = 0f;
            co.inherit = inherit;

            ActorTrait cp = AssetManager.traits.get("poisonous");
            cp.birth = 0f;
            cp.inherit = inherit;

            ActorTrait cr = AssetManager.traits.get("poison_immune");
            cr.birth = 0f;
            cr.inherit = inherit;

            ActorTrait ct = AssetManager.traits.get("weak");
            ct.birth = 0f;
            ct.inherit = inherit;

            ActorTrait cu = AssetManager.traits.get("bloodlust");
            cu.birth = 0f;
            cu.inherit = inherit;
            cu.action_special_effect = new WorldAction(ReactiveChildren);
        }
        public static void addTraitToLocalizedLibrary(string id, string description)
        {
            string language = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "language") as string;
            Dictionary<string, string> localizedText = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "localizedText") as Dictionary<string, string>;
            localizedText.Add("trait_" + id, id);
            localizedText.Add("trait_" + id + "_info", description);
        }
        public static string RandomRace(BaseSimObject pTarget)
        {
            string[] unitOptions = { SA.unit_human, SA.unit_elf, SA.unit_orc, SA.unit_dwarf };
            double[] probabilities = { 0.25, 0.25, 0.25, 0.25 };

            for (int i = 0; i < unitOptions.Length; i++)
            {
                if (pTarget.a.asset.id == unitOptions[i])
                {
                    probabilities[i] += 0.375;
                    for (int j = 0; j < probabilities.Length; j++)
                    {
                        if (j != i)
                        {
                            probabilities[j] -= 0.125;
                        }
                    }
                }
            }
            return ChooseRandomUnit(unitOptions, probabilities);
        }
        static string ChooseRandomUnit(string[] options, double[] probabilities)
        {
            double randomValue = new System.Random().NextDouble();
            double cumulativeProbability = 0;
            for (int i = 0; i < options.Length; i++)
            {
                cumulativeProbability += probabilities[i];

                if (randomValue <= cumulativeProbability)
                {
                    return options[i];
                }
            }

            return options[0];
        }
        public static bool generateCivUnitTraitsWithoutBirth(BaseSimObject pTarget)
        {
            if (pTarget == null)
            {
                return false;
            }
            int ChooseOneInTheList = Toolbox.randomInt(1, AssetManager.traits.list.Count);
            ActorTrait actorTrait = AssetManager.traits.list[ChooseOneInTheList];
            if (actorTrait.inherit != 0f && actorTrait.can_be_given == true)
            {
                float num = Toolbox.randomFloat(0f, 100f);
                if (actorTrait.inherit >= num && !pTarget.a.data.traits.Contains(actorTrait.id) && !pTarget.a.data.haveOppositeTrait(actorTrait))
                {
                    pTarget.a.data.addTrait(actorTrait.id);
                }
            }
            return true;
        }
        public static bool plagueDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (World.world_era.id == "age_ash")
            {
                traitDeathEffect(pTarget, SD.plague);
            }
            return true;
        }
        public static bool traitDeathEffect(BaseSimObject pTarget, string pDrop)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Toolbox.randomBool())
                {
                    World.world.dropManager.spawnParabolicDrop(pTarget.a.currentTile, pDrop, 0f, 0.1f, 5f, 0.5f, 4f, 0.15f);
                }
            }
            if (!pTarget.isActor())
            {
                return true;
            }
            if (pTarget.a.asset.actorSize < ActorSize.S17_Dragon)
            {
                return true;
            }
            for (int j = 0; j < 25; j++)
            {
                if (Toolbox.randomBool())
                {
                    World.world.dropManager.spawnParabolicDrop(pTarget.a.currentTile, pDrop, 0f, 0.1f, 10f, 0.5f, 10f, 0.15f);
                }
                for (int k = 0; k < pTarget.a.currentTile.neighboursAll.Length; k++)
                {
                    WorldTile pTile2 = pTarget.a.currentTile.neighboursAll[k];
                    if (Toolbox.randomBool())
                    {
                        World.world.dropManager.spawnParabolicDrop(pTile2, pDrop, 0f, 0.1f, 10f, 0.5f, 7f, 0.15f);
                    }
                }
            }
            return true;
        }
        public static void clearBadTraitsFrom(BaseSimObject pTarget)
        {
            pTarget.a.removeTrait("infected");
            pTarget.a.removeTrait("plague");
            pTarget.a.removeTrait("mushSpores");
            pTarget.a.removeTrait("tumorInfection");
            pTarget.a.removeTrait("crippled");
            pTarget.a.removeTrait("eyepatch");
            pTarget.a.removeTrait("skin_burns");
        }
        public static void PopulateWorld(BaseSimObject pTarget)
        {
            Actor a = pTarget.a;
            if (!a.is_moving && a.city != null && a.kingdom.getPopulationTotal() == 1)
            {
                string chosenUnit = RandomRace(a);
                Actor unit = World.world.units.spawnNewUnit(chosenUnit, pTarget.currentTile, true, 0f);
                unit.addTrait("miracle_born");
                generateCivUnitTraitsWithoutBirth(unit);
                TeleportRandom(unit);
                EffectsLibrary.spawnAt("fx_spawn2", unit.currentPosition, unit.stats[S.scale]);
            }
        }
        public static bool DivineLightFX(WorldTile pTile)
        {
            World.world.fxDivineLight.playOn(pTile);
            for (int i = 0; i < 100; i++)
            {
                if (World.world.fxDivineLight.isOn)
                {
                    World.world.fxDivineLight.raySpawn.playType = AnimPlayType.Forward;
                    World.world.fxDivineLight.baseSpawn.playType = AnimPlayType.Forward;
                    if (World.world.fxDivineLight.raySpawn.isLastFrame())
                    {
                        World.world.fxDivineLight.raySpawn.gameObject.SetActive(false);
                        World.world.fxDivineLight.rayIdle.gameObject.SetActive(true);
                    }
                    else
                    {
                        World.world.fxDivineLight.raySpawn.gameObject.SetActive(true);
                        World.world.fxDivineLight.rayIdle.gameObject.SetActive(false);
                    }
                    if (World.world.fxDivineLight.baseSpawn.isLastFrame())
                    {
                        World.world.fxDivineLight.baseSpawn.gameObject.SetActive(false);
                        World.world.fxDivineLight.baseIdle.gameObject.SetActive(true);
                    }
                    else
                    {
                        World.world.fxDivineLight.baseSpawn.gameObject.SetActive(true);
                        World.world.fxDivineLight.baseIdle.gameObject.SetActive(false);
                    }
                }
                else
                {
                    World.world.fxDivineLight.raySpawn.playType = AnimPlayType.Backward;
                    World.world.fxDivineLight.baseSpawn.playType = AnimPlayType.Backward;
                    World.world.fxDivineLight.rayIdle.gameObject.SetActive(false);
                    World.world.fxDivineLight.baseIdle.gameObject.SetActive(false);
                    if (World.world.fxDivineLight.raySpawn.isFirstFrame())
                    {
                        World.world.fxDivineLight.raySpawn.gameObject.SetActive(false);
                    }
                    else
                    {
                        World.world.fxDivineLight.raySpawn.gameObject.SetActive(true);
                    }
                    if (World.world.fxDivineLight.baseSpawn.isFirstFrame())
                    {
                        World.world.fxDivineLight.baseSpawn.gameObject.SetActive(false);
                    }
                    else
                    {
                        World.world.fxDivineLight.baseSpawn.gameObject.SetActive(true);
                    }
                }
                if (World.world.fxDivineLight.baseSpawn.gameObject.activeSelf)
                {
                    World.world.fxDivineLight.baseSpawn.update(World.world.deltaTime);
                }
                if (World.world.fxDivineLight.baseIdle.gameObject.activeSelf)
                {
                    World.world.fxDivineLight.baseIdle.update(World.world.deltaTime);
                }
                if (World.world.fxDivineLight.raySpawn.gameObject.activeSelf)
                {
                    World.world.fxDivineLight.raySpawn.update(World.world.deltaTime);
                }
                if (World.world.fxDivineLight.rayIdle.gameObject.activeSelf)
                {
                    World.world.fxDivineLight.rayIdle.update(World.world.deltaTime);
                }
            }
            World.world.fxDivineLight.isOn = false;
            return true;
        }
        public static bool drawTemperaturePlusPlus(WorldTile pTile, string pPower)
        {
            if (pTile.isTemporaryFrozen() && Toolbox.randomBool())
            {
                pTile.unfreeze(7);
            }
            WorldBehaviourUnitTemperatures.checkTile(pTile, 5);
            if (pTile.Type.lava)
            {
                LavaHelper.heatUpLava(pTile);
            }
            if (pTile.building && pTile.building.asset.spawn_drops)
            {
                pTile.building.data.removeFlag(S.stop_spawn_drops);
            }
            return true;
        }
        public static BrushData ApropriateBrush(Actor pActor)
        {
            if (pActor.asset.id == SA.druid)
            {
                BrushData brush = Brush.get(1, "diamond_");
                return brush;
            }
            else if (pActor.data.level == 1)
            {
                BrushData brush = Brush.get(1, "circ_");
                return brush;
            }
            else if (pActor.data.level < 4)
            {
                BrushData brush = Brush.get(2, "circ_");
                return brush;
            }
            else if (pActor.data.level < 7)
            {
                BrushData brush = Brush.get(1, "diamond_");
                return brush;
            }
            else
            {
                BrushData brush = Brush.get(3, "circ_");
                return brush;
            }
            return null;
        }
        public static bool StatusTrait(Actor a, string pStatusTrait)
        {
            return (a.hasStatus(pStatusTrait) && !a.hasTrait(pStatusTrait)) || (!a.hasStatus(pStatusTrait) && a.hasTrait(pStatusTrait));
        }
        public static string MageType(Actor a)
        {
            if (!a.hasTrait("veteran"))
            {
                if (a.data.level < 5 && !isCorrupted(a))
                {
                    if (a.data.level > 1 || StatusTrait(a, "peaceful") || a.hasTrait("wise"))
                    {
                        if (!a.hasStatus("death_mark") && !a.hasStatus("voices_in_my_head"))
                        {
                            return "whitemage";
                        }
                    }
                }
                if (a.data.level < 9)
                {
                    if (a.data.level > 4 || StatusTrait(a, "death_mark") || isCorrupted(a))
                    {
                        if (!a.hasStatus("peaceful") && !a.hasStatus("voices_in_my_head"))
                        {
                            return "necromancer";
                        }
                    }
                }
            }
            if (a.data.level > 8 || StatusTrait(a, "voices_in_my_head") || a.hasTrait("veteran"))
            {
                if (!a.hasStatus("peaceful") && !a.hasStatus("death_mark") && !isCorrupted(a))
                {
                    return "evilmage";
                }
            }
            return null;
        }
        public static string ApropriateColor(BaseSimObject pTarget, string effect = null)
        {
            if (effect != null)
            {
                if (effect == "teleport")
                {
                    if (pTarget.a.hasTrait("evil") || pTarget.a.hasTrait("cursed"))
                    {
                        if (pTarget.a.hasTrait("fire_proof") || pTarget.a.hasTrait("immortal") || pTarget.a.hasTrait("madness"))
                        {
                            return "red";
                        }
                        else if (pTarget.a.hasTrait("regeneration") || isCorrupted(pTarget))
                        {
                            return "green";
                        }
                    }
                    else if (pTarget.a.hasTrait("freeze_proof") || pTarget.a.hasTrait("wise"))
                    {
                        return "blue";
                    }
                    else if (pTarget.a.hasTrait("blessed") || pTarget.a.hasTrait("miracle_born"))
                    {
                        return "yellow";
                    }
                    else
                    {
                        return "blue";
                    }
                }
                else if (effect == "shield")
                {
                    if (pTarget.a.hasTrait("dragonslayer") && pTarget.a.hasTrait("strong_minded"))
                    {
                        return "dragon";
                    }
                    else if (pTarget.a.hasTrait("evil") || pTarget.a.hasTrait("cursed"))
                    {
                        if (pTarget.a.hasTrait("fire_proof") || pTarget.a.hasTrait("immortal") || pTarget.a.hasTrait("madness"))
                        {
                            return "evil";
                        }
                        else if (pTarget.a.hasTrait("regeneration") || isCorrupted(pTarget))
                        {
                            return "necro";
                        }
                    }
                    else if (pTarget.a.hasTrait("freeze_proof") || pTarget.a.hasTrait("wise"))
                    {
                        return string.Empty;
                    }
                    else if (pTarget.a.hasTrait("blessed") || pTarget.a.hasTrait("miracle_born"))
                    {
                        return "blessed";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            else
            {
                if (pTarget.a.hasTrait("evil") || pTarget.a.hasTrait("cursed"))
                {
                    if (pTarget.a.hasTrait("fire_proof") && pTarget.a.hasTrait("immortal"))
                    {
                        return "evilmage";
                    }
                    else if (pTarget.a.hasTrait("regeneration"))
                    {
                        return "necromancer";
                    }
                }
                if (pTarget.a.hasTrait("freeze_proof"))
                {
                    return "whitemage";
                }
                else if (pTarget.a.hasTrait("blessed"))
                {
                    return "blessed";
                }
            }
            return null;
        }
        public static string ApropriateEffect(BaseSimObject pTarget, string effect, string extra = null)
        {
            if (ApropriateColor(pTarget, effect) != null)
            {
                if (effect == "teleport")
                {
                    string teleport = "fx_teleport_" + ApropriateColor(pTarget, "teleport");
                    return teleport;
                }
                else if (effect == "shield")
                {
                    string shield = ApropriateColor(pTarget, "shield") + "shield";
                    return shield;
                }
                else if (extra != null)
                {
                    if (extra == "ground" && ApropriateColor(pTarget) == "necromancer")
                    {
                        return "fx_cast_ground_whitemage";
                    }
                    else
                    {
                        string other = "fx_cast_" + extra + "_" + ApropriateColor(pTarget);
                        return other;
                    }
                }
            }
            return null;
        }
        public static bool isNoble(BaseSimObject pTarget)
        {
            return pTarget.a.data.profession == UnitProfession.Warrior || pTarget.a.data.profession == UnitProfession.King || pTarget.a.data.profession == UnitProfession.Leader || pTarget.a.data.clan != string.Empty;
        }
        public static bool isCorrupted(BaseSimObject pTarget)
        {
            return pTarget.a.hasTrait("zombie") || pTarget.a.hasTrait("plague") || pTarget.a.hasTrait("infected") || pTarget.a.hasTrait("tumorInfection") || pTarget.a.hasTrait("mushSpores") || pTarget.a.hasTrait("cursed") || pTarget.a.asset.nameLocale == "Skeleton" || pTarget.a.asset.kingdom == SK.tumor;
        }
        public static bool TeleportRandom(BaseSimObject pSelf)
        {
            TileIsland randomIslandGround = World.world.islandsCalculator.getRandomIslandGround(true);
            WorldTile worldTile;
            if (randomIslandGround == null)
            {
                worldTile = null;
            }
            else
            {
                MapRegion random = randomIslandGround.regions.GetRandom();
                worldTile = ((random != null) ? random.tiles.GetRandom<WorldTile>() : null);
            }
            WorldTile worldTile2 = worldTile;
            if (worldTile2 == null)
            {
                return false;
            }
            if (worldTile2.Type.block)
            {
                return false;
            }
            if (!worldTile2.Type.ground)
            {
                return false;
            }
            string text = ApropriateEffect(pSelf, "teleport");
            EffectsLibrary.spawnAt(text, pSelf.currentPosition, pSelf.a.stats[S.scale]);
            BaseEffect baseEffect = EffectsLibrary.spawnAt(text, worldTile2.posV3, pSelf.a.stats[S.scale]);
            if (baseEffect != null)
            {
                baseEffect.spriteAnimation.setFrameIndex(9);
            }
            pSelf.a.cancelAllBeh(null);
            pSelf.a.spawnOn(worldTile2, 0f);
            return true;
        }
        static string ApostropheDivino(char[] letras)
        {
            System.Random random = new System.Random();
            for (int i = letras.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                char temp = letras[i];
                letras[i] = letras[j];
                letras[j] = temp;
            }
            string Apostrophe = new string(letras);
            return Apostrophe;
        }
        static bool SameWords(string FirstWord, string SecondWord)
        {
            if (FirstWord == null || SecondWord == null)
            {
                return false;
            }
            var LettersArray1 = FirstWord.ToCharArray().ToList();
            var LettersArray2 = SecondWord.ToCharArray().ToList();
            if (LettersArray1.Count != LettersArray2.Count)
            {
                return false;
            }
            LettersArray1.Sort();
            LettersArray2.Sort();
            string ArrangedWords1 = new string(LettersArray1.ToArray());
            string ArrangedWords2 = new string(LettersArray2.ToArray());
            return ArrangedWords1.Equals(ArrangedWords2);
        }
        public static bool ReactiveChildren(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget.a.hasTrait("flesh_eater") || pTarget.a.hasTrait("savage") || pTarget.a.hasTrait("evil") || pTarget.a.hasTrait("bloodlust"))
            {
                pTarget.a.removeTrait("peaceful");
                return true;
            }
            return false;
        }
        public static bool Kingslayer(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            BaseSimObject attackedBy = a.attackedBy;
            if (a.asset.unit == false && a.kingdom.data.banner_icon_id == -1)
            {
                return false;
            }
            if (a.hasTrait("scar_of_divinity") || a.hasTrait("miracle_born"))
            {
                if (!a.isKing() && a.kingdom.king != null && !a.kingdom.king.hasTrait("kingslayer"))
                {
                    DivineLightFX(pTile);
                    a.kingdom.removeKing();
                    a.kingdom.setKing(a);
                    a.kingdom.king.setProfession(UnitProfession.King);
                    WorldLog.logNewKing(a.kingdom);
                }
            }
            else
            {
                if (attackedBy != null && attackedBy.isActor() && attackedBy.isAlive() && !a.isKing() && attackedBy.a.isKing() && attackedBy.a.data.health < attackedBy.getMaxHealth() / 4)
                {
                    for (int i = 0; i < a.data.level; i++)
                    {
                        DropsLibrary.action_friendship(attackedBy.kingdom.capital._cityTile);
                    }
                    if (!a.kingdom.isEnemy(attackedBy.kingdom))
                    {
                        attackedBy.kingdom.removeKing();
                        attackedBy.kingdom.king = a;
                        attackedBy.kingdom.king.setProfession(UnitProfession.King);
                    }
                    else
                    {
                        if (a.hasTrait("madness"))
                        {
                            a.removeTrait("madness");
                            attackedBy.kingdom.removeKing();
                        }
                        else
                        {
                            if (attackedBy.city != attackedBy.kingdom.capital)
                            {
                                attackedBy.city.finishCapture(a.kingdom);
                            }
                            else
                            {
                                attackedBy.kingdom.capital.finishCapture(a.kingdom);
                            }
                            attackedBy.kingdom.removeKing();
                            a.kingdom.removeKing();
                            a.kingdom.king = a;
                            a.kingdom.king.setProfession(UnitProfession.King);
                        }
                    }
                }
            }
            if (a.city != null && a.city.leader != null && a.kingdom.king != null && a.city.leader == a.kingdom.king)
            {
                a.city.removeLeader();
            }
            return true;
        }
        public static void Projectile(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile, string pID)
        {
            if (pSelf != null && pTarget != null && pTile != null && pID != null && pTarget.isActor() && pSelf.isActor())
            {
                Vector2Int pos = pTile.pos;
                if (pos != null)
                {
                    float pDist = Vector2.Distance(pTarget.currentPosition, pos);
                    if (pDist != null)
                    {
                        Vector3 newPoint = Toolbox.getNewPoint(pSelf.currentPosition.x, pSelf.currentPosition.y, (float)pos.x, (float)pos.y, pDist, true);
                        if (newPoint != null)
                        {
                            Vector3 newPoint2 = Toolbox.getNewPoint(pTarget.currentPosition.x, pTarget.currentPosition.y, (float)pos.x, (float)pos.y, pTarget.a.stats[S.size], true);
                            if (newPoint2 != null)
                            {
                                EffectsLibrary.spawnProjectile(pID, newPoint, newPoint2, 0.0f);
                            }
                        }
                    }
                }
            }

        }
        public static bool accuratebubbleDefense(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            if (pSelf.isAlive() && Toolbox.randomChance(0.1f))
            {
                pSelf.addStatusEffect(ApropriateEffect(pSelf, "shield"), 5f);
                return true;
            }
            return false;
        }
        public static void AttachEffect(BaseSimObject pSelf, string pID)
        {
            if (pSelf != null && pID != null)
            {
                BaseEffect baseEffect = EffectsLibrary.spawnAt(pID, pSelf.a.currentPosition, pSelf.a.stats[S.scale]);
                if (baseEffect != null)
                {
                    baseEffect.attachTo(pSelf.a);
                }
            }
        }
        public static bool Golden_tooth(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (a.data.profession == UnitProfession.Baby)
            {
                return false;
            }
            else if (a.data.profession != UnitProfession.Warrior && a.data.profession != UnitProfession.King && a.data.profession != UnitProfession.Leader && a.data.clan == string.Empty)
            {
                a.removeTrait("golden_tooth");
            }
            return true;
        }
        public static bool Wise(BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget.a.data.age_overgrowth < 40)
            {
                pTarget.a.data.age_overgrowth += 5;
            }
            return true;
        }
        public static bool Gluttonous(BaseSimObject pTarget, WorldTile pTile)
        {
            if (!pTarget.a.hasTrait("strong_minded") || !pTarget.a.hasTrait("fat"))
            {
                return false;
            }
            else if (pTarget.a.data.hunger <= 5)// jejumzin intermitente
            {
                pTarget.a.data.hunger = 5;
            }
            if (Toolbox.randomChance(0.0005f) && !pTarget.a.hasTrait("weightless"))
            {
                pTarget.a.addTrait("weightless");
                pTarget.a.removeTrait("strong_minded");
                pTarget.a.removeTrait("fat");
                pTarget.a.removeTrait("gluttonous");
            }
            return true;
        }
        public static void GiveWeapon(BaseSimObject pSelf, string pItemID, string pMaterial)
        {
            if (pSelf.a.asset.use_items == true)
            {
                char[] letras = { 'A', 'R', 'T', 'U', 'R' };
                string Apostrophe = ApostropheDivino(letras);
                ActorEquipmentSlot slot = pSelf.a.equipment.getSlot(EquipmentType.Weapon);
                ItemAsset weapon = AssetManager.items.get(pItemID);
                ItemData weaponwithmaterial = ItemGenerator.generateItem(weapon, pMaterial, 0, null, Apostrophe);
                slot.setItem(weaponwithmaterial);
                pSelf.a.setStatsDirty();
            }
        }
        public static bool GiveWeaponWithConditions(BaseSimObject pTarget, string pItemID, string pMaterial, string pTrait = null, string pTrait1 = null, string pEffect = null)
        {
            Actor a = pTarget.a;
            if (pTrait != null)
            {
                a.addTrait(pTrait);
            }
            if (isNoble(a) || a.hasTrait("scar_of_divinity"))
            {
                if (pTrait1 != null)
                {
                    a.addTrait(pTrait1);
                }
                if (!a.hasWeapon())
                {
                    GiveWeapon(pTarget, pItemID, pMaterial);
                    if (pEffect != null)
                    {
                        AttachEffect(pTarget, pEffect);
                    }
                }
                else
                {
                    ActorEquipmentSlot actorEquipmentSlot = a.equipment.weapon;
                    ItemData data = actorEquipmentSlot.data;
                    string Apostrophe = "ARTUR";
                    if (data.id != pItemID && !SameWords(data.by, Apostrophe))
                    {
                        GiveWeapon(pTarget, pItemID, pMaterial);
                        if (pEffect != null)
                        {
                            AttachEffect(pTarget, pEffect);
                        }
                    }
                }
            }
            else if (pTrait1 != null && a.hasTrait(pTrait1))
            {
                a.removeTrait(pTrait1);
            }
            return true;
        }
        public static void GiveWeaponWithMagicEffects(BaseSimObject pSelf, string pEffect, string pTrait0, string pStatusTrait, string pTrait1 = null, string pTrait2 = null, string pSong = null)
        {
            if (pTrait1 != null)
            {
                pSelf.a.addTrait(pTrait1);
            }
            if (pTrait2 != null)
            {
                pSelf.a.addTrait(pTrait2);
            }
            if (pSelf.a.hasTrait(pStatusTrait))
            {
                pSelf.addStatusEffect(pStatusTrait);
                pSelf.a.removeTrait(pStatusTrait);
            }
            pSelf.a.addTrait(pTrait0);
            AttachEffect(pSelf, pEffect);
            MusicBox.playSound(pSong, pSelf.a.currentTile, false, false);
        }
        public static void SoilMaker(Actor pActor, WorldTile pTile)
        {
            PowerLibrary pl = new PowerLibrary();
            if (pActor != null && pTile != null)
            {
                BrushData LevelBrush = ApropriateBrush(pActor);
                for (int i = 0; i < LevelBrush.pos.Length; i++)
                {
                    int num = pTile.x + LevelBrush.pos[i].x;
                    int num2 = pTile.y + LevelBrush.pos[i].y;
                    if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height)
                    {
                        WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                        if (!pActor.has_attack_target && Toolbox.randomBool())
                        {
                            if (pActor.hasTrait("madness") || World.world_era.id == "age_despair")
                            {
                                if (pActor.asset.needFood == true)
                                {
                                    if (pActor.hasTrait("madness"))
                                    {
                                        MapAction.decreaseTile(tileSimple, "flash");
                                    }
                                    else if (pActor.data.hunger <= 25)
                                    {
                                        if (pTile.main_type.id == ST.deep_ocean)
                                        {
                                            MapAction.terraformTile(tileSimple, pTile.main_type, pTile.top_type, TerraformLibrary.draw);
                                        }
                                        MapAction.decreaseTile(tileSimple, "flash");
                                    }
                                }
                                else if (!pActor.hasTrait("madness"))
                                {
                                    if (pTile.main_type.id == ST.deep_ocean)
                                    {
                                        MapAction.terraformTile(tileSimple, pTile.main_type, pTile.top_type, TerraformLibrary.draw);
                                    }
                                    MapAction.decreaseTile(tileSimple, "flash");
                                }
                            }
                            else
                            {
                                if (tileSimple.building != null && !tileSimple.building.isUsable())
                                {
                                    tileSimple.building.startDestroyBuilding();
                                }
                                if (tileSimple.Type.lava)
                                {
                                    World.world.dropManager.spawn(tileSimple, SD.rain, 15f, -1f);
                                }
                                if (tileSimple.Type.canBeFilledWithOcean)
                                {
                                    MapAction.increaseTile(tileSimple, "flash");
                                }
                                if (tileSimple.Type.ocean)
                                {
                                    if (pActor.asset.needFood == true)
                                    {
                                        if (pActor.data.hunger <= 25)
                                        {
                                            MapAction.increaseTile(tileSimple, "flash");
                                        }
                                        else if (tileSimple.main_type.id != ST.shallow_waters)
                                        {
                                            MapAction.increaseTile(tileSimple, "flash");
                                        }
                                    }
                                    else
                                    {
                                        MapAction.increaseTile(tileSimple, "flash");
                                    }
                                }
                                if (pActor.hasTrait("greedy") || World.world_era.id == "age_ash")
                                {
                                    if (tileSimple.Type.grass || tileSimple.Type.soil)
                                    {
                                        MapAction.decreaseTile(tileSimple, "flash");
                                    }
                                }
                                else if (World.world_era.id != "age_chaos")
                                {
                                    if (tileSimple.Type.sand)
                                    {
                                        if (pActor.asset.needFood == true)
                                        {
                                            if (pActor.data.hunger <= 25)
                                            {
                                                MapAction.increaseTile(tileSimple, "flash");
                                            }
                                        }
                                        else
                                        {
                                            MapAction.increaseTile(tileSimple, "flash");
                                        }
                                    }
                                    if (tileSimple.Type.grass)
                                    {
                                        if (World.world_era.id == "age_wonders")
                                        {
                                            Action[] Drops = {
                                            () => WorldBehaviourActionBiomes.trySpreadBiomeAround(tileSimple, tileSimple, false, false),
                                            () => ActionLibrary.flowerPrintsEffect(pActor),
                                            () => BuildingActions.tryGrowMineralRandom(pTile),
                                            () => BuildingActions.tryGrowVegetationRandom(pTile, VegetationType.Trees, false, false),
                                            () => World.world.buildings.addBuilding(SB.fruit_bush, pTile, true, false, BuildPlacingType.New)
                                            };
                                            int random = Toolbox.randomInt(0, Drops.Length);
                                            Drops[random]();
                                            Console.ReadLine();
                                            if (tileSimple.Type.farm_field)
                                            {
                                                World.world.dropManager.spawn(tileSimple, SD.fertilizerPlants, 15f, -1f);
                                            }
                                        }
                                        else if (tileSimple.Type.biome_asset != null && tileSimple.Type.biome_asset.grow_type_selector_plants != null)
                                        {
                                            if (pActor.asset.needFood == true)
                                            {
                                                if (pActor.data.hunger <= 25)
                                                {
                                                    BuildingActions.tryGrowVegetationRandom(pTile, VegetationType.Trees, false, false);
                                                }
                                            }
                                            else
                                            {
                                                BuildingActions.tryGrowVegetationRandom(pTile, VegetationType.Trees, false, false);
                                            }
                                        }
                                    }
                                    if (tileSimple.burned_stages > 0)
                                    {
                                        World.world.dropManager.spawn(tileSimple, SD.rain, 15f, -1f);
                                    }
                                    if (tileSimple.Type.soil)
                                    {
                                        if (pActor.hasTrait("mageslayer"))
                                        {
                                            if (pActor.hasTrait("lucky"))
                                            {
                                                if (World.world_era.id == "age_moon")
                                                {
                                                    DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.crystal_low, TopTileLibrary.crystal_high);
                                                }
                                                if (World.world_era.id == "age_wonders")
                                                {
                                                    DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.candy_low, TopTileLibrary.candy_high);
                                                }
                                                if (World.world_era.id == "age_dark")
                                                {
                                                    DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.mushroom_low, TopTileLibrary.mushroom_high);
                                                }
                                                if (World.world_era.id == "age_sun")
                                                {
                                                    DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.lemon_low, TopTileLibrary.lemon_high);
                                                }
                                            }
                                        }
                                        else if (pActor.hasTrait("cursed"))
                                        {
                                            DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.corruption_low, TopTileLibrary.corruption_high);
                                        }
                                        else if (pActor.hasTrait("blessed"))
                                        {
                                            DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.enchanted_low, TopTileLibrary.enchanted_high);
                                        }
                                        else if (pActor.hasTrait("fire_blood"))
                                        {
                                            DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.infernal_low, TopTileLibrary.infernal_high);
                                        }
                                        else if (pActor.hasTrait("cold_aura"))
                                        {
                                            DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.permafrost_low, TopTileLibrary.permafrost_high);
                                        }
                                        else if (pActor.hasTrait("venomous"))
                                        {
                                            DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.swamp_low, TopTileLibrary.swamp_high);
                                        }
                                        else
                                        {
                                            if (World.world_era.id == "age_sun")
                                            {
                                                Action[] Drops = {
                                                () => DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.savanna_low, TopTileLibrary.savanna_high),
                                                () => DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.desert_low, TopTileLibrary.desert_high)
                                                };
                                                int random = Toolbox.randomInt(0, Drops.Length);
                                                Drops[random]();
                                                Console.ReadLine();
                                            }
                                            else if (World.world_era.id == "age_dark")
                                            {
                                                DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.desert_low, TopTileLibrary.desert_high);
                                            }
                                            else if (World.world_era.id == "age_hope")
                                            {
                                                DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.grass_low, TopTileLibrary.grass_high);
                                            }
                                            else if (World.world_era.id == "age_tears")
                                            {
                                                Action[] Drops = {
                                                () => DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.jungle_low, TopTileLibrary.jungle_high),
                                                () => DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.swamp_low, TopTileLibrary.swamp_high)
                                                };
                                                int random = Toolbox.randomInt(0, Drops.Length);
                                                Drops[random]();
                                                Console.ReadLine();
                                            }
                                            else if (World.world_era.id == "age_moon")
                                            {
                                                DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.jungle_low, TopTileLibrary.jungle_high);
                                            }
                                            else if (World.world_era.id == "age_ice" || tileSimple.isFrozen())
                                            {
                                                DropsLibrary.useDropSeedOn(pTile, TopTileLibrary.permafrost_low, TopTileLibrary.permafrost_high);
                                            }
                                            else if (World.world_era.id == "age_chaos" && Toolbox.randomChance(0.00025f))
                                            {
                                                World.world.earthquakeManager.startQuake(tileSimple, EarthquakeType.RandomPower);
                                                WorldLog.logDisaster(AssetManager.disasters.get("small_earthquake"), pTile);
                                            }
                                        }
                                    }
                                    else if (tileSimple.Type.rocks)
                                    {
                                        if (tileSimple.Type.mountains)
                                        {
                                            if (pActor.asset.needFood == false && World.world_era.id == "age_hope")
                                            {
                                                MapAction.decreaseTile(tileSimple, "flash");
                                            }
                                        }
                                        else
                                        {
                                            MapAction.decreaseTile(tileSimple, "flash");
                                        }
                                    }
                                }
                                else if (pTile.Type.rocks || tileSimple.Type.rocks)
                                {
                                    if (pTile.Type.rocks)
                                    {
                                        MapAction.terraformTile(tileSimple, pTile.main_type, pTile.top_type, TerraformLibrary.draw);
                                    }
                                    if (tileSimple.Type.mountains)
                                    {
                                        for (int t = 0; t < pTile.neighbours.Length; t++)
                                        {
                                            WorldTile worldTile = pTile.neighbours[t];
                                            MapAction.terraformTile(pTile, tileSimple.main_type, tileSimple.top_type, TerraformLibrary.draw);
                                            for (int y = 0; y < worldTile.neighbours.Length; y++)
                                            {
                                                MapAction.terraformTile(worldTile.neighbours[y], tileSimple.main_type, tileSimple.top_type, TerraformLibrary.draw);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static bool BlessedAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pSelf.a.asset.unit == false || pTarget.a == null || pSelf.a.hasWeapon())
            {
                return false;
            }
            float num = Toolbox.randomFloat(1f, pTarget.a.stats[S.damage]);
            int regeneration = (int)(pTarget.a.stats[S.damage] / num);
            pSelf.a.restoreHealth(regeneration);
            Projectile(pSelf, pTarget, pTile, "DivineProjectile");
            return true;
        }
        public static bool BlessedConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (isNoble(a))
            {
                a.addTrait("light_lamp");
                if (pTarget.a.data.profession == UnitProfession.King)
                {
                    a.addTrait("shiny");
                }
                else
                {
                    a.removeTrait("shiny");
                }
            }
            else if (!a.hasTrait("scar_of_divinity"))
            {
                a.removeTrait("shiny");
                a.removeTrait("light_lamp");
            }
            if (a.asset.unit == false || a.hasWeapon())
            {
                if (a.hasWeapon())
                {
                    a.stats[S.range] = 1f;
                }
                return false;
            }
            EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTile, pTarget.kingdom, -1);
            if (enemiesTarget != null && enemiesTarget.list != null)
            {
                int enemiesCount = enemiesTarget.list.Count;
                int randomEnemy = Toolbox.randomInt(0, enemiesCount);
                BaseSimObject enemy = enemiesTarget.list[randomEnemy];
                if (enemy != null && enemy.isActor() && enemy.a.asset.canBeKilledByDivineLight == true)
                {
                    enemy.a.removeTrait("fire_blood");
                    enemy.a.removeTrait("burning_feet");
                    enemy.a.addStatusEffect("blessed_fire");
                    a.addExperience(33);
                    BrushData LevelBrush = ApropriateBrush(a);
                    for (int i = 0; i < LevelBrush.pos.Length; i++)
                    {
                        int num = enemy.a.currentTile.x + LevelBrush.pos[i].x;
                        int num2 = enemy.a.currentTile.y + LevelBrush.pos[i].y;
                        if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height)
                        {
                            WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                            DivineLightFX(tileSimple);
                        }
                    }
                }
            }
            World.world.getObjectsInChunks(pTile, 100, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.asset.unit == false && actor.hasTrait("blessed") && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    actor.addStatusEffect("civilized");
                    actor.removeTrait("peaceful");
                    actor.setKingdom(a.kingdom);
                }
            }
            if (pTile.Type.biome_id == ST.biome_enchanted || a.has_attack_target)
            {
                a.addStatusEffect("enchanted");
            }
            else if (!a.hasStatus("enchanted"))
            {
                a.colorEffect = 0f;
            }
            return true;
        }
        public static bool BlessedDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            BaseSimObject attackedBy = a.attackedBy;
            traitDeathEffect(pTarget, SD.cure);
            if (World.world_era.id == "age_wonders")
            {
                traitDeathEffect(pTarget, SD.blessing);
            }
            if (a.hasTrait("shiny") && attackedBy != null && attackedBy.isActor() && attackedBy.a.asset.id != "angel")
            {
                if (attackedBy.a.data.level < a.data.level || attackedBy.a.data.level == 1)
                {
                    if (a.asset.id != "angel")
                    {
                        DivineLightFX(pTile);
                        EffectsLibrary.spawnAtTile("fx_teleport_yellow", pTile, a.a.stats[S.scale]);
                    }
                    char[] letras = { 'A', 'R', 'T', 'U', 'R' };
                    string Apostrophe = ApostropheDivino(letras);
                    WorldTip.showNow(Apostrophe + "!", false, "top", 3f);
                    World.world.units.spawnNewUnit("angel", a.currentTile, true, 0f);
                    EffectsLibrary.spawnAtTile("fx_spawn", pTile, a.a.stats[S.scale]);
                }
            }
            return false;
        }
        public static bool CursedReact(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            World.world.getObjectsInChunks(pTile, 35, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (actor.asset.unit == false && isCorrupted(actor))
                {
                    if (a.kingdom.data.banner_icon_id > -1 && actor.kingdom != a.kingdom)
                    {
                        if (a.city != null)
                        {
                            actor.setKingdom(a.kingdom);
                        }
                    }
                }
            }
            return true;
        }
        public static bool CursedConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            World.world.getObjectsInChunks(pTile, 35, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.asset.unit == false && isCorrupted(actor) && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    actor.addStatusEffect("civilized");
                    actor.setKingdom(a.kingdom);
                }
            }
            World.world.getObjectsInChunks(pTile, 500, MapObjectType.Building);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Building building = (Building)World.world.temp_map_objects[i];
                {
                    if (building.asset.id == SB.tumor || building.asset.id == SB.super_pumpkin || building.asset.id == SB.biomass || building.asset.id == SB.cybercore)
                    {
                        if (a.kingdom.data.banner_icon_id > -1 && building.kingdom != a.kingdom)
                        {
                            building.setKingdom(a.kingdom, true);
                        }
                    }
                }
            }
            return true;
        }
        public static bool CursedDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (World.world_era.id == "age_ash" || World.world_era.id == "age_chaos")
            {
                traitDeathEffect(pTarget, SD.curse);
            }
            return true;
        }
        public static bool LightningReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            if (pTile.burned_stages > 0 || pTile.isOnFire())
            {
                pSelf.a.restoreHealth(15);
            }
            return true;
        }
        public static bool LightningAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (a.asset.unit == false || !a.hasTrait("regeneration") || pTarget == null)
            {
                return false;
            }
            else if (!a.hasTrait("immortal") && pTarget.isActor())
            {
                int regeneration = pTarget.a.getMaxHealth() - pTarget.a.data.health;
                pTarget.a.spawnParticle(Toolbox.color_heal);
                pTarget.a.startColorEffect(ActorColorEffect.White);
                a.restoreHealth(regeneration);
            }
            return true;
        }
        public static bool LightningConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (a.asset.nameLocale == "Fairy")
            {
                return false;
            }
            else if (a.asset.unit == false)
            {
                a.getHit(a.getMaxHealth());
                return false;
            }
            else if (a.hasTrait("immortal") && !a.hasTrait("fire_proof"))
            {
                a.removeTrait("immortal");
                a.removeTrait("fire_proof");
                a.removeTrait("energized");
            }
            else if (!a.hasTrait("regeneration"))
            {
                return false;
            }
            else
            {
                GiveWeaponWithConditions(pTarget, "energized_weapon", "base", "fire_proof", "immortal");
                int health = a.data.health;
                if (health > 0)
                {
                    Vector2Int position = pTile.pos;
                    double level = Math.Pow(a.data.kills, a.data.level);
                    int count = World.world.temp_map_objects.Count;
                    int num = count * (int)level / health + a.data.level * (int)a.asset.base_stats[S.speed];
                    a.stats[S.speed] = num;
                    a.stats[S.dodge] = num;
                    float attack_speed = a.stats[S.speed] * 1.5f;
                    a.stats[S.attack_speed] = attack_speed;
                    a.stats[S.range] = a.data.level;
                    EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTile, pTarget.kingdom, -1);
                    if (enemiesTarget != null && enemiesTarget.list != null)
                    {
                        foreach (BaseSimObject enemy in enemiesTarget.list)
                        {
                            if (enemy != null && enemy.isActor())
                            {
                                if (a.hasTrait("madness") || enemy.a.data.health >= a.data.health * 1.5 && Toolbox.randomBool())
                                {
                                    MapBox.spawnLightningSmall(enemy.a.currentTile, 0.0625f);
                                    enemy.a.stats[S.speed] += -1;
                                    enemy.a.spawnParticle(Toolbox.color_heal);
                                    a.startColorEffect(ActorColorEffect.White);
                                }
                            }
                        }
                    }
                    World.world.getObjectsInChunks(pTile, 35, MapObjectType.Actor);
                    for (int i = 0; i < World.world.temp_map_objects.Count - 1; i++)
                    {
                        Actor actor = (Actor)World.world.temp_map_objects[i];
                        if (a.kingdom.data.banner_icon_id > -1 && actor.asset.unit == false && actor.hasTrait("energized") && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                        {
                            actor.addStatusEffect("civilized");
                            actor.removeTrait("peaceful");
                            actor.setKingdom(a.kingdom);
                        }
                    }
                }
            }
            return true;
        }
        public static bool LightningDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget.a.asset.unit == false)
            {
                MapBox.spawnLightningSmall(pTile, pTarget.a.stats[S.scale] / 2);
            }
            else if (pTarget.a.hasTrait("immortal") && pTarget.a.hasTrait("regeneration"))
            {
                MapBox.spawnLightningSmall(pTile, pTarget.a.data.level / 25);
            }
            return true;
        }
        public static bool ForceReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (a.asset.unit == false)
            {
                return false;
            }
            string[] kingdom = { a.kingdom.data.id };
            int pDamage = (int)a.stats[S.damage];
            int health = a.data.health;
            World.world.getObjectsInChunks(pTile, 10, MapObjectType.Actor);
            int count = World.world.temp_map_objects.Count - 1;
            if (health > 0 && a.kingdom.data.banner_icon_id > -1)
            {
                int num = count * a.data.level / health;
                if (pAttackedBy != null && pAttackedBy.isActor() && pAttackedBy.isAlive() && num > 0)
                {
                    MusicBox.playSound("event:/SFX/EXPLOSIONS/ExplosionForce", pTile, false, false);
                    EffectsLibrary.spawnExplosionWave(a.currentPosition, a.data.level, num / 1.5f);
                    World.world.applyForce(pTile, a.data.level, num, true, true, num, kingdom, pSelf, null);
                }
            }
            return true;
        }
        public static bool ForceConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (a.asset.unit == false)
            {
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            GiveWeaponWithConditions(pTarget, "mega_heartbeat_weapon", "steel", null, "strong_minded");
            if (a.hasTrait("madness"))
            {
                ActionLibrary.megaHeartbeat(pTarget, pTile);
                MusicBox.playSound("event:/SFX/EXPLOSIONS/ExplosionForce", pTile, false, false);
            }
            else
            {
                string[] kingdom = { a.kingdom.data.id };
                double pDamage = Math.Pow(a.data.level, 2);
                int health = a.data.health;
                if (health > 0 && a.kingdom.data.banner_icon_id > -1)
                {
                    EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTarget.currentTile, pTarget.kingdom, -1);
                    if (enemiesTarget != null && enemiesTarget.list != null)
                    {
                        int randomEnemy = Toolbox.randomInt(0, enemiesTarget.list.Count);
                        BaseSimObject enemy = enemiesTarget.list[randomEnemy];
                        int count = World.world.temp_map_objects.Count - 1;
                        int num = count * a.data.level / health;
                        int area = num / 2;
                        a.stats[S.knockback] = num;
                        if (enemy != null && enemy.isActor() && enemy.a.data.health >= a.data.health * 3)
                        {
                            enemy.a.addTrait("crippled");
                            enemy.a.getHit((int)pDamage);
                            MusicBox.playSound("event:/SFX/EXPLOSIONS/ExplosionForce", enemy.a.currentTile, false, false);
                            EffectsLibrary.spawnExplosionWave(enemy.a.currentPosition, area, num / 1.5f);
                            World.world.applyForce(enemy.a.currentTile, area, num, true, true, num, kingdom, enemy, null);
                        }
                    }
                }
            }
            return true;
        }
        public static bool ForceDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            int num = a.data.level * a.data.kills;
            string[] kingdom = { a.kingdom.data.id };
            MusicBox.playSound("event:/SFX/EXPLOSIONS/ExplosionForce", pTile, false, false);
            for (int i = 0; i < num; i++)
            {
                if (a.kingdom.data.banner_icon_id > -1)
                {
                    World.world.applyForce(pTile, num, num, true, true, num, kingdom, a, null);
                    EffectsLibrary.spawnExplosionWave(a.currentPosition, num, num / 1.5f);
                }
            }
            return true;
        }
        public static bool TornadoConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (a.asset.unit == false)
            {
                a.getHit(pTarget.a.getMaxHealth());
            }
            GiveWeaponWithConditions(pTarget, "whirlwind_weapon", "silver", null, "weightless");
            string[] kingdom = { a.kingdom.data.id };
            World.world.getObjectsInChunks(pTile, 10, MapObjectType.Actor);
            if (a.data.health > 0)
            {
                int num = (int)(World.world.temp_map_objects.Count * 2) / (a.data.health);
                for (int i = 0; i < World.world.temp_map_objects.Count; i++)
                {
                    Actor actor = (Actor)World.world.temp_map_objects[i];
                    int pDamage = (int)a.stats[S.damage_range];
                    if (actor != a && actor.kingdom.isEnemy(a.kingdom) && actor.has_attack_target && actor.data.health > a.data.health * 1.5 && !a.hasStatus("whirlwind"))
                    {
                        a.addStatusEffect("whirlwind");
                    }
                    if (!a.hasStatus("whirlwind"))
                    {
                        a.colorEffect = 0;
                    }
                }
                if (a.hasTrait("madness") && !a.hasStatus("whirlwind"))
                {
                    a.addStatusEffect("whirlwind");
                }
            }
            return true;
        }
        public static bool TornadoDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            int level = a.data.level * a.data.kills + a.data.getAge() + a.data.children;
            float num = a.getMaxHealth() / level;
            if (num < 0.26f)
            {
                num = 0.25f;
            }
            Tornado component = World.world.units.createNewUnit(SA.tornado, pTile, 0f).GetComponent<Tornado>();
            component.forceScaleTo(Tornado.TORNADO_SCALE_DEFAULT / num / 2);
            component.resizeTornado(Tornado.TORNADO_SCALE_DEFAULT / num);
            return true;
        }
        public static bool FireUltimato(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (pTarget.a.asset.unit == false)
            {
                return false;
            }
            if (a.hasTrait("madness"))
            {
                a.addTrait("burning_feet");
            }
            PowerLibrary pl = new PowerLibrary();
            for (int i = 0; i < Brush.get(4, "circ_").pos.Length; i++)
            {
                int num = pTile.x + Brush.get(4, "circ_").pos[i].x;
                int num2 = pTile.y + Brush.get(4, "circ_").pos[i].y;
                if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height)
                {
                    WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                    drawTemperaturePlusPlus(tileSimple, "temperaturePlus");
                }
            }
            GiveWeaponWithConditions(pTarget, "fire_blood_weapon", "copper", "fire_proof");
            EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTile, pTarget.kingdom, -1);
            if (enemiesTarget != null && enemiesTarget.list != null)
            {
                int randomEnemy = Toolbox.randomInt(0, enemiesTarget.list.Count);
                BaseSimObject enemy = enemiesTarget.list[randomEnemy];
                if (enemy != null && enemy.isActor())
                {
                    enemy.a.addStatusEffect("burning", 5f);
                    enemy.a.spawnParticle(Toolbox.color_yellow);
                }
            }
            World.world.getObjectsInChunks(pTile, 15, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.asset.unit == false && actor.hasTrait("fire_blood") && actor.asset.id != SA.dragon && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    actor.removeTrait("burning_feet");
                    actor.addStatusEffect("civilized");
                    actor.setKingdom(a.kingdom);
                }
            }
            World.world.getObjectsInChunks(pTile, 500, MapObjectType.Building);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Building building = (Building)World.world.temp_map_objects[i];
                {
                    if (building.asset.id == SB.flame_tower && building.kingdom != a.kingdom)
                    {
                        building.setKingdom(a.kingdom, true);
                    }
                }
            }
            return true;
        }
        public static bool FireDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            int num = pTarget.a.data.level;
            PowerLibrary pl = new PowerLibrary();
            for (int i = 0; i < num; i++)
            {
                if (num > 11)
                {
                    pl.spawnCloud(pTile, "cloud_lava");
                }
            }
            return true;
        }
        public static bool IceConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (pTarget.a.asset.unit == false)
            {
                ActionLibrary.coldAuraEffect(pTarget);
                return false;
            }
            if (a.hasTrait("madness"))
            {
                ActionLibrary.coldAuraEffect(pTarget);
            }
            EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTile, pTarget.kingdom, -1);
            if (enemiesTarget != null && enemiesTarget.list != null)
            {
                int randomEnemy = Toolbox.randomInt(0, enemiesTarget.list.Count);
                BaseSimObject enemy = enemiesTarget.list[randomEnemy];
                if (enemy != null && enemy.isActor() && enemy.a.data.health > a.data.health * 1.5)
                {
                    enemy.a.addStatusEffect("frozen", 2.5f);
                }
            }
            GiveWeaponWithConditions(pTarget, "cold_aura_weapon", "mythril", "freeze_proof");
            World.world.getObjectsInChunks(pTile, 15, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.asset.unit == false && actor.hasTrait("cold_aura") && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    actor.addStatusEffect("civilized");
                    actor.setKingdom(a.kingdom);
                }
            }
            World.world.getObjectsInChunks(pTile, 500, MapObjectType.Building);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Building building = (Building)World.world.temp_map_objects[i];
                {
                    if (a.kingdom.data.banner_icon_id > -1 && building.asset.id == SB.ice_tower && building.kingdom != a.kingdom)
                    {
                        building.setKingdom(a.kingdom, true);
                    }
                }
            }
            return true;
        }
        public static bool IceDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            traitDeathEffect(pTarget, SD.snow);
            if (pTarget.a.asset.unit == false)
            {
                return false;
            }
            int num = pTarget.a.data.level;
            PowerLibrary pl = new PowerLibrary();
            for (int i = 0; i < num; i++)
            {
                if (num > 2)
                {
                    pl.spawnCloud(pTile, "cloud_snow");
                }
            }
            return true;
        }
        public static bool AcidConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (pTarget.a.asset.unit == false)
            {
                return false;
            }
            if (a.hasTrait("madness"))
            {
                a.addTrait("acid_touch");
            }
            EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTile, pTarget.kingdom, -1);
            if (enemiesTarget != null && enemiesTarget.list != null)
            {
                int randomEnemy = Toolbox.randomInt(0, enemiesTarget.list.Count);
                BaseSimObject enemy = enemiesTarget.list[randomEnemy];
                if (enemy != null && enemy.isActor() && enemy.a.data.health > a.data.health * 1.5)
                {
                    MapAction.checkAcidTerraform(enemy.a.currentTile);
                    World.world.particlesSmoke.spawn(enemy.a.currentTile.posV3);
                    DropsLibrary.action_acid(enemy.a.currentTile, null);
                }
            }
            GiveWeaponWithConditions(pTarget, "acid_blood_weapon", "bronze", "acid_proof");
            World.world.getObjectsInChunks(pTile, 15, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.asset.unit == false && actor.hasTrait("acid_blood") && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    actor.addStatusEffect("civilized");
                    actor.setKingdom(a.kingdom);
                }
            }
            return true;
        }
        public static bool AcidDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            int num = pTarget.a.data.level;
            PowerLibrary pl = new PowerLibrary();
            World.world.getObjectsInChunks(pTile, 15, MapObjectType.Actor);
            for (int i = 0; i < num; i++)
            {
                if (num > 3)
                {
                    pl.spawnCloud(pTile, "cloud_acid");
                }
            }
            return true;
        }
        public static bool PoisonReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (a.asset.unit == false)
            {
                return false;
            }
            else if (pAttackedBy != null && pAttackedBy.isActor() && pAttackedBy.isAlive() && pAttackedBy.a.asset.flag_tornado == false)
            {
                traitDeathEffect(pSelf.a, "poison");
            }
            World.world.getObjectsInChunks(pTile, 5, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (actor.hasStatus("poisoned"))
                {
                    float pDamage = actor.data.health * 0.25f;
                    actor.getHit(pDamage, true, AttackType.Poison, null, true, false);
                }
            }
            return true;
        }
        public static bool PoisonConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (a.asset.unit == false)
            {
                return false;
            }
            EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTile, pTarget.kingdom, -1);
            if (enemiesTarget != null && enemiesTarget.list != null)
            {
                int randomEnemy = Toolbox.randomInt(0, enemiesTarget.list.Count);
                BaseSimObject enemy = enemiesTarget.list[randomEnemy];
                if (enemy != null && enemy.isActor() && enemy.a.hasStatus("poisoned"))
                {
                    float pDamage = enemy.a.data.health * 0.5f;
                    if (enemy != null && enemy.isActor() && Toolbox.randomBool() && enemy.a.data.health > 1)
                    {
                        enemy.a.getHit(pDamage, true, AttackType.Poison, null, true, false);
                    }
                }
            }
            GiveWeaponWithConditions(pTarget, "venomous_weapon", "iron", "poison_immune", "poisonous");
            World.world.getObjectsInChunks(pTile, 50, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.asset.unit == false && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    if (actor.hasTrait("venomous") || actor.hasTrait("poisonous"))
                    {
                        actor.addStatusEffect("civilized");
                        actor.setKingdom(a.kingdom);
                    }
                }
            }
            return true;
        }
        public static bool PoisonDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            traitDeathEffect(pTarget, "poison");
            if (pTarget.a.asset.unit == false)
            {
                return false;
            }
            else if (pTarget.a.hasTrait("poisonous"))
            {
                Action[] comandos = {
                () => World.world.units.spawnNewUnit(SA.snake, pTarget.currentTile, false, 0f),
                () => World.world.units.spawnNewUnit(SA.frog, pTarget.currentTile, false, 0f),
                };
                System.Random random = new System.Random();
                int indiceAleatorio = random.Next(0, comandos.Length);
                comandos[indiceAleatorio]();
                Console.ReadLine();
            }
            return true;
        }
        public static bool NatureReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (a.hasStatus("burning"))
            {
                traitDeathEffect(pSelf, SD.rain);
            }
            BrushData LevelBrush = ApropriateBrush(a);
            for (int i = 0; i < LevelBrush.pos.Length; i++)
            {
                int num = pTile.x + LevelBrush.pos[i].x;
                int num2 = pTile.y + LevelBrush.pos[i].y;
                if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height)
                {
                    WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                    if (a.asset.id != SA.druid && !a.has_attack_target)
                    {
                        if (tileSimple.Type.mountains)
                        {
                            MapAction.decreaseTile(tileSimple, "flash");
                        }
                    }
                }
            }
            return true;
        }
        public static bool NatureConditions(BaseSimObject pTarget, WorldTile pTile)
        {
            Actor a = pTarget.a;
            SoilMaker(a, pTile);
            if (a.asset.unit == false)
            {
                return false;
            }
            EnemyFinderData enemiesTarget = EnemiesFinder.findEnemiesFrom(pTile, pTarget.kingdom, -1);
            if (enemiesTarget != null && enemiesTarget.list != null)
            {
                int randomEnemy = Toolbox.randomInt(0, enemiesTarget.list.Count);
                BaseSimObject enemy = enemiesTarget.list[randomEnemy];
                if (enemy != null && enemy.isActor())
                {
                    enemy.a.addStatusEffect("slowness", 5f);
                }
            }
            GiveWeaponWithConditions(pTarget, "flower_prints_weapon", "wood", null, "thorns");
            World.world.getObjectsInChunks(pTile, 35, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    if (actor.asset.animal == true || actor.asset.oceanCreature == true || actor.asset.unit == false && actor.hasTrait("flower_prints"))
                    {
                        actor.addStatusEffect("civilized");
                        actor.removeTrait("peaceful");
                        actor.setKingdom(a.kingdom);
                    }
                }
            }
            World.world.getObjectsInChunks(pTile, 50, MapObjectType.Building);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Building building = (Building)World.world.temp_map_objects[i];
                {
                    if (building.asset.id == SB.volcano && !building.data.hasFlag(S.stop_spawn_drops))
                    {
                        PowerLibrary pl = new PowerLibrary();
                        pl.spawnCloud(pTile, "cloud_rain");
                        building.data.addFlag(S.stop_spawn_drops);
                    }
                }
            }
            return true;
        }
        public static bool NatureDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (a.data.level < 4)
            {
                traitDeathEffect(pTarget, SD.fertilizerPlants);
                return false;
            }
            else if (a.data.level < 7)
            {
                traitDeathEffect(pTarget, SD.fertilizerTrees);
            }
            else
            {
                traitDeathEffect(pTarget, SD.stone);
                World.world.getObjectsInChunks(pTile, 15, MapObjectType.Actor);
                for (int i = 0; i < World.world.temp_map_objects.Count; i++)
                {
                    Actor actor = (Actor)World.world.temp_map_objects[i];
                    World.world.earthquakeManager.startQuake(pTile, EarthquakeType.RandomPower);
                    actor.addTrait("crippled");
                    actor.getHit(World.world.temp_map_objects.Count);
                }
            }
            return true;
        }
        public static bool DragonbornReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (a.asset.unit == false || a.kingdom == null || a.hasWeapon() || pAttackedBy == null || !pAttackedBy.isActor() || !pAttackedBy.isAlive() || !a.hasTrait("strong_minded"))
            {
                return false;
            }
            else if (Toolbox.randomChance(0.25f) && !a.hasStatus("dragonshield"))
            {
                string[] kingdom = { a.kingdom.data.id };
                a.addStatusEffect("dragonshield");
                World.world.applyForce(pTile, 1, 0.25f, true, true, a.data.kills, kingdom, pSelf, null);
            }
            if (pAttackedBy.a.asset.id == SA.dragon && pAttackedBy.a.kingdom == a.kingdom)
            {
                pAttackedBy.a.GetComponent<Dragon>().aggroTargets.Clear();
            }
            return true;
        }
        public static bool DragonbornConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            int duration = a.getMaxHealth() / 2 - a.data.health;
            if (a.asset.unit == false || !a.hasTrait("strong_minded"))
            {
                return false;
            }
            a.removeTrait("peaceful");
            a.addTrait("fire_proof");
            if (a.hasTrait("veteran") || a.hasTrait("scar_of_divinity"))
            {
                int regeneration2 = (int)a.getMaxHealth() / 50;
                GiveWeaponWithConditions(pTarget, "dragonslayer_weapon", "adamantine", "giant", "immortal", "fx_dragon_actor");
                clearBadTraitsFrom(a);
                if (a.data.health <= a.getMaxHealth() / 3)
                {
                    pTarget.a.finishStatusEffect("dragonshield");
                    if (pTarget.a.moveJumpOffset.y == 0f)
                    {
                        a.forceVector.z = 2f;
                        a.addStatusEffect("dragonslayer", duration);
                        MusicBox.playSound("event:/SFX/UNITS/UNIQUE/Dragon/DragonDeath", pTile, false, false);
                        EffectsLibrary.spawnAt("fx_boulder_impact", a.currentPosition, a.stats[S.scale]);
                    }
                    if (a.hasStatus("dragonslayer"))
                    {
                        a.moveJumpOffset.y = 1f;
                        a.flying = true;
                    }
                }
                else if (a.moveJumpOffset.y != 0f)
                {
                    AttachEffect(a, "fx_dragon_actor_death");
                    MusicBox.playSound("event:/SFX/UNITS/UNIQUE/Dragon/DragonDeath", pTile, false, false);
                    a.restoreHealth(regeneration2);
                    a.finishStatusEffect("dragonslayer");
                    a.batch.c_action_landed.Add((Actor)a);
                    a.flying = false;
                    a.moveJumpOffset.y = 0f;
                }
            }
            else if (a.hasTrait("immortal"))
            {
                a.removeTrait("immortal");
            }
            if (a.hasTrait("golden_tooth"))
            {
                a.addTrait("super_health");
            }
            else if (!a.hasTrait("scar_of_divinity"))
            {
                a.removeTrait("super_health");
            }
            if (a.hasStatus("dragonshield"))
            {
                if (a.data.health > a.getMaxHealth() / 1.5 || a.hasTrait("immortal"))
                {
                    a.finishStatusEffect("dragonshield");
                }
            }
            World.world.getObjectsInChunks(pTile, 1000, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.asset.id == SA.dragon && actor.kingdom != a.kingdom && !actor.hasStatus("tamed"))
                {
                    actor.setKingdom(a.kingdom);
                    actor.addStatusEffect("tamed");
                }
            }
            return true;
        }
        public static bool DragonbornDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget.a.asset.unit == false || !pTarget.a.hasTrait("strong_minded"))
            {
                return false;
            }
            traitDeathEffect(pTarget, SD.bloodRain);
            if (pTarget.a.hasTrait("super_health"))
            {
                if (World.world_era.id == "age_chaos")
                {
                    traitDeathEffect(pTarget, SD.spite);
                }
                MusicBox.playSound("event:/SFX/UNITS/UNIQUE/Dragon/DragonDeath", pTile, false, false);
                Actor actor = World.world.units.spawnNewUnit(SA.dragon, pTarget.a.currentTile, true, 0f);
                EffectsLibrary.spawnAt("fx_dragon", actor.currentPosition, actor.stats[S.scale]);
                World.world.applyForce(pTile, 5, 5, true, true, 5, null, pTarget, null);
            }
            return true;
        }
        public static bool MagicConditions(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (!a.hasTrait("lucky"))
            {
                return false;
            }
            if (MageType(a) == "whitemage")
            {
                if (!a.hasWeapon())
                {
                    if (a.asset.use_items == true)
                    {
                        GiveWeapon(a, "white_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_blue", "freeze_proof", "peaceful", "event:/SFX/UNITS/ColdOne/ColdOneDeath");
                    }
                    else if (ApropriateColor(pTarget) != "whitemage")
                    {
                        GiveWeapon(a, "white_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_blue", "freeze_proof", "peaceful", "event:/SFX/UNITS/ColdOne/ColdOneDeath");
                    }
                }
                else
                {
                    ActorEquipmentSlot actorEquipmentSlot = a.equipment.weapon;
                    ItemData data = actorEquipmentSlot.data;
                    if (data.id != "white_staff")
                    {
                        GiveWeapon(a, "white_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_blue", "freeze_proof", "peaceful", "event:/SFX/UNITS/ColdOne/ColdOneDeath");
                    }
                    else if (a.hasTrait("peaceful"))
                    {
                        GiveWeapon(a, "white_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_blue", "freeze_proof", "peaceful", "event:/SFX/UNITS/ColdOne/ColdOneDeath");
                    }

                }
            }
            else if (MageType(a) == "necromancer")
            {
                if (!a.hasWeapon())
                {
                    if (a.asset.use_items == true)
                    {
                        GiveWeapon(a, "necromancer_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_green", "regeneration", "death_mark", "evil");
                    }
                    else if (ApropriateColor(pTarget) != "necromancer")
                    {
                        GiveWeapon(a, "necromancer_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_green", "regeneration", "death_mark", "evil");
                    }
                }
                else
                {
                    ActorEquipmentSlot actorEquipmentSlot = a.equipment.weapon;
                    ItemData data = actorEquipmentSlot.data;
                    if (data.id != "necromancer_staff")
                    {
                        GiveWeapon(a, "necromancer_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_green", "regeneration", "death_mark", "evil");
                    }
                    else if (a.hasTrait("death_mark"))
                    {
                        GiveWeapon(a, "necromancer_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_green", "regeneration", "death_mark", "evil");
                    }
                }
            }
            else if (MageType(a) == "evilmage")
            {
                if (!a.hasWeapon())
                {
                    if (a.asset.use_items == true)
                    {
                        GiveWeapon(a, "evil_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_red", "evil", "voices_in_my_head", "fire_proof", "immortal", "event:/SFX/UNITS/EvilMage/EvilMageDeath");
                    }
                    else if (ApropriateColor(pTarget) != "evilmage")
                    {
                        GiveWeapon(a, "evil_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_red", "evil", "voices_in_my_head", "fire_proof", "immortal", "event:/SFX/UNITS/EvilMage/EvilMageDeath");
                    }
                }
                else
                {
                    ActorEquipmentSlot actorEquipmentSlot = a.equipment.weapon;
                    ItemData data = actorEquipmentSlot.data;
                    if (data.id != "evil_staff")
                    {
                        GiveWeapon(a, "evil_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_red", "evil", "voices_in_my_head", "fire_proof", "immortal", "event:/SFX/UNITS/EvilMage/EvilMageDeath");
                    }
                    else if (a.hasTrait("voices_in_my_head"))
                    {
                        GiveWeapon(a, "evil_staff", "base");
                        GiveWeaponWithMagicEffects(a, "fx_teleport_red", "evil", "voices_in_my_head", "fire_proof", "immortal", "event:/SFX/UNITS/EvilMage/EvilMageDeath");
                    }
                }
            }
            if (!a.hasStatus("peaceful") && !a.hasStatus("death_mark") && !a.hasStatus("voices_in_my_head"))
            {
                MageRegenerationEffects(pTarget);
                if (a.data.level < 2)
                {
                    if (!a.hasTrait("veteran") && !a.hasTrait("wise") && !isCorrupted(a))
                    {
                        a.removeTrait("freeze_proof");
                        a.removeTrait("regeneration");
                        a.removeTrait("evil");
                        a.removeTrait("fire_proof");
                        a.removeTrait("immortal");
                        if (a.equipment != null && !isNoble(a))
                        {
                            ActorEquipmentSlot slot = a.equipment.getSlot(EquipmentType.Weapon);
                            if (!slot.isEmpty())
                            {
                                slot.emptySlot();
                            }
                        }
                    }
                }
                else
                {
                    if (a.data.level < 5)
                    {
                        if (!a.hasTrait("veteran") && !isCorrupted(a))
                        {
                            a.removeTrait("regeneration");
                            a.removeTrait("evil");
                            a.removeTrait("fire_proof");
                            a.removeTrait("immortal");
                        }
                    }
                    else if (a.data.level < 9)
                    {
                        if (!a.hasTrait("veteran"))
                        {
                            a.removeTrait("freeze_proof");
                            a.removeTrait("fire_proof");
                            a.removeTrait("immortal");
                        }
                    }
                    else
                    {
                        a.removeTrait("freeze_proof");
                        a.removeTrait("regeneration");
                    }
                }
            }
            World.world.getObjectsInChunks(pTile, 100, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (a.kingdom.data.banner_icon_id > -1 && actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    if (actor.asset.nameLocale == "White Mage" || actor.asset.nameLocale == "Necromancer" || actor.asset.nameLocale == "Evil Mage" || actor.asset.race == SK.undead)
                    {
                        actor.addStatusEffect("civilized");
                        actor.setKingdom(a.kingdom);
                    }
                }
            }
            return true;
        }
        public static void MageRegenerationEffects(BaseSimObject pTarget)
        {
            Actor a = pTarget.a;
            if (a.data.health < a.getMaxHealth() && !a.is_moving && !a.has_attack_target)
            {
                ActionLibrary.castBloodRain(null, pTarget, null);
                AttachEffect(a, ApropriateEffect(pTarget, null, "top"));
                AttachEffect(a, ApropriateEffect(pTarget, null, "ground"));
            }
        }
        public static bool MageAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (pTarget == null || !a.hasTrait("lucky"))
            {
                return false;
            }
            if (MageType(a) == "whitemage")
            {
                MusicBox.playSound("event:/SFX/UNITS/ColdOne/ColdOneDeath", pTile, false, false);
                if (a.data.health <= a.getMaxHealth() / 3)
                {
                    EffectsLibrary.spawnAt("fx_teleport_blue", pSelf.currentPosition, pSelf.a.stats[S.scale]);
                }
            }
            else if (MageType(a) == "necromancer")
            {
                MusicBox.playSound("event:/SFX/UNITS/Snowman/SnowmanDeath", pTile, false, false);
                ActionLibrary.castSpawnSkeleton(pSelf, pTarget, pTile);
                AttachEffect(a, "fx_cast_top_necromancer");
                if (Toolbox.randomChance(0.025f))
                {
                    World.world.dropManager.spawn(pTile, "curse", 15f, -1f);
                }
            }
            else if (MageType(a) == "evilmage")
            {
                MusicBox.playSound("event:/SFX/UNITS/EvilMage/EvilMageDeath", pTile, false, false);
                if (Toolbox.randomChance(0.02f))
                {
                    AttachEffect(a, "fx_cast_top_evilmage");
                    ActionLibrary.castFire(null, pTarget, null);
                }
                if (Toolbox.randomChance(0.005f))
                {
                    AttachEffect(a, "fx_cast_top_evilmage");
                    ActionLibrary.castLightning(null, pTarget, null);
                }
                if (Toolbox.randomChance(0.01f))
                {
                    AttachEffect(a, "fx_cast_top_evilmage");
                    ActionLibrary.castTornado(null, pTarget, null);
                }
            }
            return true;
        }
        public static bool MageReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile)
        {
            Actor a = pSelf.a;
            if (!a.hasTrait("lucky") || pAttackedBy == null || !pAttackedBy.isActor() || !pAttackedBy.isAlive())
            {
                return false;
            }
            clearBadTraitsFrom(pSelf);
            if (MageType(a) == "whitemage")
            {
                MusicBox.playSound("event:/SFX/UNITS/ColdOne/ColdOneDeath", pTile, false, false);
                if (a.data.health < a.getMaxHealth() / 3)
                {
                    TeleportRandom(pSelf);
                }
                else if (a.data.health <= a.getMaxHealth() / 2)
                {
                    pSelf.addStatusEffect("shield", 30f);
                }
            }
            else if (MageType(a) == "necromancer")
            {
                MusicBox.playSound("event:/SFX/UNITS/Snowman/SnowmanDeath", pTile, false, false);
                ActionLibrary.castSpawnSkeleton(pSelf, pAttackedBy, pTile);

                if (a.data.health >= a.getMaxHealth() / 3 && a.data.health <= a.getMaxHealth() / 2)
                {
                    EffectsLibrary.spawnAt("fx_cast_ground_whitemage", pSelf.currentPosition, pSelf.a.stats[S.scale]);
                    ActionLibrary.castBloodRain(pSelf, null, null);
                }
            }
            else if (MageType(a) == "evilmage")
            {
                MusicBox.playSound("event:/SFX/UNITS/EvilMage/EvilMageDeath", pTile, false, false);
                if (a.data.health < a.getMaxHealth() / 3)
                {
                    TeleportRandom(pSelf);
                }
                else if (a.data.health <= a.getMaxHealth() / 2)
                {
                    if (!a.hasStatus("evilshield"))
                    {
                        a.addStatusEffect("evilshield");
                    }
                }
            }
            World.world.getObjectsInChunks(pTile, 100, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (actor.kingdom != a.kingdom && !actor.hasStatus("civilized"))
                {
                    if (a.kingdom.data.banner_icon_id > -1 && actor.asset.nameLocale == "White Mage" || actor.asset.nameLocale == "Necromancer" || actor.asset.nameLocale == "Evil Mage" || actor.asset.race == SK.undead)
                    {
                        actor.addStatusEffect("civilized");
                        actor.setKingdom(a.kingdom);
                    }
                }
            }
            return true;
        }
        public static bool MageDeath(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (!a.hasTrait("lucky"))
            {
                return false;
            }
            if (MageType(a) == "whitemage")
            {
                traitDeathEffect(a, SD.magic_rain);
                if (World.world_era.id == "age_wonders")
                {
                    traitDeathEffect(pTarget, SD.friendship);
                }
                EffectsLibrary.spawnAtTile("fx_teleport_blue", pTile, pTarget.a.stats[S.scale]);
                MusicBox.playSound("event:/SFX/UNITS/ColdOne/ColdOneDeath", pTile, false, false);
                World.world.units.spawnNewUnit(SA.whiteMage, pTarget.a.currentTile, false, 0f);
            }
            else if (MageType(a) == "necromancer")
            {
                traitDeathEffect(a, SD.ash);
                if (isNoble(a))
                {
                    traitDeathEffect(pTarget, SD.curse);
                }
                EffectsLibrary.spawnAtTile("fx_teleport_green", pTile, pTarget.a.stats[S.scale]);
                MusicBox.playSound("event:/SFX/UNITS/Snowman/SnowmanDeath", pTile, false, false);
                World.world.units.spawnNewUnit(SA.necromancer, pTarget.a.currentTile, false, 0f);
            }
            else if (MageType(a) == "evilmage")
            {
                traitDeathEffect(a, SD.rage);
                if (isNoble(a) && World.world_era.id == "age_chaos")
                {
                    traitDeathEffect(pTarget, SD.spite);
                }
                EffectsLibrary.spawnAtTile("fx_teleport_red", pTile, pTarget.a.stats[S.scale]);
                MusicBox.playSound("event:/SFX/UNITS/EvilMage/EvilMageDeath", pTile, false, false);
                World.world.units.spawnNewUnit(SA.evilMage, pTarget.a.currentTile, false, 0f);
            }
            return true;
        }
    }
}



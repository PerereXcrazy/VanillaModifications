using System;
using System.Threading;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ai;

namespace VanillaModifications
{
    class Status
    {
        public static void init()
        {
            StatusEffect civilized = new StatusEffect();
            civilized.id = "civilized";
            civilized.duration = 16f;
            civilized.random_flip = true;
            civilized.animated = true;
            civilized.animation_speed = 0.05f;
            civilized.path_icon = "ui/icons/iconCivilized";
            civilized.description = "Capturado por algum reino";
            civilized.name = "Civilizado";
            civilized.action_interval = 1f;
            civilized.action = (WorldAction)Delegate.Combine(civilized.action, new WorldAction(civilizedEffect));
            localizeStatus("Civilizado", "Civilizado", civilized.description);
            AssetManager.status.add(civilized);

            StatusEffect enchanted = AssetManager.status.get("enchanted");
            enchanted.draw_light_area = true;
            enchanted.draw_light_size = 0.05f;
            enchanted.duration = 30f;
            enchanted.animated = true;
            enchanted.animation_speed = 0.15f;
            enchanted.base_stats[S.mod_speed] = 0.5f;
            enchanted.base_stats[S.knockback_reduction] = 0.5f;
            enchanted.base_stats[S.knockback] = 0.5f;
            enchanted.base_stats[S.attack_speed] = 100f;
            enchanted.base_stats[S.dodge] = 10f;
            enchanted.remove_status.Add("frozen");
            enchanted.remove_status.Add("burning");
            enchanted.remove_status.Add("slowness");
            enchanted.remove_status.Add("poisoned");
            enchanted.opposite_status.Add("frozen");
            enchanted.opposite_status.Add("burning");
            enchanted.opposite_status.Add("slowness");
            enchanted.opposite_status.Add("poisoned");
            enchanted.action_interval = 0.5f;
            enchanted.action_get_hit = (GetHitAction)Delegate.Combine(enchanted.action_get_hit, new GetHitAction(enchantedReact));
            enchanted.action = (WorldAction)Delegate.Combine(enchanted.action, new WorldAction(enchantedEffect));

            StatusEffect blessed_fire = new StatusEffect();
            blessed_fire.id = "blessed_fire";
            blessed_fire.path_icon = "ui/icons/iconBlessedFire";
            blessed_fire.description = "Apenas utilizada como ataque";
            blessed_fire.name = "Benção Flamejante";
            blessed_fire.texture = "fx_divine_fire";
            blessed_fire.draw_light_area = true;
            blessed_fire.draw_light_size = 0.05f;
            blessed_fire.duration = 10f;
            blessed_fire.allow_timer_reset = false;
            blessed_fire.animated = true;
            blessed_fire.animation_speed_random = 0.08f;
            blessed_fire.random_frame = true;
            blessed_fire.random_flip = true;
            blessed_fire.cancel_actor_job = true;
            blessed_fire.material = "mat_world_object_lit";
            blessed_fire.base_stats[S.mod_speed] -= 0.5f;
            blessed_fire.opposite_status.Add("evilshield");
            blessed_fire.opposite_status.Add("enchanted");
            blessed_fire.opposite_status.Add("frozen");
            blessed_fire.opposite_status.Add("burning");
            blessed_fire.action_interval = 0.5f;
            blessed_fire.tier = StatusTier.Advanced;
            blessed_fire.action_get_hit = (GetHitAction)Delegate.Combine(blessed_fire.action_get_hit, new GetHitAction(blessedFireReact));
            blessed_fire.action = (WorldAction)Delegate.Combine(blessed_fire.action, new WorldAction(blessedFireEffect));
            localizeStatus("Benção Flamejante", "Benção Flamejante", blessed_fire.description);
            AssetManager.status.add(blessed_fire);

            StatusEffect whirlwind = new StatusEffect();
            whirlwind.id = "whirlwind";
            whirlwind.duration = 15f;
            whirlwind.texture = "fx_tornado_status";
            whirlwind.animated = true;
            whirlwind.sound_idle = "event:/SFX/NATURE/TornadoIdleLoop";
            whirlwind.animation_speed = 0.1f;
            whirlwind.base_stats[S.attack_speed] = 100f;
            whirlwind.base_stats[S.dodge] = 10f;
            whirlwind.path_icon = "ui/Icons/iconTornado";
            whirlwind.description = "Segure firme";
            whirlwind.name = "Redemoinho interno";
            whirlwind.action_interval = 0.5f;
            whirlwind.action = (WorldAction)Delegate.Combine(whirlwind.action, new WorldAction(whirlwindEffect));
            localizeStatus("Redemoinho interno", "Redemoinho interno", whirlwind.description);
            AssetManager.status.add(whirlwind);

            StatusEffect dragonslayer = new StatusEffect();
            dragonslayer.id = "dragonslayer";
            dragonslayer.path_icon = "ui/icons/iconFlying";
            dragonslayer.texture = "fx_dragon_wings";
            dragonslayer.animated = true;
            dragonslayer.animation_speed = 0.160f;
            dragonslayer.base_stats[S.scale] = 0.025f;
            dragonslayer.base_stats[S.speed] = 50;
            dragonslayer.base_stats[S.knockback] = 0.5f;
            dragonslayer.base_stats[S.knockback_reduction] = 1f;
            dragonslayer.base_stats[S.attack_speed] = 100f;
            dragonslayer.base_stats[S.range] += -1f;
            dragonslayer.description = "Suas asas estão prontas para voar";
            dragonslayer.name = "Asas descoladas";
            dragonslayer.remove_status.Add("dragonshield");
            dragonslayer.opposite_status.Add("dragonshield");
            dragonslayer.tier = StatusTier.Advanced;
            dragonslayer.action_interval = 1.75f;
            dragonslayer.action = (WorldAction)Delegate.Combine(dragonslayer.action, new WorldAction(dragonslayerEffect));
            localizeStatus("Asas descoladas", "Asas descoladas", dragonslayer.description);
            AssetManager.status.add(dragonslayer);

            StatusEffect dragonshield = new StatusEffect();
            dragonshield.id = "dragonshield";
            dragonshield.duration = 90f;
            dragonshield.texture = "fx_dragonshield";
            dragonshield.random_flip = true;
            dragonshield.animated = true;
            dragonshield.animation_speed = 0.2f;
            dragonshield.base_stats[S.armor] = 100;
            dragonshield.base_stats[S.mod_attack_speed] = 0.75f;
            dragonshield.sound_idle = "event:/SFX/STATUS/StatusShield";
            dragonshield.base_stats[S.knockback_reduction] = 1f;
            dragonshield.path_icon = "ui/icons/iconDragonShield";
            dragonshield.description = "Suas asas o protegem";
            dragonshield.name = "Escudo de Escamas";
            dragonshield.remove_status.Add("frozen");
            dragonshield.remove_status.Add("burning");
            dragonshield.remove_status.Add("slowness");
            dragonshield.remove_status.Add("poisoned");
            dragonshield.remove_status.Add("dragonslayer");
            dragonshield.opposite_status.Add("frozen");
            dragonshield.opposite_status.Add("burning");
            dragonshield.opposite_status.Add("slowness");
            dragonshield.opposite_status.Add("poisoned");
            dragonshield.opposite_status.Add("dragonslayer");
            dragonshield.tier = StatusTier.Advanced;
            dragonshield.action_interval = 1.5f;
            dragonshield.action = (WorldAction)Delegate.Combine(dragonshield.action, new WorldAction(dragonshieldEffect));
            dragonshield.action_get_hit = (GetHitAction)Delegate.Combine(dragonshield.action_get_hit, new GetHitAction(dragonshieldReact));
            localizeStatus("Escudo de Escamas", "Escudo de Escamas", dragonshield.description);
            AssetManager.status.add(dragonshield);

            StatusEffect tamed = new StatusEffect();
            tamed.id = "tamed";
            tamed.duration = 16f;
            tamed.random_flip = true;
            tamed.animated = true;
            tamed.animation_speed = 0.05f;
            tamed.path_icon = "ui/icons/iconTamed";
            tamed.description = "Domado por algum Dragonato";
            tamed.name = "Domesticado";
            tamed.remove_status.Add("slowness");
            tamed.opposite_status.Add("slowness");
            tamed.tier = StatusTier.Basic;
            tamed.action_interval = 0.125f;
            tamed.action = (WorldAction)Delegate.Combine(tamed.action, new WorldAction(tamedEffect));
            localizeStatus("Domesticado", "Domesticado", tamed.description);
            AssetManager.status.add(tamed);

            StatusEffect evilshield = new StatusEffect();
            evilshield.id = "evilshield";
            evilshield.duration = 90f;
            evilshield.texture = "fx_evilshield";
            evilshield.animated = true;
            evilshield.base_stats[S.armor] = 100;
            evilshield.base_stats[S.mod_attack_speed] = 0.75f;
            evilshield.sound_idle = "event:/SFX/STATUS/StatusShield";
            evilshield.base_stats[S.knockback_reduction] = 1f;
            evilshield.path_icon = "ui/icons/iconEvilShield";
            evilshield.description = "Protegido de tudo e todos";
            evilshield.name = "Escudo Maligno";
            evilshield.remove_status.Add("blessed_fire");
            evilshield.remove_status.Add("frozen");
            evilshield.remove_status.Add("burning");
            evilshield.remove_status.Add("slowness");
            evilshield.remove_status.Add("poisoned");
            evilshield.remove_status.Add("shield");
            evilshield.opposite_status.Add("blessed_fire");
            evilshield.opposite_status.Add("frozen");
            evilshield.opposite_status.Add("burning");
            evilshield.opposite_status.Add("slowness");
            evilshield.opposite_status.Add("poisoned");
            evilshield.opposite_status.Add("shield");
            evilshield.tier = StatusTier.Advanced;
            evilshield.action_get_hit = (GetHitAction)Delegate.Combine(evilshield.action_get_hit, new GetHitAction(evilshieldReact));
            localizeStatus("Escudo Maligno", "Escudo Maligno", evilshield.description);
            AssetManager.status.add(evilshield);

            StatusEffect voices_in_my_head = new StatusEffect();
            voices_in_my_head.id = "voices_in_my_head";
            voices_in_my_head.base_stats[S.diplomacy] = -1f;
            voices_in_my_head.base_stats[S.personality_rationality] = -0.2f;
            voices_in_my_head.base_stats[S.opinion] = -1f;
            voices_in_my_head.base_stats[S.knockback_reduction] = 1f;
            voices_in_my_head.duration = 90f;
            voices_in_my_head.path_icon = "ui/icons/iconVoicesInMyHead";
            voices_in_my_head.description = "Não posso obedecer... Sai da minha cabeça!";
            voices_in_my_head.name = "Vozes na minha cabeça";
            voices_in_my_head.opposite_status.Add("death_mark");
            voices_in_my_head.opposite_status.Add("peaceful");
            voices_in_my_head.action = new WorldAction(voices_in_my_headEffect);
            voices_in_my_head.action_interval = 0.5f;
            localizeStatus("Vozes na minha cabeça", "Vozes na minha cabeça", voices_in_my_head.description);
            AssetManager.status.add(voices_in_my_head);

            StatusEffect death_mark = new StatusEffect();
            death_mark.id = "death_mark";
            death_mark.base_stats[S.fertility] = -0.3f;
            death_mark.base_stats[S.knockback_reduction] = 1f;
            death_mark.duration = 120f;
            death_mark.path_icon = "ui/icons/iconDeathMark";
            death_mark.description = "A escuridão o chama. E ele VAI RESPONDER";
            death_mark.name = "Marca da Morte";
            death_mark.opposite_status.Add("peaceful");
            death_mark.opposite_status.Add("voices_in_my_head");
            death_mark.action = new WorldAction(death_markEffect);
            death_mark.action_interval = 0.5f;
            localizeStatus("Marca da Morte", "Marca da Morte", death_mark.description);
            AssetManager.status.add(death_mark);

            StatusEffect peaceful = new StatusEffect();
            peaceful.id = "peaceful";
            peaceful.base_stats[S.knockback_reduction] = 1f;
            peaceful.duration = 180f;
            peaceful.path_icon = "ui/icons/iconPeaceful";
            peaceful.description = "Nunca ataca primeiro";
            peaceful.name = "Pacífico";
            peaceful.opposite_status.Add("voices_in_my_head");
            peaceful.opposite_status.Add("death_mark");
            peaceful.action = new WorldAction(peacefulEffect);
            peaceful.action_interval = 0.5f;
            localizeStatus("Pacífico", "Pacífico", peaceful.description);
            AssetManager.status.add(peaceful);

            StatusEffect poisoned = AssetManager.status.get("poisoned");
            poisoned.action = (WorldAction)Delegate.Combine(poisoned.action, new WorldAction(poisonedEffect));
            poisoned.base_stats[S.mod_speed] = -0.25f;
            poisoned.base_stats[S.mod_attack_speed] = -0.25f;
            poisoned.base_stats[S.dodge] = -0.5f;
            poisoned.opposite_status.Add("dragonshield");
            poisoned.opposite_status.Add("evilshield");
            poisoned.opposite_status.Add("blessed");
            poisoned.opposite_traits.Add("dragonslayer");
            poisoned.opposite_traits.Add("blessed");
            poisoned.action_interval = 1f;

            StatusEffect frozen = AssetManager.status.get("frozen");
            frozen.opposite_status.Add("dragonshield");
            frozen.opposite_status.Add("evilshield");
            frozen.opposite_status.Add("blessed_fire");
            frozen.opposite_status.Add("blessed");
            frozen.opposite_traits.Add("dragonslayer");
            frozen.opposite_traits.Add("blessed");

            StatusEffect burning = AssetManager.status.get("burning");
            burning.opposite_status.Add("dragonshield");
            burning.opposite_status.Add("evilshield");
            burning.opposite_status.Add("blessed_fire");
            burning.opposite_status.Add("blessed");
            burning.opposite_traits.Add("dragonslayer");
            burning.opposite_traits.Add("blessed");

            StatusEffect slowness = AssetManager.status.get("slowness");
            slowness.opposite_status.Add("dragonshield");
            slowness.opposite_status.Add("evilshield");
            slowness.opposite_status.Add("blessed");
            slowness.opposite_status.Add("tamed");
            slowness.opposite_traits.Add("flower_prints");
            slowness.opposite_traits.Add("dragonslayer");
            slowness.opposite_traits.Add("blessed");
            slowness.tier = StatusTier.Advanced;

            StatusEffect shield = AssetManager.status.get("shield");
            shield.opposite_status.Add("evilshield");
            shield.remove_status.Add("evilshield");
            shield.opposite_status.Add("blessed");
            shield.opposite_traits.Add("dragonslayer");
            shield.opposite_traits.Add("mageslayer");
        }
        public static bool civilizedEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget.a.kingdom.data.banner_icon_id > -1)
            {
                pTarget.a.addStatusEffect("civilized");
            }
            if (!pTarget.a.hasTrait("boat"))
            {
                if (pTarget.a.asset.needFood == true && pTarget.a.data.hunger <= 50)
                {
                    pTarget.a.restoreStatsFromEating(5, 0.1f, true);
                }
                List<Kingdom> enemies = World.world.wars.getEnemiesOf(pTarget.a.kingdom);
                if (!pTarget.a.has_attack_target && !pTarget.a.is_moving && pTarget.a.kingdom.cities.Count > 0)
                {
                    if (enemies.Count > 0 && enemies.First() != null && enemies.First().cities.Count > 0)
                    {
                        Kingdom enemy = enemies.First();
                        City enemycity = enemy.cities.First();
                        if (enemycity.zones != null)
                        {
                            List<TileZone> zones = enemycity.zones;
                            int randomIntZone = Toolbox.randomInt(0, zones.Count);
                            TileZone randomZone = zones[randomIntZone];
                            if (randomZone.tiles != null)
                            {
                                List<WorldTile> tiles = randomZone.tiles;
                                int randomIntTile = Toolbox.randomInt(0, tiles.Count);
                                WorldTile RandomTileInRandomZone = randomZone.tiles[randomIntTile];
                                if (!zones.Contains(pTile.zone))
                                {
                                    pTarget.a.goTo(RandomTileInRandomZone);
                                }
                            }
                        }
                    }
                    else if (pTarget.a.kingdom.capital != null && pTarget.a.kingdom.capital.zones != null)
                    {
                        List<TileZone> zones = pTarget.a.kingdom.capital.zones;
                        int randomIntZone = Toolbox.randomInt(0, zones.Count);
                        TileZone randomZone = zones[randomIntZone];
                        if (randomZone.tiles != null)
                        {
                            List<WorldTile> tiles = randomZone.tiles;
                            int randomIntTile = Toolbox.randomInt(0, tiles.Count);
                            WorldTile RandomTileInRandomZone = randomZone.tiles[randomIntTile];
                            if (!zones.Contains(pTile.zone))
                            {
                                pTarget.a.goTo(RandomTileInRandomZone);
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static bool blessedFireEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            pTarget.a.startColorEffect(ActorColorEffect.White);
            pTarget.a.getHit(pTarget.a.getMaxHealth() / 33);
            return true;
        }
        public static bool blessedFireReact(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            pSelf.a.spawnParticle(Toolbox.color_white_32);
            pSelf.a.startColorEffect(ActorColorEffect.White);
            return true;
        }
        public static bool enchantedEffect(BaseSimObject pTarget, WorldTile pTile)
        {
            Actor a = pTarget.a;
            if (a.asset.unit == false || !a.hasTrait("blessed") || a.hasWeapon())
            {
                return false;
            }
            else if (pTile.Type.biome_id == ST.biome_enchanted)
            {
                if (Toolbox.randomChance(0.2f))
                {
                    Traits.PopulateWorld(a);
                }
            }
            else if (a.data.health > a.getMaxHealth() / 2)
            {
                a.finishStatusEffect("enchanted");
                a.colorEffect = 0f;
            }
            a.stats[S.range] = a.data.level + a.data.kills;
            Traits.AttachEffect(a, "fx_divine_bless");
            a.startColorEffect(ActorColorEffect.White);
            a.colorEffect = 5f;
            return true;
        }
        public static bool enchantedReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (a.asset.unit == false || !a.hasTrait("blessed") || a.hasWeapon())
            {
                return false;
            }
            else
            {
                a.startColorEffect(ActorColorEffect.White);
                a.colorEffect = 5f;
                if (pAttackedBy != null && pAttackedBy.isActor() && pAttackedBy.isAlive())
                {
                    Traits.clearBadTraitsFrom(pSelf);
                    float num = Toolbox.randomFloat(1f, pAttackedBy.a.stats[S.damage]);
                    int regeneration = (int)(pAttackedBy.a.stats[S.damage] / num);
                    Traits.clearBadTraitsFrom(a);
                    a.restoreHealth(regeneration);
                    a.spawnParticle(Toolbox.color_white_32);
                }
            }
            return true;
        }
        public static bool whirlwindEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            string[] kingdom = { pTarget.a.kingdom.data.id };
            pTarget.a.startColorEffect(ActorColorEffect.White);
            pTarget.a.colorEffect = 5f;
            pTarget.a.spawnParticle(Toolbox.makeColor("#c2c2c2", -1f));
            pTarget.a.startShake(0.8f, 0.4f, true, false);
            if (pTarget.a.kingdom.data.banner_icon_id > -1)
            {
                int pDamage = (int)pTarget.a.stats[S.damage_range];
                World.world.applyForce(pTile, 10, 0.5f, false, false, pDamage, kingdom, pTarget, null);
            }
            return true;
        }
        public static bool poisonedEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            BaseSimObject attackedBy = pTarget.a.attackedBy;
            if (attackedBy != null && attackedBy.isActor() && attackedBy.isAlive() && attackedBy.a.hasTrait("venomous") && attackedBy.a.data.health < pTarget.a.data.health / 3)
            {
                pTarget.a.spawnParticle(Toolbox.makeColor("#9900ff", -1f));
                pTarget.a.startShake(0.6f, 0.3f, true, false);
            }
            return true;
        }
        public static bool evilshieldReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            Traits.AttachEffect(pSelf, "fx_evilshield_hit");
            pSelf.a.spawnParticle(Toolbox.color_red);
            return true;
        }
        public static bool dragonslayerEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Traits.AttachEffect(pTarget, "fx_dragon_tail");
            pTarget.a.restoreHealth(pTarget.a.getMaxHealth() / 33);
            if (pTarget.a.is_moving)
            {
                pTarget.a.changeMoveJumpOffset(0.5f);
            }
            pTarget.a.spawnParticle(Toolbox.color_red);
            return true;
        }
        public static bool dragonshieldEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            pTarget.a.spawnParticle(Toolbox.color_red);
            if (pTarget.a.data.health > pTarget.a.getMaxHealth() / 2)
            {
                pTarget.a.finishStatusEffect("dragonshield");
            }
            return true;
        }
        public static bool dragonshieldReact(BaseSimObject pSelf, BaseSimObject pAttackedBy, WorldTile pTile = null)
        {
            if (pAttackedBy != null && pAttackedBy.isActor() && pAttackedBy.isAlive())
            {
                Traits.AttachEffect(pSelf, "fx_dragonshield_hit");
                MusicBox.playSound("event:/SFX/UNITS/UNIQUE/Dragon/DragonSwoop", pTile, false, false);
                pSelf.a.spawnParticle(Toolbox.color_red);
                int regeneration = (int)pSelf.a.getMaxHealth() / 20;
                pAttackedBy.a.getHit(pSelf.a.data.kills);
                if (Toolbox.randomChance(0.25f))
                {
                    pSelf.a.restoreHealth(regeneration);
                }
            }
            return true;
        }
        public static bool tamedEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget.a.kingdom.data.banner_icon_id > -1)
            {
                pTarget.a.addStatusEffect("tamed");
            }
            if (pTarget.a.ai.task != null && pTarget.a.kingdom.cities.Count > 0)
            {
                pTarget.a.GetComponent<Dragon>().aggroTargets.RemoveWhere((Actor enemy) => enemy != null && enemy.kingdom != null && !enemy.kingdom.isEnemy(pTarget.a.kingdom));
                List<Kingdom> enemies = World.world.wars.getEnemiesOf(pTarget.a.kingdom);
                if (enemies.Count > 0 && enemies.First() != null && enemies.First().cities.Count > 0)
                {
                    Kingdom enemy = enemies.First();
                    City enemycity = enemy.cities.First();
                    List<TileZone> zones = enemycity.zones;
                    int randomIntZone = Toolbox.randomInt(0, zones.Count);
                    TileZone randomZone = zones[randomIntZone];
                    List<WorldTile> tiles = randomZone.tiles;
                    int randomIntTile = Toolbox.randomInt(0, tiles.Count);
                    WorldTile RandomTileInRandomZone = randomZone.tiles[randomIntTile];
                    if (pTarget.a.GetComponent<Dragon>().aggroTargets.Count == 0)
                    {
                        if (zones.Contains(pTile.zone))
                        {
                            if (Toolbox.randomBool() && pTarget.a.ai.task.id != "dragon_landattack" && pTarget.a.ai.task.id != "dragon_up")
                            {
                                pTarget.a.ai.setTask("dragon_landattack", true);
                            }
                        }
                        else
                        {
                            if (pTarget.a.moveJumpOffset.y > 0f)
                            {
                                pTarget.a.goTo(RandomTileInRandomZone);
                            }
                            else if (pTarget.a.ai.task.id != "dragon_fly" && pTarget.a.ai.task.id != "dragon_up")
                            {
                                pTarget.a.ai.setTask("dragon_up", true);
                            }
                        }
                    }
                    else
                    {
                        foreach (City city in pTarget.a.kingdom.cities)
                        {
                            if (city.zones.Contains(pTile.zone))
                            {
                                pTarget.a.GetComponent<Dragon>().aggroTargets.Clear();
                            }
                        }
                    }
                }
                else if (pTarget.a.kingdom.capital != null)
                {
                    List<TileZone> zones = pTarget.a.kingdom.capital.zones;
                    int randomIntZone = Toolbox.randomInt(0, zones.Count);
                    TileZone randomZone = zones[randomIntZone];
                    List<WorldTile> tiles = randomZone.tiles;
                    int randomIntTile = Toolbox.randomInt(0, tiles.Count);
                    WorldTile RandomTileInRandomZone = randomZone.tiles[randomIntTile];
                    if (pTarget.a.GetComponent<Dragon>().aggroTargets.Count == 0)
                    {
                        if (zones.Contains(pTile.zone))
                        {
                            if (pTarget.a.ai.task.id != "dragon_sleep")
                            {
                                pTarget.a.ai.setTask("dragon_sleep", true);
                            }
                        }
                        else
                        {
                            if (pTarget.a.moveJumpOffset.y > 0f)
                            {
                                pTarget.a.goTo(RandomTileInRandomZone);
                            }
                            else if (pTarget.a.ai.task.id != "dragon_fly" && pTarget.a.ai.task.id != "dragon_up")
                            {
                                pTarget.a.ai.setTask("dragon_up", true);
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static bool peacefulEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            a.removeTrait("regeneration");
            a.removeTrait("evil");
            a.removeTrait("fire_proof");
            a.removeTrait("immortal");
            Traits.MageRegenerationEffects(pTarget);
            if (a.hasWeapon())
            {
                ActorEquipmentSlot actorEquipmentSlot = a.equipment.weapon;
                ItemData data = actorEquipmentSlot.data;
                if (data.id != "white_staff")
                {
                    Traits.GiveWeapon(a, "white_staff", "base");
                    Traits.GiveWeaponWithMagicEffects(a, "fx_teleport_blue", "freeze_proof", "peaceful", "event:/SFX/UNITS/ColdOne/ColdOneDeath");
                }
            }
            return true;
        }
        public static bool death_markEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            a.removeTrait("freeze_proof");
            a.removeTrait("fire_proof");
            a.removeTrait("immortal");
            Traits.MageRegenerationEffects(pTarget);
            if (a.hasWeapon())
            {
                ActorEquipmentSlot actorEquipmentSlot = a.equipment.weapon;
                ItemData data = actorEquipmentSlot.data;
                if (data.id != "necromancer_staff")
                {
                    Traits.GiveWeapon(a, "necromancer_staff", "base");
                    Traits.GiveWeaponWithMagicEffects(a, "fx_teleport_green", "evil", "death_mark", "regeneration");
                }
            }
            return true;
        }
        public static bool voices_in_my_headEffect(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            a.removeTrait("freeze_proof");
            a.removeTrait("regeneration");
            Traits.MageRegenerationEffects(pTarget);
            if (a.hasWeapon())
            {
                ActorEquipmentSlot actorEquipmentSlot = a.equipment.weapon;
                ItemData data = actorEquipmentSlot.data;
                if (data.id != "evil_staff")
                {
                    Traits.GiveWeapon(a, "evil_staff", "base");
                    Traits.GiveWeaponWithMagicEffects(a, "fx_teleport_red", "evil", "voices_in_my_head", "fire_proof", "immortal", "event:/SFX/UNITS/EvilMage/EvilMageDeath");
                }
            }
            return true;
        }
        public static void localizeStatus(string id, string name, string description)
        {
            Dictionary<string, string> localizedText = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "localizedText") as Dictionary<string, string>;
            localizedText.Add(id, name);
            localizedText.Add(description, description);
        }
    }
}
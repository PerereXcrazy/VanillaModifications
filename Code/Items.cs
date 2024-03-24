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
    class Items
    {
        public static void init()
        {
            ItemAsset energized_weapon = AssetManager.items.clone("energized_weapon", "_melee");
            energized_weapon.id = "energized_weapon";
            energized_weapon.path_icon = "ui/Icons/items/icon_ring_energized_base";
            energized_weapon.materials = List.Of<string>(new string[] { "base" });
            energized_weapon.path_slash_animation = "effects/slashes/slash_base";
            energized_weapon.base_stats[S.knockback] = 2f;
            energized_weapon.base_stats[S.range] = 2f;
            energized_weapon.base_stats[S.accuracy] = 1f;
            energized_weapon.base_stats[S.critical_damage_multiplier] = 0.1f;
            energized_weapon.equipment_value = 100;
            energized_weapon.attackType = WeaponType.Melee;
            energized_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "ring_name",
            });
            energized_weapon.action_attack_target = new AttackAction(LightningAttack);
            energized_weapon.action_special_effect = new WorldAction(LightningRule);
            energized_weapon.equipmentType = EquipmentType.Weapon;
            energized_weapon.name_class = "item_class_weapon";
            energized_weapon.special_effect_interval = 0;
            AssetManager.items.list.AddItem(energized_weapon);
            Localization.addLocalization("item_energized_weapon", "Anel Energizado");
            addWeaponsSprite(energized_weapon.id, energized_weapon.materials[0]);

            ItemAsset whirlwind_weapon = AssetManager.items.clone("whirlwind_weapon", "_range");
            whirlwind_weapon.id = "whirlwind_weapon";
            whirlwind_weapon.path_icon = "ui/Icons/items/icon_ring_whirlwind_silver";
            whirlwind_weapon.materials = List.Of<string>(new string[] { "silver" });
            whirlwind_weapon.projectile = "TornadoProjectile";
            whirlwind_weapon.path_slash_animation = "effects/slashes/slash_base";
            whirlwind_weapon.base_stats[S.mod_damage] = -0.75f;
            whirlwind_weapon.base_stats[S.attack_speed] = 1f;
            whirlwind_weapon.base_stats[S.accuracy] = 1f;
            whirlwind_weapon.base_stats[S.targets] = 10f;
            whirlwind_weapon.base_stats[S.critical_damage_multiplier] = 0.1f;
            whirlwind_weapon.equipment_value = 100;
            whirlwind_weapon.attackType = WeaponType.Range;
            whirlwind_weapon.base_stats[S.projectiles] = 1f;
            whirlwind_weapon.base_stats[S.range] = 100f;
            whirlwind_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "ring_name",
            });
            whirlwind_weapon.action_special_effect = new WorldAction(TornadoRule);
            whirlwind_weapon.equipmentType = EquipmentType.Weapon;
            whirlwind_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(whirlwind_weapon);
            Localization.addLocalization("item_whirlwind_weapon", "Anel Transtornado");
            addWeaponsSprite(whirlwind_weapon.id, whirlwind_weapon.materials[0]);

            ItemAsset mega_heartbeat_weapon = AssetManager.items.clone("mega_heartbeat_weapon", "_range");
            mega_heartbeat_weapon.id = "mega_heartbeat_weapon";
            mega_heartbeat_weapon.path_icon = "ui/Icons/items/icon_ring_mega_heartbeat_steel";
            mega_heartbeat_weapon.materials = List.Of<string>(new string[] { "steel" });
            mega_heartbeat_weapon.projectile = "ForceProjectile";
            mega_heartbeat_weapon.path_slash_animation = "effects/slashes/slash_base";
            mega_heartbeat_weapon.base_stats[S.attack_speed] = 1f;
            mega_heartbeat_weapon.base_stats[S.accuracy] = 1f;
            mega_heartbeat_weapon.base_stats[S.targets] = 2f;
            mega_heartbeat_weapon.base_stats[S.knockback] = 2.5f;
            mega_heartbeat_weapon.base_stats[S.critical_damage_multiplier] = 0.1f;
            mega_heartbeat_weapon.equipment_value = 100;
            mega_heartbeat_weapon.attackType = WeaponType.Range;
            mega_heartbeat_weapon.base_stats[S.projectiles] = 1f;
            mega_heartbeat_weapon.base_stats[S.range] = 100f;
            mega_heartbeat_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "plague_doctor_staff_name",
            });
            mega_heartbeat_weapon.action_special_effect = new WorldAction(ForceRule);
            mega_heartbeat_weapon.equipmentType = EquipmentType.Weapon;
            mega_heartbeat_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(mega_heartbeat_weapon);
            Localization.addLocalization("item_mega_heartbeat_weapon", "Anel Impactante");
            addWeaponsSprite(mega_heartbeat_weapon.id, mega_heartbeat_weapon.materials[0]);

            ItemAsset fire_blood_weapon = AssetManager.items.clone("fire_blood_weapon", "_range");
            fire_blood_weapon.id = "fire_blood_weapon";
            fire_blood_weapon.path_icon = "ui/Icons/items/icon_ring_fire_blood_copper";
            fire_blood_weapon.materials = List.Of<string>(new string[] { "copper" });
            fire_blood_weapon.projectile = "FireProjectile";
            fire_blood_weapon.path_slash_animation = "effects/slashes/slash_base";
            fire_blood_weapon.base_stats[S.attack_speed] = 1f;
            fire_blood_weapon.base_stats[S.mod_damage] = -0.5f;
            fire_blood_weapon.base_stats[S.accuracy] = 1f;
            fire_blood_weapon.base_stats[S.targets] = 2f;
            fire_blood_weapon.base_stats[S.critical_damage_multiplier] = 0.1f;
            fire_blood_weapon.equipment_value = 100;
            fire_blood_weapon.attackType = WeaponType.Range;
            fire_blood_weapon.base_stats[S.projectiles] = 3f;
            fire_blood_weapon.base_stats[S.range] = 100f;
            fire_blood_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "flame_sword_name",
            });
            fire_blood_weapon.item_modifiers = List.Of<string>(new string[]
            {
            "flame"
            });
            fire_blood_weapon.action_special_effect = new WorldAction(FireRule);
            fire_blood_weapon.equipmentType = EquipmentType.Weapon;
            fire_blood_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(fire_blood_weapon);
            Localization.addLocalization("item_fire_blood_weapon", "Anel Flamejante");
            addWeaponsSprite(fire_blood_weapon.id, fire_blood_weapon.materials[0]);

            ItemAsset cold_aura_weapon = AssetManager.items.clone("cold_aura_weapon", "_range");
            cold_aura_weapon.id = "cold_aura_weapon";
            cold_aura_weapon.path_icon = "ui/Icons/items/icon_ring_cold_aura_mythril";
            cold_aura_weapon.materials = List.Of<string>(new string[] { "mythril" });
            cold_aura_weapon.projectile = "IceProjectile";
            cold_aura_weapon.path_slash_animation = "effects/slashes/slash_base";
            cold_aura_weapon.base_stats[S.attack_speed] = 1f;
            cold_aura_weapon.base_stats[S.mod_damage] = -0.75f;
            cold_aura_weapon.base_stats[S.accuracy] = 1f;
            cold_aura_weapon.base_stats[S.targets] = 2f;
            cold_aura_weapon.base_stats[S.critical_damage_multiplier] = 0.05f;
            cold_aura_weapon.equipment_value = 100;
            cold_aura_weapon.attackType = WeaponType.Range;
            cold_aura_weapon.base_stats[S.projectiles] = 3f;
            cold_aura_weapon.base_stats[S.range] = 100f;
            cold_aura_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "white_staff_name",
            });
            cold_aura_weapon.item_modifiers = List.Of<string>(new string[]
            {
            "ice"
            });
            cold_aura_weapon.action_special_effect = new WorldAction(IceRule);
            cold_aura_weapon.equipmentType = EquipmentType.Weapon;
            cold_aura_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(cold_aura_weapon);
            Localization.addLocalization("item_cold_aura_weapon", "Anel Congelante");
            addWeaponsSprite(cold_aura_weapon.id, cold_aura_weapon.materials[0]);

            ItemAsset acid_blood_weapon = AssetManager.items.clone("acid_blood_weapon", "_range");
            acid_blood_weapon.id = "acid_blood_weapon";
            acid_blood_weapon.path_icon = "ui/Icons/items/icon_ring_acid_blood_bronze";
            acid_blood_weapon.materials = List.Of<string>(new string[] { "bronze" });
            acid_blood_weapon.projectile = "AcidProjectile";
            acid_blood_weapon.path_slash_animation = "effects/slashes/slash_base";
            acid_blood_weapon.base_stats[S.attack_speed] = 1.5f;
            acid_blood_weapon.base_stats[S.mod_damage] = -0.5f;
            acid_blood_weapon.base_stats[S.accuracy] = 1f;
            acid_blood_weapon.base_stats[S.targets] = 2f;
            acid_blood_weapon.base_stats[S.critical_damage_multiplier] = 0.1f;
            acid_blood_weapon.equipment_value = 100;
            acid_blood_weapon.attackType = WeaponType.Range;
            acid_blood_weapon.base_stats[S.projectiles] = 4f;
            acid_blood_weapon.base_stats[S.range] = 100f;
            acid_blood_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "necromancer_staff_name",
            });
            acid_blood_weapon.action_attack_target = new AttackAction(AcidEnd);
            acid_blood_weapon.action_special_effect = new WorldAction(AcidRule);
            acid_blood_weapon.equipmentType = EquipmentType.Weapon;
            acid_blood_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(acid_blood_weapon);
            Localization.addLocalization("item_acid_blood_weapon", "Anel Corrosivo");
            addWeaponsSprite(acid_blood_weapon.id, acid_blood_weapon.materials[0]);

            ItemAsset venomous_weapon = AssetManager.items.clone("venomous_weapon", "_range");
            venomous_weapon.id = "venomous_weapon";
            venomous_weapon.path_icon = "ui/Icons/items/icon_ring_venomous_iron";
            venomous_weapon.materials = List.Of<string>(new string[] { "iron" });
            venomous_weapon.projectile = "PoisonProjectile";
            venomous_weapon.path_slash_animation = "effects/slashes/slash_base";
            venomous_weapon.base_stats[S.attack_speed] = 1f;
            venomous_weapon.base_stats[S.accuracy] = 1f;
            venomous_weapon.base_stats[S.targets] = 2f;
            venomous_weapon.base_stats[S.critical_damage_multiplier] = -0.75f;
            venomous_weapon.base_stats[S.mod_damage] = -0.75f;
            venomous_weapon.equipment_value = 100;
            venomous_weapon.attackType = WeaponType.Range;
            venomous_weapon.base_stats[S.projectiles] = 2f;
            venomous_weapon.base_stats[S.range] = 100f;
            venomous_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "blaster_name",
            });
            venomous_weapon.action_attack_target = new AttackAction(PoisonEnd);
            venomous_weapon.action_special_effect = new WorldAction(PoisonRule);
            venomous_weapon.equipmentType = EquipmentType.Weapon;
            venomous_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(venomous_weapon);
            Localization.addLocalization("item_venomous_weapon", "Anel Venenoso");
            addWeaponsSprite(venomous_weapon.id, venomous_weapon.materials[0]);

            ItemAsset flower_prints_weapon = AssetManager.items.clone("flower_prints_weapon", "_range");
            flower_prints_weapon.id = "flower_prints_weapon";
            flower_prints_weapon.path_icon = "ui/Icons/items/icon_ring_flower_prints_wood";
            flower_prints_weapon.materials = List.Of<string>(new string[] { "wood" });
            flower_prints_weapon.projectile = "NatureProjectile";
            flower_prints_weapon.path_slash_animation = "effects/slashes/slash_base";
            flower_prints_weapon.base_stats[S.attack_speed] = 1f;
            flower_prints_weapon.base_stats[S.mod_damage] = -0.5f;
            flower_prints_weapon.base_stats[S.accuracy] = 1f;
            flower_prints_weapon.base_stats[S.targets] = 2f;
            flower_prints_weapon.base_stats[S.critical_damage_multiplier] = 0.1f;
            flower_prints_weapon.equipment_value = 100;
            flower_prints_weapon.attackType = WeaponType.Range;
            flower_prints_weapon.base_stats[S.projectiles] = 4f;
            flower_prints_weapon.base_stats[S.range] = 100f;
            flower_prints_weapon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
            "druid_staff_name",
            });
            flower_prints_weapon.item_modifiers = List.Of<string>(new string[]
            {
            "slowness"
            });
            flower_prints_weapon.action_attack_target = new AttackAction(NatureEnd);
            flower_prints_weapon.action_special_effect = new WorldAction(NatureRule);
            flower_prints_weapon.equipmentType = EquipmentType.Weapon;
            flower_prints_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(flower_prints_weapon);
            Localization.addLocalization("item_flower_prints_weapon", "Anel Florestal");
            addWeaponsSprite(flower_prints_weapon.id, flower_prints_weapon.materials[0]);

            ItemAsset dragonslayer_weapon = AssetManager.items.clone("dragonslayer_weapon", "_melee");
            dragonslayer_weapon.id = "dragonslayer_weapon";
            dragonslayer_weapon.path_icon = "ui/Icons/items/icon_dragonslayer_adamantine";
            dragonslayer_weapon.materials = List.Of<string>(new string[] { "adamantine" });
            dragonslayer_weapon.path_slash_animation = "effects/slashes/slash_base";
            dragonslayer_weapon.base_stats[S.knockback] = 1f;
            dragonslayer_weapon.base_stats[S.accuracy] = 100f;
            dragonslayer_weapon.base_stats[S.targets] = 5f;
            dragonslayer_weapon.base_stats[S.mod_attack_speed] = -0.75f;
            dragonslayer_weapon.base_stats[S.critical_damage_multiplier] = 5f;
            dragonslayer_weapon.equipment_value = 100;
            dragonslayer_weapon.attackType = WeaponType.Melee;
            dragonslayer_weapon.base_stats[S.projectiles] = 1f;
            dragonslayer_weapon.name_templates = List.Of<string>(new string[]
            {
            "evil_staff_name",
            });
            dragonslayer_weapon.item_modifiers = List.Of<string>(new string[]
            {
            "flame"
            });
            dragonslayer_weapon.action_attack_target = new AttackAction(DragonEnd);
            dragonslayer_weapon.action_special_effect = new WorldAction(DragonRule);
            dragonslayer_weapon.equipmentType = EquipmentType.Weapon;
            dragonslayer_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(dragonslayer_weapon);
            Localization.addLocalization("item_dragonslayer_weapon", "Alma Dragoniana");
            addCenteredWeaponsSprite(dragonslayer_weapon.id, dragonslayer_weapon.materials[0]);

            ItemAsset angel_weapon = AssetManager.items.clone("angel_weapon", "_range");
            angel_weapon.id = "angel_weapon";
            angel_weapon.path_icon = "ui/Icons/items/icon_angel_base";
            angel_weapon.materials = List.Of<string>(new string[] { "base" });
            angel_weapon.projectile = "DivineProjectile";
            angel_weapon.path_slash_animation = "effects/slashes/slash_base";
            angel_weapon.base_stats[S.damage_range] = 0f;
            angel_weapon.base_stats[S.accuracy] = 100f;
            angel_weapon.base_stats[S.targets] = 15f;
            angel_weapon.base_stats[S.critical_damage_multiplier] = 5f;
            angel_weapon.equipment_value = 3333;
            angel_weapon.attackType = WeaponType.Range;
            angel_weapon.base_stats[S.projectiles] = 3f;
            angel_weapon.base_stats[S.range] = 1000f;
            angel_weapon.name_templates = List.Of<string>(new string[]
            {
            "white_staff_name",
            });
            angel_weapon.action_attack_target = new AttackAction(BlessEnd);
            angel_weapon.action_special_effect = new WorldAction(BlessRule);
            angel_weapon.equipmentType = EquipmentType.Weapon;
            angel_weapon.name_class = "item_class_weapon";
            AssetManager.items.list.AddItem(angel_weapon);
            Localization.addLocalization("item_angel_weapon", "Cajado Divino");
            addWeaponsStaffSprite(angel_weapon.id, angel_weapon.materials[0]);
        }
        public static bool LightningAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget != null && pTarget.isActor())
            {
                Traits.Projectile(pSelf, pTarget, pTile, "LightningProjectile");
                int regeneration = pTarget.a.getMaxHealth() - pTarget.a.data.health;
                pSelf.a.restoreHealth(regeneration);
                pTarget.a.spawnParticle(Toolbox.color_heal);
            }
            return true;
        }
        public static bool LightningRule(BaseSimObject pTarget, WorldTile pTile)
        {
            Particle(pTarget, "#000000", "#00ffff", "#ffffff");
            if (!pTarget.a.hasTrait("energized"))
            {
                MapBox.spawnLightningSmall(pTile, 0.25f);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            return false;
        }
        public static bool TornadoRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Particle(pTarget, "#d0e1e3", "#90acaf", "#608993");
            if (!pTarget.a.hasTrait("whirlwind"))
            {
                ActionLibrary.castTornado(null, pTarget, null);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            return false;
        }
        public static bool ForceRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Particle(pTarget, "#e0e0e0", "#adadbe", "#68667f");
            if (!pTarget.a.hasTrait("mega_heartbeat"))
            {
                int num = pTarget.a.data.level / 2 + pTarget.a.data.kills;
                World.world.applyForce(pTile, num, num, true, true, num, null, pTarget, null);
                EffectsLibrary.spawnExplosionWave(pTile.posV3, num, num);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            return false;
        }
        public static bool FireRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (!pTarget.a.hasTrait("fire_blood"))
            {
                ActionLibrary.fireBloodEffect(pTarget, null);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            return false;
        }
        public static bool IceRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (!pTarget.a.hasTrait("cold_aura"))
            {
                Traits.traitDeathEffect(pTarget, SD.snow);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            Particle(pTarget, "#ffffff", "#a5c1d5", "#8ebacf");
            return false;
        }
        public static bool AcidEnd(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget.a == null)
            {
                return false;
            }
            pSelf.a.spawnParticle(Toolbox.makeColor("#00ff00", -1f));
            MapAction.checkAcidTerraform(pTile);
            World.world.particlesSmoke.spawn(pTile.posV3);
            return true;
        }
        public static bool AcidRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Particle(pTarget, "#fff4c5", "#e4f339", "#adcf3a");
            if (!pTarget.a.hasTrait("acid_blood"))
            {
                ActionLibrary.acidBloodEffect(pTarget, null);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            return false;
        }
        public static bool PoisonEnd(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (pTarget.a == null)
            {
                return false;
            }
            if (!pTarget.a.hasStatus("poisoned"))
            {
                pTarget.a.addStatusEffect("poisoned");
            }
            else
            {
                float pDamage = pTarget.a.data.health * 0.5f;
                if (Toolbox.randomBool() && pTarget.a.data.health > 1)
                {
                    pTarget.a.getHit(pDamage, true, AttackType.Poison, null, true, false);
                }
            }
            return true;
        }
        public static bool PoisonRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Particle(pTarget, "#a31bc9", "#5e226f", "#332038");
            if (!pTarget.a.hasTrait("venomous"))
            {
                Traits.PoisonDeath(pTarget);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            return false;
        }
        public static bool NatureEnd(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (!pSelf.a.is_moving)
            {
                pTile = pSelf.a.currentTile;
                World.world.getObjectsInChunks(pTile, 5, MapObjectType.Building);
                for (int i = 0; i < World.world.temp_map_objects.Count; i++)
                {
                    Building building = (Building)World.world.temp_map_objects[i];
                    {
                        if (building != null)
                        {
                            return false;
                        }
                    }
                }
                BrushData LevelBrush = Traits.ApropriateBrush(pSelf.a);
                for (int i = 0; i < LevelBrush.pos.Length; i++)
                {
                    int num = pTile.x + LevelBrush.pos[i].x;
                    int num2 = pTile.y + LevelBrush.pos[i].y;
                    if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height && Toolbox.randomBool())
                    {
                        WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                        for (int t = 0; t < tileSimple.neighbours.Length; t++)
                        {
                            MapAction.decreaseTile(pTile, "flash");
                            if(Toolbox.randomBool())
                            {
                                MapAction.increaseTile(tileSimple.neighbours[t], "flash");
                            }
                        }
                    }
                }
            }
            return true;
        }
        public static bool NatureRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (!pTarget.a.hasTrait("flower_prints"))
            {
                Traits.NatureDeath(pTarget, pTile);
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            Particle(pTarget, "#86bc4e", "#385c3c", "#624833");
            BiomeAsset biome_asset = pTile.Type.biome_asset;
            if (biome_asset == null)
            {
                return false;
            }
            if (!pTarget.a.has_attack_target && Toolbox.randomBool() && World.world_era.id != "age_chaos")
            {
                BrushData LevelBrush = Traits.ApropriateBrush(pTarget.a);
                for (int i = 0; i < LevelBrush.pos.Length; i++)
                {
                    int num = pTile.x + LevelBrush.pos[i].x;
                    int num2 = pTile.y + LevelBrush.pos[i].y;
                    if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height)
                    {
                        WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                        if (tileSimple.Type.mountains)
                        {
                            MapAction.decreaseTile(tileSimple, "flash");
                        }
                    }
                }
            }
            return true;
        }
        public static bool DragonRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (!pTarget.a.hasTrait("dragonslayer"))
            {
                Traits.AttachEffect(pTarget.a, "fx_dragon_actor_death");
                if (pTarget.a.stats[S.health] > 999)
                {
                    Actor actor = World.world.units.spawnNewUnit(SA.dragon, pTile, true, 0f);
                    EffectsLibrary.spawnAtTileRandomScale("fx_boulder_impact", actor.currentTile, 0.1f, 0.2f);
                    pTarget.a.killHimself();
                }
                else
                {
                    pTarget.a.getHit(pTarget.a.getMaxHealth());
                }
            }
            return true;
        }
        public static bool DragonEnd(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget.a == null)
            {
                return false;
            }
            if (pSelf.a.hasTrait("super_health"))
            {
                pSelf.a.restoreHealth(pSelf.a.data.health / 20);
                EffectsLibrary.spawnAt("fx_dragon", pSelf.a.currentPosition, pSelf.a.stats[S.scale]);
                BrushData LevelBrush = Traits.ApropriateBrush(pSelf.a);
                for (int i = 0; i < LevelBrush.pos.Length; i++)
                {
                    int num = pTile.x + LevelBrush.pos[i].x;
                    int num2 = pTile.y + LevelBrush.pos[i].y;
                    if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height)
                    {
                        WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                        Traits.DragonbornAttackTile(pSelf.a, tileSimple);
                    }
                }
            }
            else
            {
                pSelf.a.restoreHealth(pSelf.a.data.health / 40);
                ActionLibrary.fireBloodEffect(pSelf);
            }
            return true;
        }
        public static bool BlessRule(BaseSimObject pTarget, WorldTile pTile = null)
        {
            if (!pTarget.a.hasTrait("blessed"))
            {
                pTarget.a.getHit(pTarget.a.getMaxHealth());
            }
            Particle(pTarget, "#e8a965", "#ffdb6e", "#ffffff");
            return true;
        }
        public static bool BlessEnd(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget.a == null)
            {
                return false;
            }
            else if (Toolbox.randomChance(0.2f))
            {
                EffectsLibrary.spawnAt("fx_divine_fire", pTarget.currentPosition, pTarget.a.stats[S.scale]);
            }
            pTarget.a.addStatusEffect("blessed_fire");
            pTarget.a.startColorEffect(ActorColorEffect.White);
            return true;
        }
        public static bool Particle(BaseSimObject pTarget, string pColor0, string pColor1, string pColor2)
        {
            if (!MapBox.isRenderGameplay())
            {
                return false;
            }
            if (pTarget.isBuilding())
            {
                return false;
            }
            Actor a = pTarget.a;
            if (!a.is_visible)
            {
                return false;
            }
            Sprite renderedItem = a.getRenderedItem();
            if (renderedItem == null)
            {
                return false;
            }
            AnimationFrameData animationFrameData = a.getAnimationFrameData();
            if (animationFrameData == null)
            {
                return false;
            }
            Vector3 pVector = default(Vector3);
            pVector.x = a.curTransformPosition.x + animationFrameData.posItem.x * a.currentScale.x;
            pVector.y = a.curTransformPosition.y + animationFrameData.posItem.y * a.currentScale.y;
            pVector.z = -0.01f;
            float num = renderedItem.rect.height * a.currentScale.y;
            if (a.is_moving)
            {
                pVector.y += num;
                pVector.x += Toolbox.randomFloat(-0.1f, 0.1f);
                pVector.y += Toolbox.randomFloat(-0.1f, 0.2f);
            }
            else
            {
                pVector.x += Toolbox.randomFloat(-0.05f, 0.05f);
                float num2 = Toolbox.randomFloat(0f, num * 1.5f);
                if ((double)num2 < (double)num * 0.5)
                {
                    pVector.x += Toolbox.randomFloat(-0.15f, 0.15f);
                }
                pVector.y += num2;
            }
            if (a.curAngle.y != 0f || a.curAngle.z != 0f)
            {
                pVector = Toolbox.RotatePointAroundPivot(ref pVector, ref a.curTransformPosition, ref a.curAngle);
            }
            BaseEffect baseEffect = EffectsLibrary.spawn("fx_weapon_particle", null, null, null, 0f, -1f, -1f);
            if (baseEffect != null)
            {
                Action[] comandos = {
                () => ((StatusParticle)baseEffect).spawnParticle(pVector, Toolbox.makeColor(pColor0, -1f), 0.25f),
                () => ((StatusParticle)baseEffect).spawnParticle(pVector, Toolbox.makeColor(pColor1, -1f), 0.25f),
                () => ((StatusParticle)baseEffect).spawnParticle(pVector, Toolbox.makeColor(pColor2, -1f), 0.25f)
                };
                System.Random random = new System.Random();
                int indiceAleatorio = random.Next(0, comandos.Length);
                comandos[indiceAleatorio]();
                Console.ReadLine();
                return true;
            }
            return false;
        }
        static void addWeaponsSprite(string id, string material)
        {
            var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            var sprite = Resources.Load<Sprite>("items/w_" + id + "_" + material);
            dictItems.Add(sprite.name, sprite);
        }
        static void addWeaponsStaffSprite(string id, string material)
        {
            var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            var sprite = Resources.Load<Sprite>("items/staff/w_" + id + "_" + material);
            dictItems.Add(sprite.name, sprite);
        }
        static void addCenteredWeaponsSprite(string id, string material)
        {
            var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
            var sprite = Resources.Load<Sprite>("items/center/w_" + id + "_" + material);
            dictItems.Add(sprite.name, sprite);
        }
    }
}
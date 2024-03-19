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
    class Projectiles
    { 
	    public static void init()
        {
            var Bless = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "DivineProjectile",
                look_at_target = false,
                speed_random = 5f,
                texture = "bless_projectile",
                trailEffect_enabled = true,
                trailEffect_id = "fx_divine_sound",
                trailEffect_scale = 1f,
                trailEffect_timer = 0f,
                texture_shadow = string.Empty,
                endEffect = string.Empty,
                terraformOption = "flash",
                terraformRange = 1,
                draw_light_area = true,
                draw_light_size = 0.1f,
                looped = true,
                parabolic = true,
                sound_impact = "event:/SFX/DROPS/DropBlessing",
                startScale = 0.05f,
                targetScale = 0.1f,
            });
            Bless.world_actions = new AttackAction(BlessEnd);
            var Lightning = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "LightningProjectile",
                look_at_target = true,
                speed = 0.5f,
                animation_speed = 0.075f,
                texture = "lightning_projectile",
                trailEffect_enabled = false,
                texture_shadow = string.Empty,
                endEffect = string.Empty,
                looped = false,
                hitShake = true,
                shakeDuration = 0.05f,
                shakeInterval = 0.01f,
                shakeIntensity = 0.25f,
                terraformOption = "lightning_soft",
                terraformRange = 1,
                draw_light_area = true,
                draw_light_size = 0.1f,
                parabolic = false,
                sound_launch = string.Empty,
                sound_impact = "event:/SFX/EXPLOSIONS/ExplosionLightningStrike",
                startScale = 0.035f,
                targetScale = 0.035f,
            });
            Lightning.world_actions = new AttackAction(LightningEnd);
            var Force = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "ForceProjectile",
                look_at_target = true,
                speed = 40f,
                speed_random = 50f,
                texture = "null",
                trailEffect_enabled = true,
                trailEffect_id = "fx_force_wave",
                trailEffect_scale = 1f,
                trailEffect_timer = 0f,
                texture_shadow = string.Empty,
                endEffect = string.Empty,
                hitShake = true,
                shakeDuration = 0.5f,
                shakeInterval = 0.01f,
                shakeIntensity = 0.25f,
                terraformOption = string.Empty,
                terraformRange = 1,
                draw_light_area = false,
                parabolic = false,
                sound_launch = string.Empty,
                sound_impact = "event:/SFX/EXPLOSIONS/ExplosionForce",
                startScale = 0.025f,
                targetScale = 0.05f,
            });
            Force.world_actions = new AttackAction(ForceEnd);
            var Tornado = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "TornadoProjectile",
                look_at_target = true,
                speed_random = 4f,
                texture = "null",
                trailEffect_enabled = false,
                texture_shadow = string.Empty,
                endEffect = "fx_tornado",
                hitShake = false,
                terraformOption = string.Empty,
                terraformRange = 1,
                draw_light_area = false,
                parabolic = false,
                sound_launch = string.Empty,
                sound_impact = string.Empty,
                looped = false,
                startScale = 0.025f,
                targetScale = 0.05f,
            });
            Tornado.world_actions =  new AttackAction(TornadoEnd);
            var Fire = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "FireProjectile",
                look_at_target = true,
                speed_random = 7.5f,
                texture = "fire_projectile",
                trailEffect_enabled = false,
                texture_shadow = string.Empty,
                endEffect = string.Empty,
                hitShake = false,
                terraformOption = "fire_soft",
                terraformRange = 1,
                draw_light_area = true,
                draw_light_size = 0.1f,
                parabolic = true,
                sound_launch = "event:/SFX/WEAPONS/WeaponFireballStart",
                sound_impact = "event:/SFX/WEAPONS/WeaponFireballLand",
                looped = true,
                startScale = 0.05f,
                targetScale = 0.3275f,
            });
            var Ice = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "IceProjectile",
                look_at_target = true,
                speed_random = 5f,
                animation_speed = 0.5f,
                texture = "snow_projectile",
                trailEffect_enabled = false,
                texture_shadow = string.Empty,
                endEffect = string.Empty,
                hitShake = false,
                terraformOption = string.Empty,
                terraformRange = 1,
                draw_light_area = true,
                draw_light_size = 0.025f,
                parabolic = true,
                sound_launch = "event:/SFX/WEAPONS/WeaponFreezeOrbStart",
                sound_impact = "event:/SFX/WEAPONS/WeaponFreezeOrbLand",
                looped = true,
                startScale = 0.05f,
                targetScale = 0.125f,
            });
            Ice.world_actions = (AttackAction)Delegate.Combine(Ice.world_actions, new AttackAction(IceEnd));
            var Acid = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "AcidProjectile",
                look_at_target = true,
                speed_random = 7.5f,
                animation_speed = 1f,
                texture = "acid_projectile",
                trailEffect_enabled = false,
                texture_shadow = string.Empty,
                endEffect = string.Empty,
                hitShake = false,
                terraformOption = string.Empty,
                terraformRange = 1,
                draw_light_area = true,
                draw_light_size = 0.01f,
                parabolic = true,
                sound_launch = "event:/SFX/WEAPONS/WeaponGreenOrbStart",
                sound_impact = "event:/SFX/WEAPONS/WeaponGreenOrbLand",
                looped = true,
                startScale = 0.05f,
                targetScale = 0.2f,
            });
            Acid.world_actions = (AttackAction)Delegate.Combine(Acid.world_actions, new AttackAction(AcidEnd));
            var Poison = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "PoisonProjectile",
                look_at_target = true,
                speed = 5f,
                texture = "poison_projectile",
                trailEffect_enabled = false,
                texture_shadow = string.Empty,
                hitShake = false,
                terraformOption = string.Empty,
                draw_light_area = false,
                parabolic = true,
                sound_launch = "event:/SFX/WEAPONS/WeaponMadnessBallStart",
                sound_impact = "event:/SFX/WEAPONS/WeaponMadnessBallLand",
                looped = true,
                startScale = 0.05f,
                targetScale = 0.025f,
            });
            Poison.world_actions = (AttackAction)Delegate.Combine(Poison.world_actions, new AttackAction(PoisonEnd));
            var Nature = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "NatureProjectile",
                rotate = true,
                look_at_target = true,
                speed_random = 7.5f,
                animation_speed = 1.5f,
                texture = "nature_projectile",
                trailEffect_enabled = true,
                trailEffect_id = "fx_cast_ground_nature",
                trailEffect_scale = 0.1f,
                trailEffect_timer = 0.25f,
                texture_shadow = string.Empty,
                endEffect = string.Empty,
                hitShake = false,
                terraformOption = string.Empty,
                terraformRange = 1,
                draw_light_area = false,
                parabolic = true,
                sound_launch = "event:/SFX/WEAPONS/WeaponGreenOrbStart",
                sound_impact = "event:/SFX/WEAPONS/WeaponGreenOrbLand",
                looped = true,
                startScale = 0.05f,
                targetScale = 0.15f,
            });
            Nature.world_actions = (AttackAction)Delegate.Combine(Nature.world_actions, new AttackAction(NatureEnd));
            var Dragon = AssetManager.projectiles.add(new ProjectileAsset
            {
                id = "DragonProjectile",
                look_at_target = true,
                speed_random = 5f,
                texture = "fireball",
                trailEffect_enabled = false,
                texture_shadow = string.Empty,
                endEffect = "fx_dragon",
                hitShake = true,
                shakeDuration = 0.25f,
                shakeInterval = 0.01f,
                shakeIntensity = 0.125f,
                terraformOption = "dragon_attack",
                terraformRange = 3,
                draw_light_area = true,
                draw_light_size = 0.5f,
                parabolic = false,
                sound_launch = "event:/SFX/UNITS/UNIQUE/Dragon/DragonSwoop",
                looped = true,
                startScale = 0.1f,
                targetScale = 0.25f,
            });
        }
        public static bool BlessEnd(BaseSimObject pSelf, BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            if (Toolbox.randomChance(0.05f))
            {
                EffectsLibrary.spawnAtTile("fx_divine_fire", pTile, 0.1f);
            }
            World.world.flashEffects.flashPixel(pTile, 100, ColorType.White);
            for (int i = 0; i < pTile.neighbours.Length; i++)
            {
                World.world.flashEffects.flashPixel(pTile.neighbours[i], 100, ColorType.White);
            }
            World.world.getObjectsInChunks(pTile, 2, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (!actor.hasTrait("blessed") && Toolbox.randomChance(0.1f))
                {
                    actor.a.startColorEffect(ActorColorEffect.White);
                    actor.a.addStatusEffect("blessed_fire");
                }
                if (actor.asset.canBeKilledByDivineLight == true && pSelf != null)
                {
                    actor.removeTrait("fire_blood");
                    actor.removeTrait("burning_feet");
                    BrushData LevelBrush = Traits.ApropriateBrush(pSelf.a);
                    for (int t = 0; t < LevelBrush.pos.Length; t++)
                    {
                        int num = actor.currentTile.x + LevelBrush.pos[t].x;
                        int num2 = actor.currentTile.y + LevelBrush.pos[t].y;
                        if (num >= 0 && num < MapBox.width && num2 >= 0 && num2 < MapBox.height)
                        {
                            WorldTile tileSimple = MapBox.instance.GetTileSimple(num, num2);
                            Traits.DivineLightFX(tileSimple);
                        }
                    }
                }
            }
            return true;
        }
        public static bool LightningEnd(BaseSimObject pSelf, BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            World.world.getObjectsInChunks(pTile, 2, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (!actor.hasTrait("energized") && actor.has_attack_target)
                {
                    World.world.particlesFire.spawn(pTile.posV3);
                    actor.startColorEffect(ActorColorEffect.White);
                    MapBox.spawnLightningSmall(actor.currentTile, actor.stats[S.scale] / 2);
                }
            }
            return true;
        }
        public static bool IceEnd(BaseSimObject pSelf, BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            pTile.freeze(15);
            return true;
        }
        public static bool ForceEnd(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (pSelf.isAlive() && a.kingdom.data.banner_icon_id > -1)
            {
                string[] kingdom = { a.kingdom.data.id };
                float pDamage = a.stats[S.damage_range];
                int count = World.world.temp_map_objects.Count - 1;
                if (count > 0 && a.data.health > 0)
                {
                    int num = count * a.data.level / a.data.health;
                    int area = num / 2;
                    EffectsLibrary.spawnExplosionWave(pTile.posV3, area, num / 1.5f);
                    World.world.applyForce(pTile, area, num, false, false, num, kingdom, pSelf, null);
                }
                World.world.getObjectsInChunks(pTile, 3, MapObjectType.Actor);
                for (int i = 0; i < World.world.temp_map_objects.Count; i++)
                {
                    Actor actor = (Actor)World.world.temp_map_objects[i];
                    if(actor.kingdom != a.kingdom)
                    {
                        actor.addTrait("crippled");
                    }
                }
            }
            return true;
        }
        public static bool TornadoEnd(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (pSelf.isAlive() && a.kingdom.data.banner_icon_id > -1)
            {
                if (pTile.Type.canBeRemovedWithSpade)
                {
                    MapAction.removeGreens(pTile);
                }
                for (int t = 0; t < pTile.neighbours.Length; t++)
                {
                    WorldTile worldTile = pTile.neighbours[t];
                    if( worldTile.Type.canBeRemovedWithSpade)
                    {
                        MapAction.removeGreens(worldTile);
                    }
                }
                string[] kingdom = { a.kingdom.data.id };
                float pDamage = a.stats[S.damage_range];
                World.world.getObjectsInChunks(pTile, 5, MapObjectType.Actor);
                for (int i = 0; i < World.world.temp_map_objects.Count; i++)
                {
                    Actor actor = (Actor)World.world.temp_map_objects[i];
                    if (!actor.hasTrait("whirlwind"))
                    {
                        World.world.applyForce(pTile, 10, 0.5f, false, false, (int)pDamage, kingdom, pSelf, null);
                        actor.addTrait("crippled");
                    }
                    else
                    {
                        int regeneration = World.world.temp_map_objects.Count;
                        actor.spawnParticle(Toolbox.makeColor("#c2c2c2", -1f));
                        actor.restoreHealth(regeneration);
                    }
                }
            }
            return true;
        }
        public static bool AcidEnd(BaseSimObject pSelf, BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            MapAction.checkAcidTerraform(pTile);
            World.world.particlesSmoke.spawn(pTile.posV3);
            for (int i = 0; i < pTile.neighbours.Length; i++)
            {
                MapAction.checkAcidTerraform(pTile.neighbours[i]);
            }
            return true;
        }
        public static bool PoisonEnd(BaseSimObject pSelf, BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            Actor a = pSelf.a;
            if (pSelf.isAlive() && a.kingdom.data.banner_icon_id > -1)
            {
                float pDamage = pSelf.a.stats[S.damage_range];
                World.world.getObjectsInChunks(pTile, 5, MapObjectType.Actor);
                for (int i = 0; i < World.world.temp_map_objects.Count; i++)
                {
                    Actor actor = (Actor)World.world.temp_map_objects[i];
                    if (actor != a)
                    {
                        if (!actor.hasStatus("poisoned"))
                        {
                            actor.addStatusEffect("poisoned");
                        }
                        else
                        {
                            if (Toolbox.randomBool() && actor.data.health > 1)
                            {
                                actor.getHit(pDamage, true, AttackType.Poison, null, true, false);
                            }
                        }

                    }
                }
            }
            return true;
        }
        public static bool NatureEnd(BaseSimObject pSelf, BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            if (pTile.Type.biome_asset != null && pTile.Type.biome_asset.grow_type_selector_plants != null)
            {
                BuildingActions.tryGrowVegetationRandom(pTile, VegetationType.Trees, false, false);
            }
            if (pTile.burned_stages > 0 || pTile.isOnFire())
            {
                World.world.dropManager.spawnParabolicDrop(pTile, SD.rain, 0f, 0.1f, 5f, 0.5f, 4f, 0.15f);
            }
            return true;
        }
    }
}
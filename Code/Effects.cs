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
    class Effects
    {
        public static void init()
        {
            AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_spawn2",
                show_on_mini_map = true,
                sound_launch = "event:/SFX/DESTRUCTION/InfinityCoin",
                prefab_id = "effects/prefabs/PrefabSpawnSmall",
                draw_light_area = true,
                draw_light_size = 2f,
            });
            var divinebless = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_divine_bless",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_divine_bless",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = false,
                time_between_frames = 0.15f,
            });
            World.world.stackEffects.CallMethod("add", divinebless);

            var divineground = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_divine_fire",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_divine_fire_ground",
                sound_loop_idle = "event:/SFX/POWERS/Blessing",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.5f,
                time_between_frames = 0.15f,
                time_out_interval = 0.20000000298023224,
            });
            World.world.stackEffects.CallMethod("add", divineground);

            var divinesound = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_divine_sound",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/nada",
                sound_loop_idle = "event:/SFX/POWERS/Blessing",
                limit = 3333,
                draw_light_area = true,
                draw_light_size = 0.015f,
                time_between_frames = 1f,
            });
            World.world.stackEffects.CallMethod("add", divinesound);

            var teleportbless = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_teleport_yellow",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_teleport_yellow",
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.1f,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", teleportbless);

            var tornado = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_tornado",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_tornado_loop",
                sound_loop_idle = "event:/SFX/NATURE/TornadoIdleLoop",
                show_on_mini_map = true,
                limit = 15,
                draw_light_area = false,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", tornado);

            var lightninghorizontal = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_lightning_horizontal",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_lightning_horizontal",
                show_on_mini_map = true,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 1f,
                draw_light_area_offset_y = 5f,
                time_between_frames = 0.05f,
            });
            World.world.stackEffects.CallMethod("add", lightninghorizontal);

            var force = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_force_wave",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_explosion_wave",
                show_on_mini_map = false,
                limit = 9999,
                draw_light_area = false,
                time_between_frames = 0.1f,
            });
            World.world.stackEffects.CallMethod("add", force);

            var firetop = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_top_fire",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cast_top_fire",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", firetop);

            var icetop = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_top_ice",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cast_top_ice",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.1f,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", icetop);

            var acidend = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_top_acid",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cast_top_acid",
                sound_loop_idle = "event:/SFX/BUILDINGS_IDLE/IdleAcidGeyser",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.05f,
                time_between_frames = 0.075f,
            });
            World.world.stackEffects.CallMethod("add", acidend);

            var natureground = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_ground_nature",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_cast_ground_nature",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = false,
                time_between_frames = 0.1f,
            });
            World.world.stackEffects.CallMethod("add", natureground);

            var naturetop = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_top_nature",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cast_top_green",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = false,
                time_between_frames = 0.1f,
            });
            World.world.stackEffects.CallMethod("add", naturetop);

            var dragon = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragon",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_dragon",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.1f,
                time_between_frames = 0.08f,
                sound_launch = "event:/SFX/UNITS/UNIQUE/Dragon/DragonFirebreath",
            });
            World.world.stackEffects.CallMethod("add", dragon);

            var dragonEffect = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragon_actor",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_dragon_actor",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.085f,
                time_between_frames = 0.125f,
                sound_launch = "event:/SFX/UNITS/UNIQUE/Dragon/DragonFirebreath",
            });
            World.world.stackEffects.CallMethod("add", dragonEffect);

            var dragonDeathEffect = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragon_actor_death",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_dragon_actor_death",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.085f,
                time_between_frames = 0.125f,
                sound_launch = "event:/SFX/UNITS/UNIQUE/Dragon/DragonFirebreath",
            });
            World.world.stackEffects.CallMethod("add", dragonDeathEffect);

            var dragontail = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragon_tail",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_dragon_tail",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.16f,
            });

            var dragonhorns = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragonshield_horns",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_dragonshield_horns",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.25f,
            });

            var dragonshield = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragonshield",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_dragonshield",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.1f,
                time_between_frames = 0.2f,
            });
            World.world.stackEffects.CallMethod("add", dragonshield);

            var dragonshieldAttackMode = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragonshield_attackmode",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_dragonshield_attackmode",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.1f,
                time_between_frames = 0.1f,
            });
            World.world.stackEffects.CallMethod("add", dragonshieldAttackMode);

            var dragonshieldHit = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_dragonshield_hit",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_dragonshield_hit",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.1f,
                time_between_frames = 0.1f,
            });
            World.world.stackEffects.CallMethod("add", dragonshieldHit);

            var whitemageTop = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_top_whitemage",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_cast_top_whitemage",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
                sound_launch = "event:/SFX/UNITS/ColdOne/ColdOneDeath",
            });
            World.world.stackEffects.CallMethod("add", whitemageTop);

            var whitemageGround = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_ground_whitemage",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cast_ground_whitemage",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", whitemageGround);

            var necromancerTop = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_top_necromancer",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_cast_top_necromancer",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
                sound_launch = "event:/SFX/UNITS/Skeleton/SkeletonDeath",
            });
            World.world.stackEffects.CallMethod("add", necromancerTop);

            var necromancerTeleport = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_teleport_green",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_teleport_green",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.05f,
                time_between_frames = 0.12f,
                sound_launch = "event:/SFX/UNITS/Snowman/SnowmanDeath",
            });
            World.world.stackEffects.CallMethod("add", necromancerTeleport);

            var evilmageTop = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_top_evilmage",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_cast_top_evilmage",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
                sound_launch = "event:/SFX/UNITS/Demon/DemonDeath",
            });
            World.world.stackEffects.CallMethod("add", evilmageTop);

            var evilmageGround = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_cast_ground_evilmage",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsBack",
                sprite_path = "effects/fx_cast_ground_evilmage",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", evilmageGround);

            var evilshield = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_evilshield",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_evilshield",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", evilshield);

            var evilshieldHit = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_evilshield_hit",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_evilshield_hit",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
            });
            World.world.stackEffects.CallMethod("add", evilshieldHit);

            var blessedshield = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_blessedshield",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_blessedshield",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
                time_between_frames = 0.08f,
            });
            World.world.stackEffects.CallMethod("add", blessedshield);

            var blessedshieldHit = AssetManager.effects_library.add(new EffectAsset
            {
                id = "fx_blessedshield_hit",
                use_basic_prefab = true,
                sorting_layer_id = "EffectsTop",
                sprite_path = "effects/fx_blessedshield_hit",
                show_on_mini_map = false,
                limit = 15,
                draw_light_area = true,
                draw_light_size = 0.25f,
            });
            World.world.stackEffects.CallMethod("add", blessedshieldHit);
        }
    }
}

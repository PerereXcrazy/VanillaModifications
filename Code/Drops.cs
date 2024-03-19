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
    class Drops
    {
        public static void init()
        {
            var poison = AssetManager.drops.add(new DropAsset
            {
                id = "poison",
                path_texture = "drops/drop_plague",
                random_frame = true,
                default_scale = 0.1f,
                action_landed = new DropsAction(action_poison),
                material = "mat_world_object_lit",
                sound_drop = "event:/SFX/DROPS/DropPlague"
            });
            AssetManager.drops.add(poison);
        }
        public static void action_poison(WorldTile pTile = null, string pDropID = null)
        {
            World.world.getObjectsInChunks(pTile, 3, MapObjectType.Actor);
            for (int i = 0; i < World.world.temp_map_objects.Count; i++)
            {
                Actor actor = (Actor)World.world.temp_map_objects[i];
                if (actor.hasStatus("poisoned"))
                {
                    actor.startShake(0.3f, 0.1f, true, true);
                    actor.startColorEffect(ActorColorEffect.White);
                }
                else
                {
                    actor.addStatusEffect("poisoned");
                }
            }
        }
    }
}

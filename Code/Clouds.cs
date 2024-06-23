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
    class Clouds
    {
        public static void init()
        {
            List<string> list = List.Of<string>(new string[]
            {
            "effects/clouds/cloud_small_1",
            "effects/clouds/cloud_small_2"
            });
            List<string> list2 = List.Of<string>(new string[]
            {
            "effects/clouds/cloud_big_1",
            "effects/clouds/cloud_big_2",
            "effects/clouds/cloud_big_3"
            });
            List<string> list3 = new List<string>();
            list3.AddRange(list2);
            list3.AddRange(list);
            var fire = AssetManager.clouds.add(new CloudAsset
            {
                id = "cloud_fire3",
                color = Toolbox.makeColor("#FFB229", -1f),
                drop_id = SD.fire,
                path_sprites = list,
                cloud_action_1 = new CloudAction(CloudLibrary.spawnLightning),
                speed_max = 7f,
                considered_disaster = true,
                draw_light_area = true
            });
            AssetManager.clouds.add(fire);

            var fire2 = AssetManager.clouds.add(new CloudAsset());
            fire2.id = "cloud_fire2";
            fire2.color = Toolbox.makeColor("#FFB229", -1f);
            fire2.drop_id = SD.fire;
            fire2.path_sprites = list;
            fire2.cloud_action_1 = new CloudAction(CloudLibrary.dropAction);
            fire2.speed_max = 7f;
            fire2.considered_disaster = true;
            fire2.draw_light_area = true;
            AssetManager.clouds.add(fire2);

            AssetManager.clouds.add(new CloudAsset
            {
                id = "cloud_fire",
                color = Toolbox.makeColor("#FF3030", -1f),
                drop_id = "rage",
                cloud_action_1 = new CloudAction(CloudLibrary.dropAction),
                path_sprites = list,
                speed_max = 4f,
                considered_disaster = true,
                draw_light_area = true
            });
        }
    }
}

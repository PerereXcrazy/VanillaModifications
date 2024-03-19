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
    class Kingdoms
    {
        public static void init()
        {

            KingdomAsset orc = AssetManager.kingdoms.get(SK.orc);
            orc.addTag(SK.civ);
            orc.addFriendlyTag(SK.neutral);
            orc.addFriendlyTag(SK.good);
            orc.addEnemyTag(SK.bandits);

            KingdomAsset orc2 = AssetManager.kingdoms.get(SK.nomads_orc);
            orc2.addFriendlyTag(SK.neutral);
            orc2.addFriendlyTag(SK.good);
            orc2.addEnemyTag(SK.bandits);

            KingdomAsset druid = AssetManager.kingdoms.get(SK.druid);
            druid.addFriendlyTag(SK.orc);
            druid.addFriendlyTag(SK.nomads_orc);

            KingdomAsset good = AssetManager.kingdoms.get(SK.good);
            good.addFriendlyTag(SK.orc);
            good.addFriendlyTag(SK.nomads_orc);
        }
    }
}

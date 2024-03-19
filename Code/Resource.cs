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
    class Resource
    {
        public static void init()
        {
            List<string> empty = null;
            ResourceAsset mushrooms = AssetManager.resources.get(SR.mushrooms);
            mushrooms.give_trait = empty;
            ResourceAsset desert_berries = AssetManager.resources.get(SR.desert_berries);
            desert_berries.give_trait = empty;
            ResourceAsset peppers = AssetManager.resources.get(SR.peppers);
            peppers.give_trait = empty;
            ResourceAsset banana = AssetManager.resources.get(SR.bananas);
            banana.give_trait = empty;
            ResourceAsset crystal_salt = AssetManager.resources.get(SR.crystal_salt);
            crystal_salt.give_trait = empty;
            ResourceAsset evil_beets = AssetManager.resources.get(SR.evil_beets);
            evil_beets.give_trait = empty;
            ResourceAsset lemons = AssetManager.resources.get(SR.lemons);
            lemons.give_trait = empty;
            ResourceAsset meat = AssetManager.resources.get(SR.meat);
            meat.give_trait = empty;
            ResourceAsset sushi = AssetManager.resources.get(SR.sushi);
            sushi.give_trait = empty;
            ResourceAsset jam = AssetManager.resources.get(SR.jam);
            jam.give_trait = empty;
            ResourceAsset burger = AssetManager.resources.get(SR.burger);
            burger.give_trait = empty;
            ResourceAsset ale = AssetManager.resources.get(SR.ale);
            ale.give_trait = empty;
            ResourceAsset pie = AssetManager.resources.get(SR.pie);
            pie.give_trait = empty;
            ResourceAsset fish = AssetManager.resources.get(SR.fish);
            fish.give_trait = empty;
            ResourceAsset candy = AssetManager.resources.get(SR.candy);
            candy.give_trait = empty;
            ResourceAsset worms = AssetManager.resources.get(SR.worms);
            worms.give_trait = empty;
            ResourceAsset pine_cones = AssetManager.resources.get(SR.pine_cones);
            pine_cones.give_trait = empty;
            ResourceAsset snow_cucumbers = AssetManager.resources.get(SR.snow_cucumbers);
            snow_cucumbers.give_trait = empty;
        }
    }
}

using System.Reflection;
using RubberSlimeRemaster.Patchs;
using RubberSlimeRemaster.Slimes;
using SRML;
using SRML.SR;
using SRML.SR.Translation;
using TranslationAPI;
using UnityEngine;
using static SRML.SR.PediaRegistry;

namespace RubberSlimeRemaster
{
    public class Main : ModEntryPoint
    {
        public static Color color1 = new Color32(207, 64, 229, 255);
        public static Color color2 = new Color32(129, 42, 142, 255);
        public static Color color3 = new Color32(229, 78, 252, 255);

        public override void PreLoad()
        {
            RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Id.RUBBER_PLORT);
            RegisterIdentifiableMapping(Id.RUBBER_SLIME_ENTRY, Id.RUBBER_SLIME);
            SetPediaCategory(Id.RUBBER_SLIME_ENTRY, PediaCategory.SLIMES);
            new SlimePediaEntryTranslation(Id.RUBBER_SLIME_ENTRY).SetTitleTranslation("Rubber Slimes")
                .SetIntroTranslation("Sorta Solid…")
                .SetDietTranslation("Veggies and Sweets")
                .SetFavoriteTranslation("Royal Jelly")
                .SetSlimeologyTranslation("How they came to life? Idk, try invent some Rubber Slime lore lol")
                .SetRisksTranslation("There are no specific risk, coming from Rubber  Slimes")
                .SetPlortonomicsTranslation("Rubber Plort can be used as… well rubber");
            TranslationPatcher.AddUITranslation("m.foodgroup." + Id.SWEET_FOODGROUP.ToString().ToLower(), "Sweets");
            HarmonyInstance.PatchAll();
        }

        public override void Load()
        {
            TranslationUtil.RegisterAssembly(Assembly.GetExecutingAssembly());
            CreatePlort.CreateDreamPlort();
            CreateSlime.CreateRubberSlime();
            AddEatMap.PatchPinkSlimeEatMap();
            ConsoleInstance.Log("Loaded Rubber Slimes successfully");
        }
    }
}
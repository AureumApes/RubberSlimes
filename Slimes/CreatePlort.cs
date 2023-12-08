using SRML.SR;
using SRML.Utils;
using UnityEngine;
using Texture = RubberSlimeRemaster.Utility.Texture;

namespace RubberSlimeRemaster.Slimes
{
    public class CreatePlort
    {
        public static void CreateDreamPlort()
        {
            var b = PrefabUtils.CopyPrefab(
                SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT));
            b.GetComponent<Identifiable>().id = Id.RUBBER_PLORT;
            b.name = "Rubber Plort";
            LookupRegistry.RegisterIdentifiablePrefab(b);
            b.GetComponent<MeshRenderer>().material = Object.Instantiate(b.GetComponent<MeshRenderer>().material);
            b.GetComponent<MeshRenderer>().material.SetColor("_TopColor", Main.color1);
            b.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", Main.color2);
            b.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", Main.color1);
            SlimeEat.FoodGroup.PLORTS.UnregisterId(Id.RUBBER_PLORT);
            b.GetComponent<MeshRenderer>().material.SetColor("_CrackColor", Main.color3);
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT,
                SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Id.RUBBER_PLORT));
            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Id.RUBBER_PLORT).GetComponent<Vacuumable>()
                .size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.rubber_plort", "Rubber Plort");
            var icon = Texture.LoadTextureFromAssembly("rubberPlortIcon").AsSprite();
            LookupRegistry.RegisterVacEntry(Id.RUBBER_PLORT, Main.color1, icon);
            PlortRegistry.RegisterPlort(Id.RUBBER_PLORT, 100f, 10f);
            DroneRegistry.RegisterBasicTarget(Id.RUBBER_PLORT);
        }
    }
}
using SRML.SR;
using SRML.Utils;
using UnityEngine;
using Texture = RubberSlimeRemaster.Utility.Texture;

namespace RubberSlimeRemaster.Slimes
{
    public class CreateSlime
    {
        public static void CreateRubberSlime()
        {
            var byIdentifiableId =
                SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME);
            var definition = (SlimeDefinition)PrefabUtils.DeepCopyObject(byIdentifiableId);
            definition.AppearancesDefault = new SlimeAppearance[1];
            definition.Diet.Produces = new[]
            {
                Id.RUBBER_PLORT
            };
            definition.Diet.MajorFoodGroups = new[]
            {
                SlimeEat.FoodGroup.VEGGIES,
                Id.SWEET_FOODGROUP
            };
            definition.Diet.FavoriteProductionCount = 3;
            definition.Diet.Favorites = new[]
            {
                Identifiable.Id.ROYAL_JELLY_CRAFT
            };
            definition.Diet.EatMap?.Clear();
            definition.CanLargofy = false;
            definition.FavoriteToys = new Identifiable.Id[1]
            {
                Identifiable.Id.RUBBER_DUCKY_TOY
            };
            definition.Name = "Rubber Slime";
            definition.IdentifiableId = Id.RUBBER_SLIME;
            var slimeObj =
                PrefabUtils.CopyPrefab(
                    SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObj.name = "Rubber_Slime";
            slimeObj.GetComponent<PlayWithToys>().slimeDefinition = definition;
            slimeObj.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = definition;
            slimeObj.GetComponent<SlimeEat>().slimeDefinition = definition;
            slimeObj.GetComponent<Identifiable>().id = Id.RUBBER_SLIME;
            slimeObj.GetComponent<Vacuumable>().size = Vacuumable.Size.LARGE;
            slimeObj.transform.localScale = new Vector3(1f, 1f, 1f);
            Object.Destroy(slimeObj.GetComponent<PinkSlimeFoodTypeTracker>());

            var slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(byIdentifiableId.AppearancesDefault[0]);
            definition.AppearancesDefault[0] = slimeAppearance;
            foreach (var structure in slimeAppearance.Structures)
            {
                var defaultMaterials = structure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    var material = Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions
                        .GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME).AppearancesDefault[0].Structures[0]
                        .DefaultMaterials[0]);
                    material.SetColor("_TopColor", Main.color1);
                    material.SetColor("_MiddleColor", Main.color2);
                    material.SetColor("_BottomColor", Main.color1);
                    material.SetFloat("_Shininess", 1f);
                    material.SetFloat("_Gloss", 0.0f);
                    structure.DefaultMaterials[0] = material;
                }
            }

            foreach (var expressionFace in slimeAppearance.Face.ExpressionFaces)
            {
                if ((bool)(Object)expressionFace.Mouth)
                {
                    expressionFace.Mouth.SetColor("_MouthBot", new Color32(154, 23, 183, 255));
                    expressionFace.Mouth.SetColor("_MouthMid", new Color32(154, 23, 183, 255));
                    expressionFace.Mouth.SetColor("_MouthTop", new Color32(154, 23, 183, 255));
                }

                if ((bool)(Object)expressionFace.Eyes)
                {
                    expressionFace.Eyes.SetColor("_EyeRed", new Color32(183, 23, 42, 255));
                    expressionFace.Eyes.SetColor("_EyeGreen", new Color32(23, 183, 103, byte.MaxValue));
                    expressionFace.Eyes.SetColor("_EyeBlue", new Color32(40, 60, 68, byte.MaxValue));
                }
            }

            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = Main.color1,
                Middle = Main.color2,
                Bottom = Main.color1
            };
            slimeObj.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            LookupRegistry.RegisterIdentifiablePrefab(slimeObj);
            SlimeRegistry.RegisterSlimeDefinition(definition);
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT,
                SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Id.RUBBER_SLIME));
            var icon = slimeAppearance.Icon = Texture.LoadTextureFromAssembly("rubberSlimeIcon").AsSprite();
            slimeAppearance.ColorPalette.Ammo = Main.color1;
            SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Id.RUBBER_SLIME).GetComponent<Vacuumable>()
                .size = Vacuumable.Size.NORMAL;
            TranslationPatcher.AddActorTranslation("l.rubber_slime", "Rubber Slime");
            PediaRegistry.RegisterIdEntry(Id.RUBBER_SLIME_ENTRY, icon);
        }
    }
}
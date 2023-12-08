using System.Linq;

namespace RubberSlimeRemaster.Patchs
{
    internal class HarmonyPatch
    {
        [HarmonyLib.HarmonyPatch(typeof(SlimeEat))]
        [HarmonyLib.HarmonyPatch("GetFoodGroupIds")]
        internal static class FoodGroupPatch
        {
            public static void Postfix(ref Identifiable.Id[] __result, SlimeEat.FoodGroup group)
            {
                if (!SlimeEat.foodGroupIds.ContainsKey(Id.SWEET_FOODGROUP))
                    SlimeEat.foodGroupIds.Add(Id.SWEET_FOODGROUP, FoodClass.SWEETS_CLASS.ToArray());
                if (__result == null)
                    return;
                var list = __result.ToList();
                if (group == Id.SWEET_FOODGROUP)
                    foreach (var id in FoodClass.SWEETS_CLASS)
                        list.Add(id);
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(SlimeDiet))]
    [HarmonyLib.HarmonyPatch("GetFoodCategoryMsg")]
    internal static class FoodGroupPatchMsg
    {
        public static bool Prefix(ref string __result, Identifiable.Id id)
        {
            if (SlimeEat.GetFoodGroupIds(Id.SWEET_FOODGROUP).Contains(id))
                __result = "m.foodgroup." + Id.SWEET_FOODGROUP.ToString().ToLower();
            return false;
        }
    }
}
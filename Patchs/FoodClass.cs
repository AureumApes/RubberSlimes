using System.Collections.Generic;

namespace RubberSlimeRemaster.Patchs
{
    public class FoodClass
    {
        internal static HashSet<Identifiable.Id> SWEETS_CLASS = new HashSet<Identifiable.Id>();

        public static void Set()
        {
            SWEETS_CLASS.AddIfDoesNotContain(Identifiable.Id.WILD_HONEY_CRAFT);
            SWEETS_CLASS.AddIfDoesNotContain(Identifiable.Id.ROYAL_JELLY_CRAFT);
            SWEETS_CLASS.AddIfDoesNotContain(Identifiable.Id.HONEY_PLORT);
        }
    }
}
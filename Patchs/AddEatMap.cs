using SRML.SR.Utils;

namespace RubberSlimeRemaster.Patchs
{
    public class AddEatMap
    {
        public static void PatchPinkSlimeEatMap()
        {
            SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.PINK_SLIME)
                .AddEatMapEntry(new SlimeDiet.EatMapEntry
                {
                    eats = Identifiable.Id.JELLYSTONE_CRAFT,
                    becomesId = Id.RUBBER_SLIME,
                    producesId = Identifiable.Id.NONE
                });
        }
    }
}
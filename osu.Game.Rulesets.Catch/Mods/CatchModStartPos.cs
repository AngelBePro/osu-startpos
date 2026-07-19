// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Catch.Objects;

namespace osu.Game.Rulesets.Catch.Mods
{
    public class CatchModStartPos : ModStartPos
    {
        public override void ApplyToBeatmap(IBeatmap beatmap)
        {
            base.ApplyToBeatmap(beatmap);

            if (StartTime.Value <= 0)
                return;

            double offset = StartTime.Value * 1000 + FirstObjectTime;

            if (beatmap is Beatmap<CatchHitObject> catchBeatmap)
                catchBeatmap.HitObjects.RemoveAll(h => h.StartTime < offset);
        }
    }
}

// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Taiko.Objects;

namespace osu.Game.Rulesets.Taiko.Mods
{
    public class TaikoModStartPos : ModStartPos
    {
        public override void ApplyToBeatmap(IBeatmap beatmap)
        {
            base.ApplyToBeatmap(beatmap);

            if (StartTime.Value <= 0)
                return;

            double offset = StartTime.Value * 1000 + FirstObjectTime;

            if (beatmap is Beatmap<TaikoHitObject> taikoBeatmap)
                taikoBeatmap.HitObjects.RemoveAll(h => h.StartTime < offset);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NSW.StarCitizen.Tools.Global;
using NSW.StarCitizen.Tools.Update;

namespace NSW.StarCitizen.Tools.Localization
{
    public sealed class GitHubLocalizationRepository : GitHubUpdateRepository, ILocalizationRepository
    {
        public GameMode Mode { get; }

        public GitHubLocalizationRepository(GameMode mode, string name, string repository) :
            base(GitHubDownloadType.Sources, GitHubUpdateInfo.Factory.NewWithVersionByName(), name, repository)
        {
            Mode = mode;
        }

        public ILocalizationInstaller Installer { get; } = new DefaultLocalizationInstaller();

        public override async Task<List<UpdateInfo>> GetAllAsync(CancellationToken cancellationToken)
        {
            var updates = await base.GetAllAsync(cancellationToken).ConfigureAwait(false);
            return updates.Where(i => IsTagNameForMode(i.TagName, Mode)).ToList();
        }

        private static bool IsTagNameForMode(string tagName, GameMode mode)
        {
            if (mode != GameMode.LIVE)
            {
                return tagName.EndsWith($"-{mode}", StringComparison.OrdinalIgnoreCase);
            }
            int index = tagName.LastIndexOf("-", StringComparison.Ordinal);
            if (index < 0 || index == tagName.Length - 1)
            {
                return true;
            }
            if (Enum.TryParse(tagName.Substring(index + 1), true, out GameMode tagMode))
            {
                return tagMode == mode;
            }
            return true;
        }
    }
}
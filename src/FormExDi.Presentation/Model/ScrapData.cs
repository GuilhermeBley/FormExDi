namespace FormExDi.Presentation.Model
{
    /// <summary>
    /// Data scrap
    /// </summary>
    internal class ScrapData
    {
        /// <summary>
        /// None
        /// </summary>
        public static ScrapData None { get; } = Create(null!, string.Empty, string.Empty, null, null, 0, 0, 0 ,0);

        public string Id { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime? DtStart { get; private set; } = null;
        public DateTime? DtEnd { get; private set; } = null;
        public int CurrentSearch { get; private set; } = 0;
        public int TotalSearch { get; private set; } = 0;
        public int CountScrap { get; private set; } = 0;
        public int CountInProgress { get; private set; } = 0;

        private ScrapData(string id, string name, string description, DateTime? start, DateTime? end, int currentSearch, int totalSearch, int countScrap, int countInProgress) 
        { 
            Id = id;
            Name = name;
            Description = description;
            DtStart = start;
            DtEnd = end;
            CurrentSearch = currentSearch;
            TotalSearch = totalSearch;
            CountScrap = countScrap;
            CountInProgress = countInProgress;
        }

        public static ScrapData Create(string id, string name, string description, DateTime? start, DateTime? end, int currentSearch, int totalSearch, int countScrap, int countInProgress)
        {
            if (id is null)
                id = Guid.Empty.ToString();
            if (name is null)
                name = string.Empty;
            if (description is null)
                description = string.Empty;
            if (currentSearch < 0)
                currentSearch = 0;
            if (totalSearch < 0)
                totalSearch = 0;
            if (currentSearch > totalSearch)
                currentSearch = totalSearch;
            if (start is not null && end is not null && start > end)
                start = end;
            if (countScrap < 0)
                countScrap = 0;
            if (countInProgress < 0)
                countInProgress = 0;
            if (countInProgress > countScrap)
                countInProgress = countScrap;

            return new(id, name, description, start, end, currentSearch, totalSearch, countScrap, countInProgress);
        }
    }
}

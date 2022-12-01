namespace FormExDi.Presentation.Model
{
    internal class SearchsQttStatus
    {
        private object _lock = new();
        private int _currentQtd = 0;
        private int _totalQtd = 0;
        public int CurrentQtd => _currentQtd;
        public int TotalQtd => _totalQtd;

        public SearchsQttStatus(int currentQtd, int totalQtd)
        {
            if (currentQtd < 0 || currentQtd > totalQtd)
                currentQtd = 0;
            if (totalQtd < 0)
                totalQtd = 0;

            _currentQtd = currentQtd;
            _totalQtd = totalQtd;
        }

        public void AddCurrent()
        {
            lock(_lock)
                _currentQtd++;
        }

        public override string ToString()
        {
            return $"{_currentQtd}/{_totalQtd}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Portfolio.Model;

namespace Portfolio.Service
{
    public class KalenderEventFileService : AbstractFileService<KalenderEvent>, IKalenderEventService
    {
        private ObservableCollection<KalenderEvent> _kalenderEvents;

        public async Task<ObservableCollection<KalenderListItem>> GetKalenderEvents()
        {
            _kalenderEvents = await OpenOrCreateFileAndGetContents();
            var a = new List<KalenderEvent>
            {
                new KalenderEvent() {Date = DateTime.Now, EventName = "Zwemmen"},
                new KalenderEvent() {Date = DateTime.Now.AddDays(15), EventName = "Fuif Aspiranten"},
                new KalenderEvent() {Date = DateTime.Now.AddDays(30), EventName = "Wafelverkoop"},
                new KalenderEvent() {Date = DateTime.Now.AddDays(50), EventName = "Eetdag"},
                new KalenderEvent() {Date = DateTime.Now.AddDays(80), EventName = "Geen chiro wegens leidersweekend"},
                new KalenderEvent() {Date = DateTime.Now.AddDays(95), EventName = "Sporthal"},
                new KalenderEvent() {Date = DateTime.Now.AddDays(200), EventName = "Chirofeesten"},
                new KalenderEvent() {Date = DateTime.Now.AddDays(500), EventName = "Kamp"}
            };
            _kalenderEvents = new ObservableCollection<KalenderEvent>(a);
            if (_kalenderEvents.Count == 0)
            {
                return new ObservableCollection<KalenderListItem>();
            }

            var result = new List<KalenderListItem>();
            var currentGroup = _kalenderEvents[0].Date;
            foreach (var item in _kalenderEvents)
            {
                if (result.Count == 0)
                {
                    result.Add(new KalenderHeaderItem() { Date = currentGroup });
                }
                var currentDate = item.Date;
                if (currentDate.Year != currentGroup.Year || currentDate.Month != currentGroup.Month)
                {
                    result.Add(new KalenderHeaderItem() { Date = currentDate });
                    currentGroup = currentDate;
                }

                result.Add(item);
            }

            return new ObservableCollection<KalenderListItem>(result);
        }

        protected override string GetFileName()
        {
            return "kalenderEvents.json";
        }

        protected override ObservableCollection<KalenderEvent> GetItems()
        {
            return _kalenderEvents;
        }
    }
}

using System.Collections.Generic;

namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        bool Contains(long v);
        TimeEntry Find(long v);
        TimeEntry Create(TimeEntry toCreate);
        IEnumerable<TimeEntry> List();
        TimeEntry Update(long v, TimeEntry theUpdate);
        void Delete(long v);
    }
}
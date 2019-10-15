using System.Collections.Generic;

namespace PalTracker
{
    public interface ITimeEntryRepository
    {
        bool Contains(int v);
        TimeEntry Find(int v);
        TimeEntry Create(TimeEntry toCreate);
        List<TimeEntry> List();
        TimeEntry Update(int v, TimeEntry theUpdate);
        void Delete(int v);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository:ITimeEntryRepository
    {
        public List<TimeEntry> _timeEntry; 
        public int count=0;
        
        public InMemoryTimeEntryRepository()
        {
            _timeEntry= new List<TimeEntry>();
            count=0;

        }
         
        public TimeEntry Create(TimeEntry timeEntry)
        {
            _timeEntry.Add(new TimeEntry(++count,timeEntry.projectId,timeEntry.userId,timeEntry.date,timeEntry.hours));
            return _timeEntry[count-1];
        }

        public TimeEntry Find(int v)
        {
            return _timeEntry[v-1];
        }

        public bool Contains(int v)
        {
           return _timeEntry.Count == v;
        }

        public List<TimeEntry> List()
        {
            return _timeEntry;
        }

        public TimeEntry Update(int v, TimeEntry timeEntry)
        {
           
                var tempTimeEntry = _timeEntry[v-1];
                tempTimeEntry.projectId = timeEntry.projectId;
                tempTimeEntry.userId = timeEntry.userId;
                tempTimeEntry.hours = timeEntry.hours;
                tempTimeEntry.date = timeEntry.date;
                _timeEntry[v-1] = tempTimeEntry;
                return _timeEntry[v-1];
           
        }

        public void Delete(int v)
        {
           var timeEntry = Find(v);
           _timeEntry.Remove(timeEntry);
           count--;
        }
    }
}
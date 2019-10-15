using System;
using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository:ITimeEntryRepository
    {
        public List<TimeEntry> _timeEntry; 
        public Dictionary<int, TimeEntry> _timeEntry1;
        public int count=0;
        
        public InMemoryTimeEntryRepository()
        {
            _timeEntry= new List<TimeEntry>();
            _timeEntry1 = new Dictionary<int, TimeEntry>();
            count=0;

        }
         
        public TimeEntry Create(TimeEntry timeEntry)
        {
            timeEntry.id = ++count;
            _timeEntry1.Add(timeEntry.id,timeEntry);
            //_timeEntry.Add(new TimeEntry(++count,timeEntry.projectId,timeEntry.userId,timeEntry.date,timeEntry.hours));
            return _timeEntry1[count];
        }

        public TimeEntry Find(int v)
        {
           //return _timeEntry.FirstOrDefault(x=>x.id ==v);
           return _timeEntry1.ContainsKey(v) ? _timeEntry1[v] : new TimeEntry();
        }

        public bool Contains(int v)
        {
        //    return _timeEntry.Exists(x=>x.id == v);
            return _timeEntry1.ContainsKey(v);
        }

        public List<TimeEntry> List()
        {
           return _timeEntry1.Values.ToList();
        }

        public TimeEntry Update(int v, TimeEntry timeEntry)
        {
           
                // var tempTimeEntry = _timeEntry.IndexOf(timeEntry);
                // tempTimeEntry.projectId = timeEntry.projectId;
                // tempTimeEntry.userId = timeEntry.userId;
                // tempTimeEntry.hours = timeEntry.hours;
                // tempTimeEntry.date = timeEntry.date;
                // _timeEntry[v-1] = tempTimeEntry;
                // return _timeEntry[v-1];
                // foreach (var item in _timeEntry)
                // {
                //     if(item.id == tempTimeEntry.id)
                //     {
                //         item.projectId = timeEntry.projectId;
                //         item.userId = timeEntry.userId;
                //         item.hours = timeEntry.hours;
                //         item.date = timeEntry.date;              
                //     }
                // }

                // return 
                // var result = _timeEntry.IndexOf(timeEntry);
                
                // _timeEntry[result]

           _timeEntry1[v] = timeEntry;
           return _timeEntry1[v];
        }

        // private void test(int id)
        // {
        //     (from p in _timeEntry
        //     where p.id == id
        //     select p).u
        // }

        public void Delete(int v)
        {
        //    var timeEntry = Find(v);
        //    _timeEntry.FirstOrDefault(x=>x.id ==v);
        //    _timeEntry.Remove(timeEntry);
        //    count--;
           _timeEntry1.Remove(v);
           //count--;
        }
    }
}
using System;

namespace PalTracker
{
    public struct TimeEntry
    {
        public long ProjectId;
        public long UserId;
        public DateTime Date;
        public int Hours;
        public long? Id;
        
        public TimeEntry(long v1, long v2, DateTime dateTime, int v3)
        {
          ProjectId= v1;
          UserId = v2;
          Hours = v3;
          Id = null;
          Date = dateTime;
        }

        public TimeEntry(long v1, long v2, long v3, DateTime dateTime, int v4)
        {   this.Id = v1;
            this.ProjectId = v2;
            this.Date = dateTime;
            this.UserId = v3;
            this.Hours =v4;
   }
    }
}
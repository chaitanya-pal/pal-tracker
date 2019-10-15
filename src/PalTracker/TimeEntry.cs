using System;

namespace PalTracker
{
    public struct TimeEntry
    {
        public int projectId;
        public int userId;
        public DateTime date;
        public int hours;
        public int id;

        public TimeEntry(int v1, int v2, DateTime dateTime, int v3)
        {
          projectId= v1;
          userId = v2;
          hours = v3;
          id =1;
          date = dateTime;
        }

        public TimeEntry(int v1, int v2, int v3, DateTime dateTime, int v4)
        {   this.id = v1;
            this.projectId = v2;
            this.date = dateTime;
            this.userId = v3;
            this.hours =v4;
   }
    }
}
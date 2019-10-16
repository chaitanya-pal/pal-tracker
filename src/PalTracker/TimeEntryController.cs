using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private ITimeEntryRepository _timeEntryRepository;
        private IOperationCounter<TimeEntry> _operationCounter ;

        public TimeEntryController(ITimeEntryRepository timeEntryRepository, IOperationCounter<TimeEntry> operationCounter )
        {
            this._timeEntryRepository = timeEntryRepository;
            this._operationCounter = operationCounter;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]

        public ActionResult Read(int id)
        {
             _operationCounter.Increment(TrackedOperation.Read);
            if (_timeEntryRepository.Contains(id))
                return new OkObjectResult(_timeEntryRepository.Find(id));
            else
                return new NotFoundResult();
        }

       [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
             _operationCounter.Increment(TrackedOperation.Create);
            var createdTimeEntry = _timeEntryRepository.Create(timeEntry);

            return CreatedAtRoute("GetTimeEntry", new {id = createdTimeEntry.Id}, createdTimeEntry);
        }

        [HttpGet]
        public ActionResult List()
        {
             _operationCounter.Increment(TrackedOperation.List);
            return new OkObjectResult(_timeEntryRepository.List());
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,[FromBody] TimeEntry theUpdate)
        {
             _operationCounter.Increment(TrackedOperation.Update);
            if (_timeEntryRepository.Contains(id))
            {
                var response = _timeEntryRepository.Update(id, theUpdate);
                return new OkObjectResult(response);
            }
            else
                return new NotFoundResult();
        }

        [HttpDelete]
        [Route("{id}")]
        public object Delete(int id)
        {
              _operationCounter.Increment(TrackedOperation.Delete);

            if (_timeEntryRepository.Contains(id))
            {
                _timeEntryRepository.Delete(id);
                return new NoContentResult();
            }
            else
                return new NotFoundResult();
        }
    }
}
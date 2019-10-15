using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(ITimeEntryRepository timeEntryRepository)
        {
            this._timeEntryRepository = timeEntryRepository;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]

        public ActionResult Read(int id)
        {
            if (_timeEntryRepository.Contains(id))
                return new OkObjectResult(_timeEntryRepository.Find(id));
            else
                return new NotFoundResult();
        }

        [HttpPost]
        // [Route("/time-entries")]
        public ActionResult Create([FromBody]TimeEntry toCreate)
        {
            var response = _timeEntryRepository.Create(toCreate);
            return CreatedAtRoute("GetTimeEntry", new { id = toCreate.id }, response);
        }

        [HttpGet]
        public ActionResult List()
        {
            return new OkObjectResult(_timeEntryRepository.List());
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,[FromBody] TimeEntry theUpdate)
        {
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
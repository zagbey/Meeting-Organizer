// Controllers/MeetingController.cs

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MeetingOrganizer.API.Data;
using MeetingOrganizer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingOrganizerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeetingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MeetingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var meetings = _context.Meetings.ToList();
            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var meeting = _context.Meetings.Find(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return Ok(meeting);
        }

        [HttpPost]
        public IActionResult Post(Meeting meeting)
        {
            _context.Meetings.Add(meeting);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return BadRequest();
            }

            _context.Entry(meeting).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var meeting = _context.Meetings.Find(id);
            if (meeting == null)
            {
                return NotFound();
            }

            _context.Meetings.Remove(meeting);
            _context.SaveChanges();
            return Ok();
        }
    }
}

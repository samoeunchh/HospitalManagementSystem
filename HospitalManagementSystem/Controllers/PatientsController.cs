﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
              return View(await _context.Patient.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.PatientId == id);
            ViewData["VitalSigns"] = await (from v in _context.VitalSign
                                            join n in _context.Staff on v.NurseId equals n.StaffId
                                            where v.PatientId.Equals(id)
                                            select new VitalSignViewModel
                                            {
                                                Nurse = n.StaffName,
                                                IssueDate = v.IssueDate,
                                                Heart = v.Heart,
                                                Temp =  v.Temp,
                                                BloodPres = v.BloodPres,
                                                Noted= v.Noted
                                            }).ToListAsync();
            ViewData["CheckUp"]= await (from v in _context.CheckUp
                                        join s in _context.Staff on v.DoctorId equals s.StaffId
                                        where v.PatientId.Equals(id)
                                        select new CheckUpViewModel
                                        {
                                            Doctor=s.StaffName,
                                            IssueDate=v.IssueDate,
                                            PatientId=v.PatientId,
                                            CheckUpId=v.CheckUpId,
                                            Noted=v.Noted
                                        }).ToListAsync();
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> VitalSign(Guid Id)
        {
            var patient = await _context.Patient.FindAsync(Id);
            ViewData["PatientId"] = patient.PatientId;
            ViewData["PatientName"] = patient.PatientName;
            ViewData["Staffs"] = new SelectList(_context.Staff, "StaffId", "StaffName");
            return View();
        }
        public async Task<IActionResult> CheckUp(Guid Id)
        {
            var patient = await _context.Patient.FindAsync(Id);
            ViewData["PatientId"] = patient.PatientId;
            ViewData["PatientName"] = patient.PatientName;
            ViewData["Staffs"] = new SelectList(_context.Staff, "StaffId", "StaffName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckUp(CheckUp checkup)
        {
            if (ModelState.IsValid)
            {
                checkup.CheckUpId = Guid.NewGuid();
                _context.Add(checkup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Patient"] = checkup.PatientId;
            ViewData["Staffs"] = new SelectList(_context.Staff, "StaffId", "StaffName", checkup.DoctorId);
            return View(checkup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VitalSign(VitalSign vital)
        {
            if (ModelState.IsValid)
            {
                vital.VitalSignId = Guid.NewGuid();
                _context.Add(vital);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Patient"] = vital.PatientId;
            ViewData["Staffs"] = new SelectList(_context.Staff, "StaffId", "StaffName",vital.NurseId);
            return View(vital);
        }
        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,PatientName,Gender,DateOfBirth,PhoneNumber,Email,Address")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                patient.PatientId = Guid.NewGuid();
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PatientId,PatientName,Gender,DateOfBirth,PhoneNumber,Email,Address")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Patient == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Patient'  is null.");
            }
            var patient = await _context.Patient.FindAsync(id);
            if (patient != null)
            {
                _context.Patient.Remove(patient);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(Guid id)
        {
          return _context.Patient.Any(e => e.PatientId == id);
        }
    }
}

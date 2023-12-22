using ClinicLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLibrary.DAO
{
    public class DoctorsDao { 
    private static DoctorsDao instance = null;
    private static readonly object instanceLock = new object();
    public static DoctorsDao Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DoctorsDao();
            }
            return instance;
        }
    }

    public IEnumerable<Doctor> GetDoctorList()
    {
        var list = new List<Doctor>();
        try
        {
            using var context = new ClinicBaDangContext();
            list = context.Doctors.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return list;
    }

    public Doctor GetDoctorByID(int id)
    {
        Doctor doctor = null;
        try
        {
            using var context = new ClinicBaDangContext();
            doctor = context.Doctors.SingleOrDefault(d => d.DoctorID == id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return doctor;
    }

    public void AddNew(Doctor doctor)
    {
        try
        {
            using var context = new ClinicBaDangContext();
            context.Doctors.Add(doctor);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Update(Doctor doctor)
    {
        try
        {
            Doctor d = GetDoctorByID(doctor.Id);
            if (d != null)
            {
                using var context = new ClinicBaDangContext();
                context.Doctors.Update(doctor);
                context.SaveChanges();
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public void Delete(Doctor doctor)
    {
        try
        {
            Doctor d = GetDoctorByID(doctor.Id);
            if (d != null)
            {
                using var context = new ClinicBaDangContext();
                context.Doctors.Remove(doctor);
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
}

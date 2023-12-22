using ClinicLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLibrary.Respository
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctorByID(int id);
        void Add(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(Doctor doctor);
    }
}

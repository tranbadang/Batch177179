using ClinicLibrary.DAO;
using ClinicLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicLibrary.Respository
{
    public class DoctorRepository : IDoctorRepository
    {

        public IEnumerable<Doctor> GetDoctors() => DoctorsDao.Instance.GetDoctorList();
        public Doctor GetDoctorByID(int id) => DoctorsDao.Instance.GetDoctorByID(id);
        public void Add(Doctor doctor) => DoctorsDao.Instance.AddNew(doctor);
        public void Update(Doctor doctor) => DoctorsDao.Instance.Update(doctor);
        public void Delete(Doctor doctor) => DoctorsDao.Instance.Delete(doctor);

        public Doctor GetDoctorByID()
        {
            throw new NotImplementedException();
        }
    }
}

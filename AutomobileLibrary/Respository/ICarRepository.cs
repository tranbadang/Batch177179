﻿using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Respository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCardByID(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}

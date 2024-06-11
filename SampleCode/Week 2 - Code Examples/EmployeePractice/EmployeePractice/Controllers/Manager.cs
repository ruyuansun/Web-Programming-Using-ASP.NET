using AutoMapper;
using EmployeePractice.Data;
using EmployeePractice.Models;
using GetAllGetOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-a53f4d58-85e5-42ac-8083-a6198ed4b277
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace EmployeePractice.Controllers
{
   public class Manager
   {
      // Reference to the data context
      private DataContext ds = new DataContext();

      // AutoMapper instance
      public IMapper mapper;

      public Manager()
      {
         // If necessary, add more constructor code here...

         // Configure the AutoMapper components
         var config = new MapperConfiguration(cfg =>
         {
            cfg.CreateMap<Employee, EmployeeBaseViewModel>();
            cfg.CreateMap<EmployeeAddViewModel, Employee>();
            cfg.CreateMap<EmployeeEditViewModel, Employee>();
            cfg.CreateMap<Employee, EmployeeEditViewModel>();

         });

         mapper = config.CreateMapper();

         // Turn off the Entity Framework (EF) proxy creation features
         // We do NOT want the EF to track changes - we'll do that ourselves
         ds.Configuration.ProxyCreationEnabled = false;

         // Also, turn off lazy loading...
         // We want to retain control over fetching related objects
         ds.Configuration.LazyLoadingEnabled = false;
      }


      // Add your methods below and call them from controllers. Ensure that your methods accept
      // and deliver ONLY view model objects and collections. When working with collections, the
      // return type is almost always IEnumerable<T>.
      //
      // Remember to use the suggested naming convention, for example:
      // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

      public IEnumerable<EmployeeBaseViewModel> EmployeeGetAll()
      {
         var employees = ds.Employees.OrderBy(e => e.EmpName);
         return mapper.Map<IEnumerable<EmployeeBaseViewModel>>(employees);
      }

      public EmployeeBaseViewModel EmployeeGetById(int id)
      {
         var employee = ds.Employees.Find(id);
         return (employee == null) ? null : mapper.Map<EmployeeBaseViewModel>(employee);
      }

      public EmployeeBaseViewModel EmployeeAdd(EmployeeAddViewModel newItem)
      {
         var addedItem = mapper.Map<Employee>(newItem);
         var savedItem = ds.Employees.Add(addedItem);
         ds.SaveChanges();
         return mapper.Map<EmployeeBaseViewModel>(savedItem);
      }

      public EmployeeBaseViewModel EmployeeEdit(EmployeeEditViewModel editedItem)
      {
         var existingItem = ds.Employees.Find(editedItem.EmpId);
         if (existingItem == null)
         {
            return null;
         }
         ds.Entry(existingItem).CurrentValues.SetValues(editedItem);
         ds.SaveChanges();
         return mapper.Map<EmployeeBaseViewModel>(existingItem);
      }

      public bool EmployeeDelete(int id)
      {
         var itemToDelete = ds.Employees.Find(id);
         if (itemToDelete == null)
         {
            return false;
         }
         ds.Employees.Remove(itemToDelete);
         ds.SaveChanges();
         return true;
      }

   }
}
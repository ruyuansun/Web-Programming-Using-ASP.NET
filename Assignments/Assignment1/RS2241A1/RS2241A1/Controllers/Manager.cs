using AutoMapper;
using RS2241A1.Data;
using RS2241A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-ff761a8f-d837-4d06-b982-b5aa6c10f636
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace RS2241A1.Controllers
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
            cfg.CreateMap<Concert, ConcertBaseViewModel>();
            cfg.CreateMap<ConcertAddViewModel, Concert>();
            cfg.CreateMap<ConcertEditViewModel, Concert>();
            cfg.CreateMap<Concert, ConcertEditViewModel>();
            cfg.CreateMap<Concert, ConcertEditFormViewModel>();
            cfg.CreateMap<ConcertBaseViewModel, ConcertEditFormViewModel>();
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

      // Get all concerts
      public IEnumerable<ConcertBaseViewModel> ConcertGetAll()
      {
         var concerts = ds.Concerts.OrderBy(c => c.Name);
         return mapper.Map<IEnumerable<ConcertBaseViewModel>>(concerts);
      }

      // Get one concert by id
      public ConcertBaseViewModel ConcertGetById(int id)
      {
         var concert = ds.Concerts.Find(id);
         return (concert == null) ? null : mapper.Map<ConcertBaseViewModel>(concert);
      }

      // Add new concert
      public ConcertBaseViewModel ConcertAdd(ConcertAddViewModel newItem)
      {
         var addedItem = mapper.Map<Concert>(newItem);
         var savedItem = ds.Concerts.Add(addedItem);
         ds.SaveChanges();
         return mapper.Map<ConcertBaseViewModel>(savedItem);
      }

      // Edit existing concert
      public ConcertBaseViewModel ConcertEdit(ConcertEditViewModel editedItem)
      {
         var existingItem = ds.Concerts.Find(editedItem.ConcertId);
         if (existingItem == null)
         {
            return null;
         }
         ds.Entry(existingItem).CurrentValues.SetValues(editedItem);
         ds.SaveChanges();
         return mapper.Map<ConcertBaseViewModel>(existingItem);
      }


      // Delete existing concert
      public bool ConcertDelete(int id)
      {
         var itemToDelete = ds.Concerts.Find(id);
         if (itemToDelete == null)
         {
            return false;
         }
         ds.Concerts.Remove(itemToDelete);
         ds.SaveChanges();
         return true;
      }

   }
}
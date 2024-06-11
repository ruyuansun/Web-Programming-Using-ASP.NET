﻿using AutoMapper;
using EmployeesPractice.Data;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-fd073961-6367-412f-8141-66f07207fe84
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace EmployeesPractice.Controllers
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
            // Define the mappings below, for example...
            // cfg.CreateMap<SourceType, DestinationType>();
            // cfg.CreateMap<Product, ProductBaseViewModel>();

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



   }
}
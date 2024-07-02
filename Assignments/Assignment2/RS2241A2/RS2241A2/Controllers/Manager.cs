using AutoMapper;
using RS2241A2.Data;
using RS2241A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-280a364a-9ced-478d-8d03-bb3bf6d9ec7c
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace RS2241A2.Controllers
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
            cfg.CreateMap<Track, TrackBaseViewModel>()
            .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
            .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

            cfg.CreateMap<Track, TrackWithDetailViewModel>()
            .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
            .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name));

            cfg.CreateMap<Invoice, InvoiceBaseViewModel>();

            cfg.CreateMap<Invoice, InvoiceWithDetailsViewModel>()
            .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
            .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
            .ForMember(dest => dest.CustomerState, opt => opt.MapFrom(src => src.Customer.State))
            .ForMember(dest => dest.CustomerCountry, opt => opt.MapFrom(src => src.Customer.Country))
            .ForMember(dest => dest.CustomerEmployeeFirstName, opt => opt.MapFrom(src => src.Customer.Employee.FirstName))
            .ForMember(dest => dest.CustomerEmployeeLastName, opt => opt.MapFrom(src => src.Customer.Employee.LastName));

            cfg.CreateMap<InvoiceLine, InvoiceLineBaseViewModel>();
            cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>()
            .ForMember(dest => dest.TrackName, opt => opt.MapFrom(src => src.Track.Name))
            .ForMember(dest => dest.TrackComposer, opt => opt.MapFrom(src => src.Track.Composer))
            .ForMember(dest => dest.TrackAlbumTitle, opt => opt.MapFrom(src => src.Track.Album.Title))
            .ForMember(dest => dest.TrackAlbumArtistName, opt => opt.MapFrom(src => src.Track.Album.Artist.Name))
            .ForMember(dest => dest.TrackGenreName, opt => opt.MapFrom(src => src.Track.Genre.Name))
            .ForMember(dest => dest.TrackMediaType, opt => opt.MapFrom(src => src.Track.MediaType.Name));
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


      public IEnumerable<TrackBaseViewModel> TrackGetAll()
      {
         var tracks = ds.Tracks.Include("Album").Include("Genre").OrderBy(t => t.Name);
         return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks);
      }

      public IEnumerable<TrackBaseViewModel> TrackGetBluesJazz()
      {
         var tracks = ds.Tracks.Include("Album").Include("Genre").Where(t => t.GenreId == 2 || t.GenreId == 6).OrderBy(t => t.Genre.Name).ThenBy(t => t.Name);
         return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks);
      }

      public IEnumerable<TrackBaseViewModel> TrackGetCantrellStaley()
      {
         var tracks = ds.Tracks.Include("Album").Include("Genre").Where(t => t.Composer.Contains("Cantrell") || t.Composer.Contains("Staley")).OrderBy(t => t.Name);
         return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks);
      }

      public IEnumerable<TrackBaseViewModel> TrackGetTop50Longest()
      {
         var tracks = ds.Tracks.Include("Album").Include("Genre").OrderByDescending(t => t.Milliseconds).Take(50);
         return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks);
      }

      public IEnumerable<TrackBaseViewModel> TrackGetTop50Smallest()
      {
         var tracks = ds.Tracks.Include("Album").Include("Genre").OrderBy(t => t.Milliseconds).Take(50);
         return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBaseViewModel>>(tracks);
      }


      public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll()
      {
         var invoices = ds.Invoices.OrderByDescending(i => i.InvoiceDate).ThenBy(i => i.CustomerId);
         return mapper.Map<IEnumerable<InvoiceBaseViewModel>>(invoices);
      }

      public InvoiceWithDetailsViewModel InvoiceGetByIdWithDetail(int id)
      {
         var invoice = ds.Invoices.Include("Customer.Employee")
            .Include("InvoiceLines.Track.Album.Artist")
            .Include("InvoiceLines.Track.Genre")
            .Include("InvoiceLines.Track.MediaType")
            .SingleOrDefault(i => i.InvoiceId == id);
         return (invoice == null) ? null : mapper.Map<InvoiceWithDetailsViewModel>(invoice);
      }

   }
}
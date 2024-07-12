using AutoMapper;
using RS2241A3.Data;
using RS2241A3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-6faf15c5-f25e-4292-8c19-5375396b80a7
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace RS2241A3.Controllers
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
                cfg.CreateMap<Album, AlbumBaseViewModel>();
                cfg.CreateMap<MediaType, MediaTypeBaseViewModel>();
                cfg.CreateMap<Artist, ArtistBaseViewModel>();

                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>()
                 .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
                 .ForMember(dest => dest.AlbumArtistName, opt => opt.MapFrom(src => src.Album.Artist.Name))
                 .ForMember(dest => dest.MediaType, opt => opt.MapFrom(src => src.MediaType));
                cfg.CreateMap<TrackAddFormViewModel, Track>();
                cfg.CreateMap<TrackAddViewModel, Track>();
                cfg.CreateMap<Track, TrackAddViewModel>();


                cfg.CreateMap<Playlist, PlaylistBaseViewModel>()
                 .ForMember(dest => dest.TracksCount, opt => opt.MapFrom(src => src.Tracks.Count));
                cfg.CreateMap<Playlist, PlaylistEditTracksFormViewModel>()
                    .ForMember(dest => dest.TrackList, opt => opt.Ignore())
                    .ForMember(dest => dest.TracksCount, opt => opt.MapFrom(src => src.Tracks.Count))
                   .ForMember(dest => dest.Tracks, opt => opt.MapFrom(src => src.Tracks.Select(t => new TrackBaseViewModel
                   {
                       TrackId = t.TrackId,
                       Name = t.Name,
                       Composer = t.Composer,
                       Milliseconds = t.Milliseconds,
                       UnitPrice = t.UnitPrice
                   })));
                cfg.CreateMap<Playlist, PlaylistEditTracksViewModel>();
                cfg.CreateMap<PlaylistEditTracksViewModel, Playlist>();
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

      public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
      {
         var albums = ds.Albums.OrderBy(a => a.Title);
         return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(albums);
      }

      public IEnumerable<ArtistBaseViewModel> ArtistGetAll()
      {
         var artists = ds.Artists.OrderBy(a => a.Name);
         return mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(artists);
      }

      public IEnumerable<MediaTypeBaseViewModel> MediaTypeGetAll()
      {
         var mediaTypes = ds.MediaTypes.OrderBy(m => m.Name);
         return mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBaseViewModel>>(mediaTypes);
      }

      public IEnumerable<TrackWithDetailViewModel> TrackGetAllWithDetail()
      {
         var tracks = ds.Tracks.Include("Album.Artist").Include("MediaType").OrderBy(t => t.Name);
         return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(tracks);
      }
      public TrackWithDetailViewModel TrackGetById(int id)
      {
         var track = ds.Tracks.Include("Album.Artist").Include("MediaType").SingleOrDefault(t => t.TrackId == id);
         return (track == null) ? null : mapper.Map<Track, TrackWithDetailViewModel>(track);
      }

      public TrackAddFormViewModel TrackAddGet()
      {
         var form = new TrackAddFormViewModel();

         var albums = ds.Albums.OrderBy(a => a.Title).ToList();
         var mediaTypes = ds.MediaTypes.OrderBy(m => m.Name).ToList();

         form.AlbumList = new SelectList(albums, "AlbumId", "Title", albums.First().AlbumId);
         form.MediaTypeList = new SelectList(mediaTypes, "MediaTypeId", "Name", mediaTypes.First().MediaTypeId);

         return form;
      }

      public TrackAddViewModel TrackAdd(TrackAddViewModel newItem)
      {
         var album = ds.Albums.Find(newItem.AlbumId);
         var mediaType = ds.MediaTypes.Find(newItem.MediaTypeId);

         if (album == null || mediaType == null)
         {
            return null;
         }

         var addedItem = ds.Tracks.Add(mapper.Map<TrackAddViewModel, Track>(newItem));
         addedItem.Album = album;
         addedItem.MediaType = mediaType;

         ds.SaveChanges();

         return (addedItem == null) ? null : mapper.Map<Track, TrackAddViewModel>(addedItem);
      }

      public IEnumerable<PlaylistBaseViewModel> PlaylistGetAll()
      {
         var playlists = ds.Playlists.Include("Tracks").OrderBy(p => p.Name);
         return mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBaseViewModel>>(playlists);
      }

      public PlaylistEditTracksFormViewModel PlaylistGetById(int id)
      {
         var playlist = ds.Playlists.Include("Tracks").SingleOrDefault(p => p.PlaylistId == id);

         if (playlist == null)
         {
            return null;
         }

         var result = mapper.Map<PlaylistEditTracksFormViewModel>(playlist);
         result.TrackList = new MultiSelectList(ds.Tracks.OrderBy(t => t.Name), "TrackId", "Name", playlist.Tracks.Select(t => t.TrackId));
         result.SelectedTracks = playlist.Tracks.Select(t => t.TrackId);
         return result;
      }

      public void PlaylistEditTracks(PlaylistEditTracksViewModel model)
      {
         var playlist = ds.Playlists.Include("Tracks").SingleOrDefault(p => p.PlaylistId == model.PlaylistId);

         if (playlist != null)
         {
            playlist.Tracks.Clear();

            foreach (var trackId in model.SelectedTracks)
            {
               var track = ds.Tracks.Find(trackId);
               if (track != null)
               {
                  playlist.Tracks.Add(track);
               }
            }

            ds.SaveChanges();
         }
      }

   }
}
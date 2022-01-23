using ApplicationService.DTOs;
using ApplicationService.Implementation;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        //AuthorManagement

        private AuthorManagementService authorService = new AuthorManagementService();

        public List<AuthorDTO> GetAuthors()
        {
            return authorService.Get();
        }
        public AuthorDTO GetAuthorByID(int id)
        {
            return authorService.GetById(id);
        }

        public string PostAuthor(AuthorDTO authorDTO)
        {
            if (!authorService.Save(authorDTO))
            {
                return "Author is not saved!";
            }
            else
            {
                return "Author is saved!";
            }
        }

        public string DeleteAuthor(int id)
        {
            if (!authorService.Delete(id))
            {
                return "Author is not deleted!";
            }
            else
            {
                return "Author is deleted!";
            }
        }
        //AuthorManagement - End

        //SongManagement

        private SongManagementService songService = new SongManagementService();

        public List<SongDTO> GetSongs()
        {
            return songService.Get();
        }

        public SongDTO GetSongByID(int id)
        {
            return songService.GetById(id);
        }

        public string PostSongs(SongDTO songDTO)
        {
            if (!songService.Save(songDTO))
            {
                return "Song is not saved!";
            }
            else
            {
                return "Song is saved!";
            }
        }

        public string DeleteSong(int id)
        {
            if (!songService.Delete(id))
            {
                return "Song is not deleted!";
            }
            else
            {
                return "Song is deleted!";
            }
        }
        //SongManagement - End

        //AlbumManagement 
        private AlbumManagementService albumService = new AlbumManagementService();

        public List<AlbumDTO> GetAlbums()
        {
            return albumService.Get();
        }

        public AlbumDTO GetAlbumByID(int id)
        {
            return albumService.GetById(id);
        }

        public string PostAlbums(AlbumDTO albumDTO)
        {
            if (!albumService.Save(albumDTO))
            {
                return "Album is not saved!";
            }
            else
            {
                return "Album is saved!";
            }
        }

        public string DeleteAlbum(int id)
        {
            if (!albumService.Delete(id))
            {
                return "Album is not deleted!";
            }
            else
            {
                return "Album is deleted!";
            }
        }
        //AlbumManagement - End
    }
}

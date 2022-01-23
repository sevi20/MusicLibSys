using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        //AuthorManagement 
        [OperationContract]
        List<AuthorDTO> GetAuthors();

        [OperationContract]
        string PostAuthor(AuthorDTO authorDTO);

        [OperationContract]
        AuthorDTO GetAuthorByID(int id);

        [OperationContract]
        string DeleteAuthor(int id);
        //AuthorManagment - End

        //SongManagement
        [OperationContract]
        List<SongDTO> GetSongs();

        [OperationContract]
        string PostSongs(SongDTO songDTO);

        [OperationContract]
        SongDTO GetSongByID(int id);

        [OperationContract]
        string DeleteSong(int id);
        //SongManagement - End

        //AlbumManagement 
        [OperationContract]
        List<AlbumDTO> GetAlbums();

        [OperationContract]
        string PostAlbums(AlbumDTO albumDTO);

        [OperationContract]
        AlbumDTO GetAlbumByID(int id);

        [OperationContract]
        string DeleteAlbum(int id);
        //AlbumManagement - End
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

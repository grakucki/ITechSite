using ITechInstrukcjeModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ITechService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceWorkstation
    {
        /// <summary>
        /// Ping to serwisu w celu ustalenia czy jesteśmy online
        /// </summary>
        /// <returns>Data i czas serwera</returns>
        [OperationContract]
        [WebGet(UriTemplate = "Ping")]
        DateTime Ping();


        /// <summary>
        /// Test połaczenia
        /// </summary>
        /// <param name="value">Identyfikator zasobu dla którego zostanie zwrócony News w odpowiedzi</param>
        /// <returns>Tekst z komunikatami o powodzeniu lub problemach połączenia</returns>
        [OperationContract]
        string TestConnection(int value);

        /// <summary>
        /// Zwraca News dla zadanej Workstation według IDR
        /// </summary>
        /// <param name="idR">Identyfikator Resources</param>
        /// <returns>Wiadomość do wyświelenia na stacji roboczej</returns>
        [OperationContract]
        News GetNews(int idR);

        /// <summary>
        /// Lista obsługiwanych modeli sterowników
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<String> GetSimaticCpuType();

        /// <summary>
        /// Lista dostępnych stanowisk roboczych
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Resource> GetWorkstationList();


        /// <summary>
        /// Plan ifnoramcyjny dla stanowiska roboczego
        /// </summary>
        /// <param name="idR">Identyfikator zasobu dla którego ma zostać wygenerowana lista</param>
        /// <returns></returns>
        [OperationContract]
        Resource GetInformationPlain(int idR);

        /// <summary>
        /// Plan ifnoramcyjny dla stanowiska roboczego0 idR oraz jego modeli Modeli
        /// </summary>
        /// <param name="idR">Identyfikator zasobu dla którego ma zostać wygenerowana lista</param>
        /// <returns></returns>
        [OperationContract]
        List<Resource> GetInformationPlainsList(int idR);

        /// <summary>
        /// Lista plików dla wzkazanego workstation oraz produkowanych dla niego modeli
        /// </summary>
        /// <param name="idR">Identyfikator zasobu dla którego ma zostać wygenerowana lista</param>
        /// <returns></returns>
        [OperationContract]
        List<DokumentIdentity> GetDokumentsList(int idR);


        /// lista użytkowników i ich prawa dostępu
        [OperationContract]
        List<ItechUsers> GetITechUserList();

        /// <summary>
        /// Update ustawień stacji roboczej
        /// </summary>
        /// <param name="idR">stacja robocza</param>
        /// <returns></returns>
        [OperationContract]
        void UpdateWorkstation(Workstation idR);


        /// <summary>
        /// zwara listę na podtrzeby wyświelaenia jakie modele są produkowane na stacji roboczej
        /// </summary>
        /// <param name="idR"></param>
        [OperationContract]
        List<ModelWorkstationInfo> GetModelWorkstationInfo(int idR);


        /// <summary>
        ///  lista dostępnych modeli 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Resource> GetModels();

        /// <summary>
        /// aktualizacja tabeli ModelWorkstation
        /// </summary>
        /// <param name="modelWorkstationInfo"></param>
        [OperationContract]
        void UpdateModelWorkstationInfo(ModelWorkstationInfo modelWorkstationInfo, bool Remove = false);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class DokumentIdentity
    {
        /// <summary>
        /// identyfikator dokumentu
        /// </summary>
        [DataMember]
        public int id { get; set; }

        /// <summary>
        /// Lokalna nazwa dokumentu - pod jaką nazwą należy zapisać plik
        /// </summary>
        [DataMember]
        public string LocalFileName { get; set; }

        /// <summary>
        /// Codowa nazwa dokumentu
        /// </summary>
        [DataMember]
        public string CodeName { get; set; }

        /// <summary>
        /// Wielkość pliku
        /// </summary>
        [DataMember]
        public long Size { get; set; }

        /// <summary>
        /// Ostatnia modyfikacja dokumentu
        /// </summary>
        [DataMember]
        public DateTime LastWriteTime { get; set; }
    }

    [DataContract]
    public class ModelWorkstationInfo
    {

        /// <summary>
        /// identyfikator rekordu w tabeli [ModelsWorkstation]
        /// </summary>
        [DataMember]
        public int id { get; set; }

        /// <summary>
        /// identyfikator resources
        /// </summary>
        [DataMember]
        public int? idW { get; set; }

        /// <summary>
        /// identyfikator modelu
        /// </summary>
        [DataMember]
        public int? idM { get; set; }

        /// <summary>
        /// Nazwa stanowiska roboczego
        /// </summary>
        [DataMember]
        public string WorkstationName { get; set; }

        /// <summary>
        /// Nazwa Modelu
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        /// <summary>
        /// indeks Modelu na sterowniku
        /// </summary>
        [DataMember]
        public string SterownikIndex { get; set; }
    }


    
}

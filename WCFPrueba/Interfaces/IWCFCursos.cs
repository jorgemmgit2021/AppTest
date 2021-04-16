using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFPrueba
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWCFCursos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWCFCursos
    {
        [OperationContract]
        ListCurso[] getList();
        [OperationContract]
        Curso getId(int id);
        [OperationContract]
        int Set(Curso Curso);
        [OperationContract]
        int Delete(int id);
        [OperationContract]
        Catalogo[] getAllModalidades();
        [OperationContract]
        Catalogo[] getAllPaises();
        [OperationContract]
        Catalogo[] getAllCiudades(int id);
    }
    [DataContract]
    public class Curso
    {
        [DataMember]
        public int Id_Curso { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember] 
        public int Id_Modalidad { get; set; }
        [DataMember] 
        public decimal Costo { get; set; }
        [DataMember] 
        public int Id_Pais { get; set; }
        [DataMember] 
        public int Id_Ciudad { get; set; }
        [DataMember] 
        public string Direccion { get; set; }
}
    [DataContract]
    public class ListCurso{
        [DataMember]
        public int Id_Curso { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Modalidad { get; set; }
        [DataMember]
        public decimal Costo { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string Direccion { get; set; }
    }

    [DataContract]
    public class Catalogo {
        [DataMember]
        public int Id_Elemento { get; set; }
        [DataMember] 
        public int Id_Grupo { get; set; }
        [DataMember] 
        public string Descripcion { get; set; }
    }
}

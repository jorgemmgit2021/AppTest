using DataEntity.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Westwind.Utilities;

namespace WCFPrueba
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCFCursos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Curso de prueba WCF para probar este servicio, seleccione WCFCursos.svc o WCFCursos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFCursos : IWCFCursos
    {
        public int Delete(int id){
            var a = new PRUEBA();
            a.Cursos.Remove(a.Cursos.FirstOrDefault(j => j.Id_Curso == id));
            return a.SaveChanges();
        }

        public Curso getId(int id){
            var a = new PRUEBA();
            var q = id != 0 ? a.Cursos.Where(l => l.Id_Curso == id).FirstOrDefault() : new DataEntity.Data.Cursos();
            Curso c = new Curso();
            DataUtils.CopyObjectData(q, c, "Catalogos,Catalogos1,Catalogos2");
            if (a.Entry(q).State == System.Data.Entity.EntityState.Unchanged){
                //c.Catalogos = new dynamic[3];
                //c.Catalogos.SetValue(q.Catalogos, 0); c.Catalogos.SetValue(q.Catalogos, 1); c.Catalogos.SetValue(q.Catalogos, 2);
            }
            return c;
        }
        public ListCurso[] getList(){
            var a = new PRUEBA();
            var c = new Curso();
            var q = a.Cursos.Select(n => new {
                Id_Curso = n.Id_Curso,
                Descripcion = n.Descripcion,
                Modalidad = n.Catalogos.Descripcion,
                Costo = n.Costo,
                Pais = n.Catalogos1.Descripcion,
                Ciudad = n.Catalogos2.Descripcion,
                Direccion = n.Direccion
            }).ToList().ConvertAll<ListCurso>((n)=> {
                var o = new ListCurso(); // { Id_Curso = 0,Descripcion = "",Modalidad = "",Costo = 0, Pais = "",Ciudad = "",Direccion = "" };
                DataUtils.CopyObjectData(n, o, "Catalogos,Catalogos1,Catalogos2");
                //o.Catalogos = new dynamic[3];
                //o.Catalogos.SetValue(n.Catalogos, 0); o.Catalogos.SetValue(n.Catalogos1, 1); o.Catalogos.SetValue(n.Catalogos2, 2);
                return o;
            });
            return q.ToArray();
        }
        
        public int Set(Curso Curso){
            var a = new DataEntity.Data.PRUEBA();
            var q = getId(Curso.Id_Curso);
            if (q.Id_Curso == 0){
                var n = new Cursos();
                DataUtils.CopyObjectData(Curso, n, "Id_Curso,Catalogos");
                a.Cursos.Add(n);
            }
            else{
                var f = a.Cursos.FirstOrDefault(c => c.Id_Curso == Curso.Id_Curso);
                DataUtils.CopyObjectData(Curso, f, "Id_Curso,Catalogos");
            }
            return a.SaveChanges();
        }

        public Catalogo[] getAllModalidades(){
            var a = new DataEntity.Data.PRUEBA();
            var settingModalidad = Convert.ToInt32(ConfigurationManager.AppSettings["IdGrupoModalidades"]);
            var c = a.Catalogos.Where(l => l.Id_Grupo == settingModalidad).ToList().ConvertAll<Catalogo>((g)=> {
                var o = new Catalogo();
                DataUtils.CopyObjectData(g, o);
                return o;
            }).ToArray();
            return c;
        }

        public Catalogo[] getAllPaises(){
            var a = new DataEntity.Data.PRUEBA();
            var settingPaises = Convert.ToInt32(ConfigurationManager.AppSettings["IdGrupoPaises"]);
            var c = a.Catalogos.Where(l => l.Id_Grupo == settingPaises).ToList().ConvertAll<Catalogo>((g) => {
                var o = new Catalogo();
                DataUtils.CopyObjectData(g, o);
                return o;
            }).ToArray();
            return c;
        }

        public Catalogo[] getAllCiudades(int id){
            var a = new DataEntity.Data.PRUEBA();
            var c = a.Catalogos.Where(l => l.Id_Grupo == id).ToList().ConvertAll<Catalogo>((g) => {
                var o = new Catalogo();
                DataUtils.CopyObjectData(g, o);
                return o;
            }).ToArray();
            return c;
        }
    }
}

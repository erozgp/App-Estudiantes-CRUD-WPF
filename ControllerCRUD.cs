using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Estudiantes_CRUD_WPF
{
    internal class ControllerCRUD
    {

        public List<Estudiante> Estudiantes = new List<Estudiante>();

        public ControllerCRUD() { }

        public List<Estudiante> GetEstudiantes() { return Estudiantes; }

        public void AddEstudiante(Estudiante estudiante) { Estudiantes.Add(estudiante); }

        public void RemoveEstudiante(int indexEstudiante) { Estudiantes.Remove(Estudiantes[indexEstudiante]); }

        public void UpdateEstudiante(int indexEstudiante, Estudiante updatedDataEstudiante) { Estudiantes[indexEstudiante] = updatedDataEstudiante; }
    }
}

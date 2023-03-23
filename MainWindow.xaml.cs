using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App_Estudiantes_CRUD_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ControllerCRUD controllerCRUD = new ControllerCRUD();
        //Creaci�n e inicializaci�n de la variable que almacena el �ndice para el Estudiante seleccionado.
        int indexFilaSelect = -1;
        int indexFilaEliminate = -1;

        public MainWindow()
        {
            InitializeComponent();
            //Estudiante de prueba.
            controllerCRUD.AddEstudiante(new Estudiante("Erick", 23, "erozgp@gmail.com"));
            updateFormComponents();
        }

        private void updateFormComponents()
        {
            //Actualizo el DataGridView y valores.
            TxtBxNombre.Text = null;
            TxtBxEdad.Text = null;
            TxtBxEmail.Text = null;
            indexFilaSelect = -1;
            indexFilaEliminate = -1;
            dgEstudiantes.ItemsSource = null;
            dgEstudiantes.ItemsSource = controllerCRUD.GetEstudiantes();
        }

        private void dgEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Se verifica que se haya seleccionado cualquier celda de la fila con doble click para guardar el �ndice de toda la fila y obtener los datos para cargarlos en los cuadros de texto.
            indexFilaSelect = dgEstudiantes.SelectedIndex;
            indexFilaEliminate = dgEstudiantes.SelectedIndex;
            if (indexFilaSelect > -1) 
            {
                Estudiante dataEstudiante = (Estudiante)dgEstudiantes.SelectedItem;
                //Estudiante dataEstudiante = getRowData(indexFilaSelect);                       
                if(dataEstudiante != null)
                {
                    TxtBxNombre.Text = dataEstudiante.Nombre;
                    TxtBxEdad.Text = Convert.ToString(dataEstudiante.Edad);
                    TxtBxEmail.Text = dataEstudiante.Email;
                }
                else
                {
                    updateFormComponents();
                }
                
            }
            else
            {
                updateFormComponents();
            }
            
            
            
        }

        private Estudiante getTxtBxData()
        {
            //Obtengo los datos actualizados o nuevos de los cuadros de texto.
            return new Estudiante(
                TxtBxNombre.Text,
                Int32.Parse(TxtBxEdad.Text),
                TxtBxEmail.Text);
        }

        /*private Estudiante getRowData(int index)
        {
            //Obtengo los datos del elemento seleccionado y se devuelve el Estudiante.
            DataGrid fila = dgEstudiantes.DataContext[inde] .Rows[index];
            return new Estudiante(
                fila.Cells["Nombre"].Value.ToString(),
                Int32.Parse(fila.Cells["Edad"].Value.ToString()),
                fila.Cells["Email"].Value.ToString());

        }*/

        private Boolean isFieldNotNullValidator()
        {
            //Se valida el contenido en las cajas de texto.
            if (!string.IsNullOrEmpty(TxtBxNombre.Text) && !string.IsNullOrEmpty(TxtBxEdad.Text) && !string.IsNullOrEmpty(TxtBxEmail.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (indexFilaSelect > -1 && isFieldNotNullValidator())
            {
                //Actualizar elemento seleccionado.
                Estudiante updatedDataEstudiante = getTxtBxData();
                controllerCRUD.UpdateEstudiante(indexFilaSelect, updatedDataEstudiante);
                updateFormComponents();
            }
            else if (isFieldNotNullValidator())
            {
                //Crea un nuevo estudiante.
                controllerCRUD.AddEstudiante(getTxtBxData());
                updateFormComponents();
            }
            else
            {
                MessageBox.Show("Completa todos los campos. :)");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (indexFilaEliminate > -1)
            {
                controllerCRUD.RemoveEstudiante(indexFilaEliminate);

                updateFormComponents();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento para eliminar. :)");
            }
        }
    }
}

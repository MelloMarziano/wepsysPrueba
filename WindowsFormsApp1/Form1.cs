using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<stp_findAll_Result> getAllPerson()
        {
            using(DBMATRICULASEntities db = new DBMATRICULASEntities())
            {
                List < stp_findAll_Result > result = db.stp_findAll().ToList();
                return result;
            }
           
        }

        public List<stp_findByMatricula_Result> getPerson(string matricula)
        {
            using (DBMATRICULASEntities db = new DBMATRICULASEntities())
            {
                List<stp_findByMatricula_Result> result = db.stp_findByMatricula(matricula).ToList();
                return result;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != "" && txtApellido.Text != "" && txtMatricula.Text != "" && dtpFechaNacimiento.Text != "")
            {
                Decimal.TryParse(txtLactitud.Text, out decimal uLactitud);
                Decimal.TryParse(txtLongitud.Text, out decimal uLongitud);
                Decimal.TryParse(txtAltitud.Text, out decimal uAltitud);
                registerData(txtNombre.Text, 
                    txtApellido.Text,
                    dtpFechaNacimiento.Value, 
                    txtMatricula.Text,
                    uLactitud,
                    uLongitud,
                    uAltitud
                    );
                limpiarCampos();
                dataGridView1.DataSource = getAllPerson();
            }
            
        }
        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtMatricula.Clear();
            txtLongitud.Clear();
            txtAltitud.Clear();
            txtLactitud.Clear();
            dtpFechaNacimiento.ResetText();
        }

        public void registerData(string nombres,string apellidos, DateTime fechaNacimiento, string matricula, decimal ubicacionLatitud, decimal ubicacionLongitud, decimal ubicacionAltitud)
        {
            using (DBMATRICULASEntities db = new DBMATRICULASEntities())
            {
                db.stp_insert(nombres, apellidos, matricula, fechaNacimiento, ubicacionLatitud, ubicacionLongitud, ubicacionAltitud);
            }
           
        }

        private void btnBuscarMatricula_Click(object sender, EventArgs e)
        {
            var result = Interaction.InputBox( "Buscar por matricula", "");
            if(result != null )
            {
                dataGridView1.DataSource = getPerson(result);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getAllPerson();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<propietario> propietarios = new List<propietario>();
        List<propiedad> propiedades = new List<propiedad>();
        List<reporte> reportes = new List<reporte>();


        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //se lee el archivo de propietarios
            FileStream stream = new FileStream("propietarios.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                propietario p = new propietario();

                p.Dpi1 = reader.ReadLine();
                p.Nombre= reader.ReadLine();
                p.Apellido= reader.ReadLine();

                propietarios.Add(p);
            }

            reader.Close();

            //se lee el archivo de propiedades
            FileStream stream2 = new FileStream("propiedades.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);

            while (reader2.Peek() > -1)
            {
                propiedad propiedad = new propiedad();

                propiedad.NumCasa= reader2.ReadLine();
                propiedad.Dpi1 = reader2.ReadLine();
                propiedad.CuotaMantenimiento = float.Parse(reader2.ReadLine());

                propiedades.Add(propiedad);
            }

            reader2.Close();


            for(int x=0; x < propietarios.Count; x++)
            {
                for(int y=0; y < propiedades.Count; y++)
                {
                    if(propietarios[x].Dpi1== propiedades[y].Dpi1)
                    {
                        reporte reporte = new reporte();

                        reporte.Nombre = propietarios[x].Nombre;
                        reporte.Apellido = propietarios[x].Apellido;
                        reporte.NumCasa = propiedades[y].NumCasa;
                        reporte.CuotaMantenimeinto = propiedades[y].CuotaMantenimiento;

                        reportes.Add(reporte);
                    }
                }
            }


            Mostrar();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            reportes = reportes.OrderBy(r => r.CuotaMantenimeinto).ToList();
            Mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            label2.Text = "";
            //lista donde se vana  guardar el número de propiedades de cada propietario
            List<int> numCasas = new List<int>();


            //se recorren las dos listas dinámicas y se comparan los dpi's
            for(int x=0; x < propietarios.Count; x++)
            {
                //se crea un contador que inicializa en 0 (para indicar el número de propiedades)
                int cont =0;
                for (int y=0; y < propiedades.Count; y++)
                {
                    //si el Dpi es el mismo en ambas listas, el contador aumenta 
                    if( propietarios[x].Dpi1== propiedades[y].Dpi1)
                    {
                        cont++;
                        
                    }
                }
                //se agrega el contador a la lista
                numCasas.Add(cont);
            }


            //se busca el número máximo en la lista de contador de Casas
            
            int ind = numCasas.IndexOf(numCasas.Max()); 

           
            label1.Text = "Propietario con más propiedades:\n" + propietarios[ind].Nombre + " " + propietarios[ind].Apellido;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            reportes = reportes.OrderBy(r => r.CuotaMantenimeinto).ToList();
            string nombreCompleto="";
            string nombreCompleto2="";

            for(int x=0; x < 3; x++)
            {
                nombreCompleto += reportes[x].Nombre + " " + reportes[x].Apellido + "\n";
            }


            reportes = reportes.OrderByDescending(r => r.CuotaMantenimeinto).ToList();

            for (int x = 0; x < 3; x++)
            {
                nombreCompleto2 += reportes[x].Nombre + " " + reportes[x].Apellido + "\n";
            }


            label1.Text = "Cuotas más bajas:\n" + nombreCompleto;
            label2.Text = "Cuotas más altas:\n" + nombreCompleto2;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            List<float> cuotas = new List<float>(); 

            //se recorren las dos listas dinámicas y se comparan los dpi's
            for (int x = 0; x < propietarios.Count; x++)
            {
                //se crea un contador que inicializa en 0 
                float cuota = 0;
                for (int y = 0; y < propiedades.Count; y++)
                {
                    //si el Dpi es el mismo en ambas listas, la cuota aumenta 
                    if (propietarios[x].Dpi1 == propiedades[y].Dpi1)
                    {
                        cuota += propiedades[y].CuotaMantenimiento;

                    }
                }
                //se agrega la cuota a la lista
                cuotas.Add(cuota);
            }

            int ind = cuotas.IndexOf(cuotas.Max());
            label1.Text = "Cuota total mas alta:\n" + cuotas[ind] + "\n" +
                "Nombre del propietario:\n" + propietarios[ind].Nombre + " " + propietarios[ind].Apellido;
                
        }
    }
}

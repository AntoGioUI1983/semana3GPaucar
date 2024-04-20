namespace semana3GPaucar.Vistas;
public partial class vPagina : ContentPage
{
    double promedioSemestre = 0;
    double promedio1 = 0;
    double promedio2 = 0;


    public vPagina(string usuario)
    {
        InitializeComponent();
        DisplayAlert("Bienvenido", usuario, "Cerrar");
        lblUsuario.Text = "Usuario conectado: " + usuario;
    }

    private void btnInicio_Clicked(object sender, EventArgs e)
    {
        double seguimiento1 = Convert.ToDouble(txtSeguimiento1.Text);
        double examen1 = Convert.ToDouble(txtExamen1.Text);
        promedio1 = (seguimiento1 * 0.3) + (examen1 * 0.2);

        if (seguimiento1 >= 0.01 && examen1 <= 10.00)
        {
            lblPromedio1.Text = "Promedio Parcial 1: " + promedio1.ToString();
            DisplayAlert("Seguimiento 1", "Promedio: " + promedio1.ToString(), "cerrar");
        }
        else
        {
            DisplayAlert("Alerta", "Las notas deben ser entre 0 y 10", "cerrar");
            txtSeguimiento1.Text = "";
            txtExamen1.Text = "";
            lblPromedio1.Text = "";
        }


        promedioSemestre = promedio1 + promedio2;
    }

    private void btnInicio2_Clicked(object sender, EventArgs e)
    {
        double seguimiento2 = Convert.ToDouble(txtSeguimiento2.Text);
        double examen2 = Convert.ToDouble(txtExamen2.Text);
        promedio2 = ((seguimiento2 * 0.3) + (examen2 * 0.2));

        if (seguimiento2 >= 0.01 && examen2 <= 10.00)
        {
            lblPromedio2.Text = "Promedio Parcial 2: " + promedio2.ToString();
           DisplayAlert("Seguimiento 2", "Promedio : " + promedio2, "cerrar");
        }
        else
        {
            DisplayAlert("Alerta", "Las notas deben ser entre 0 y 10", "cerrar");
            txtSeguimiento2.Text = "";
            txtExamen2.Text = "";
            lblPromedio2.Text = "";
        }


        promedioSemestre = promedio1 + promedio2;
        lblPromedioSemestre.Text = "Promedio Semestre: " + promedioSemestre.ToString();
        MostrarEstado(promedioSemestre);
    }

    private string MostrarEstado(double notaFinal)
    {
        string estado = "";
        if (notaFinal >= 7)
        {
            estado = "Aprobado";
        }
        else if (notaFinal >= 5 && notaFinal <= 6.9)
        {
            estado = "Complementario";
        }
        else
        {
            estado = "Reprobado";
        }
        lblEstadoSemestre.Text = "Estado: " + estado;
        return estado;
    }

    private void btnInforme_Clicked(object sender, EventArgs e)
    {
        DateTime selectedDate = datePicker.Date;

        var selectedName = pkseleccion.Items[pkseleccion.SelectedIndex];
        var estado = MostrarEstado(promedioSemestre);

        DisplayAlert("Informe:",
                     "Estudiante: " + selectedName + "\nFecha: " + selectedDate.ToString("dd/MM/yyyy") + "\nParcial 1: " + promedio1 + "\nParcial 2: " + promedio2 + "\nPromedio Final: " + promedioSemestre + "\nEstado: " + estado,
                     "Cerrar");
    }

    private void btnNuevo_Clicked(object sender, EventArgs e)
    {
        txtSeguimiento1.Text = "";
        txtExamen1.Text = "";
        lblPromedio1.Text = "";
        txtSeguimiento2.Text = "";
        txtExamen2.Text = "";
        lblPromedio2.Text = "";
        lblPromedioSemestre.Text = "";
        lblEstadoSemestre.Text = "";
        promedio1 = 0;
        promedio2 = 0;
        promedioSemestre = 0;
        pkseleccion.SelectedIndex = -1;
    }
}




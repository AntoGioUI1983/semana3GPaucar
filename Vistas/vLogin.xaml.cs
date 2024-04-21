

namespace semana3GPaucar.Vistas
{
    public partial class vLogin : ContentPage
    {
        string[] usuarios = { "Carlos", "Ana", "Jose","a","AGiovanny"};
        string[] contrasenas = { "carlos123", "ana123", "jose123","a","gp123" };

        public vLogin()
        {
            InitializeComponent();
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            string usuarioInput = txtUsuario.Text;
            string contrasenaInput = txtContrasena.Text;
            // Verificar si el usuario y la contraseña están en los vectores
            bool credencialesValidas = false;
            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i] == usuarioInput && contrasenas[i] == contrasenaInput)
                {
                    credencialesValidas = true;
                    break;
                }
            }

            if (credencialesValidas)
            {
                Navigation.PushAsync(new vPagina(usuarioInput));
            }
            else
            {
                DisplayAlert("Alerta", "Usuario o contraseña incorrectos", "Cerrar");
                txtUsuario.Text = "";
                txtContrasena.Text = "";
            }
        }
    }
}

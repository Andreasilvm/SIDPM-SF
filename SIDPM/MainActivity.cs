using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace SIDPM
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText txtUsuario;
        EditText txtContraseña;
        Button btnBuscar;
        Button btnRegistrar;
        Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //txtUsuario = FindViewById<EditText>(Resource.Id.txtUsuario);
            //txtContraseña = FindViewById<EditText>(Resource.Id.txtContraseña);
 //btnBuscar = FindViewById<Button>(Resource.Id.txtContraseña);
            //btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrarse);

            //btnBuscar.Click += btnBuscar_Click;
            //btnRegistrar.Click += BtnRegistrar_Click;

            //Toolbar

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbarMenuMain);

            SetActionBar(toolbar);
            ActionBar.Title = "Menu";

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.icRegistrar:
                    Toast.MakeText(this,"Agregar!",ToastLength.Short).Show();
                    SetContentView(Resource.Layout.Registrar);
                    break;
                case Resource.Id.icActualizarADmon:
                    Toast.MakeText(this, "Actualizar!", ToastLength.Short).Show();
                    SetContentView(Resource.Layout.actualizarAdmon);
                    break;
                case Resource.Id.icEliminarAdmon:
                    Toast.MakeText(this, "Eliminar!", ToastLength.Short).Show();
                    SetContentView(Resource.Layout.eliminarAdmon);
                    break;
                case Resource.Id.icPeticiones:
                    Toast.MakeText(this, "Peticiones!", ToastLength.Short).Show();
                    SetContentView(Resource.Layout.peticiones);
                    break;
                case Resource.Id.icReporteAdmon:
                    Toast.MakeText(this, "Reportes!", ToastLength.Short).Show();
                    SetContentView(Resource.Layout.reporteAdmon);
                    break;
                case Resource.Id.icCerrarSesion:
                    Toast.MakeText(this, "Login!", ToastLength.Short).Show();
                    SetContentView(Resource.Layout.activity_main);
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void BtnRegistrar_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(RegistrarActivity));
            StartActivity(i);
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Login resultado = null;
                if (!string.IsNullOrEmpty(txtUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtContraseña.Text.Trim()))
                {
                    resultado = new Auxiliar().SelecionarUno(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
                    if (resultado != null)
                    {
                        txtUsuario.Text = resultado.Usuario.ToString();
                        Toast.MakeText(this, "Login realizado con exito", ToastLength.Short).Show();
                        var bienvenido = new Intent(this, typeof(MainActivity));// modificar despues
                        bienvenido.PutExtra("usuario", FindViewById<EditText>(Resource.Id.txtUsuario).Text);
                        StartActivity(bienvenido);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Nombre de usuario y/o clave inválida(s)", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Nombre de usuario y/o clave son vacios", ToastLength.Long).Show();
                }

            }
            catch { }
        }


    }
}

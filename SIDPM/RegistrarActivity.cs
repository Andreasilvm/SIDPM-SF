using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIDPM
{
    [Activity(Label = "RegistrarActivity")]
    public class RegistrarActivity : Activity
    {
        // se crean los objetos 
        EditText txtNuevoUsuario;
        EditText txtcedula;
        EditText txtPrimerNombre;
        EditText txtSegundoNombre;
        EditText txtPrimerApellido;
        EditText txtSegundoApellido;
        EditText txtPrograma;
        EditText txtNuevaContraseña;
        Button BtnRegistrarUsuario;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            txtNuevoUsuario = FindViewById<EditText>(Resource.Id.txtNuevoUsuario);
            txtcedula = FindViewById<EditText>(Resource.Id.txtcedula);
            txtPrimerNombre = FindViewById<EditText>(Resource.Id.txtPrimerNombre);
            txtSegundoNombre = FindViewById<EditText>(Resource.Id.txtSegundoNombre);
            txtPrimerApellido = FindViewById<EditText>(Resource.Id.txtPrimerApellido);
            txtSegundoApellido = FindViewById<EditText>(Resource.Id.txtSegundoApellido);
            txtPrograma = FindViewById<EditText>(Resource.Id.txtPrograma);
            txtNuevaContraseña = FindViewById<EditText>(Resource.Id.txtNuevaContraseña);
            BtnRegistrarUsuario = FindViewById<Button>(Resource.Id.BtnRegistrarUsuario);

            BtnRegistrarUsuario.Click += BtnRegistrarUsuario_Click;
        }

        private void BtnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNuevoUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtNuevaContraseña.Text.Trim()))
                {
                    new Auxiliar().Guardar(new Login() { Id = 0, Usuario = txtNuevoUsuario.Text.Trim(), Password = txtNuevaContraseña.Text.Trim() });
                    Toast.MakeText(this, "Registro guardado", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una contraseña", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }


    }
}

using System;


namespace Utilitarios
{
    public class U_Registro
    {
        private U_Paciente pac;
        private String url;
        private bool valores;
        private string error_cedula_paciente;
        private String error_nombre_paciente;
        private String error_apellido_paciente;
        private String error_direccion_paciente;
        private string error_telefono_paciente;
        private String error_correo_paciente;
        private String error_clave_paciente;
        private string error_nacmiento_paciente;
        private String error_foto;
        private String error_session;
        private String error_sexo;

        public U_Paciente Pac { get => pac; set => pac = value; }
        public string Url { get => url; set => url = value; }
        public bool Valores { get => valores; set => valores = value; }
        public string Error_cedula_paciente { get => error_cedula_paciente; set => error_cedula_paciente = value; }
        public string Error_nombre_paciente { get => error_nombre_paciente; set => error_nombre_paciente = value; }
        public string Error_apellido_paciente { get => error_apellido_paciente; set => error_apellido_paciente = value; }
        public string Error_direccion_paciente { get => error_direccion_paciente; set => error_direccion_paciente = value; }
        public string Error_telefono_paciente { get => error_telefono_paciente; set => error_telefono_paciente = value; }
        public string Error_correo_paciente { get => error_correo_paciente; set => error_correo_paciente = value; }
        public string Error_clave_paciente { get => error_clave_paciente; set => error_clave_paciente = value; }
        public string Error_nacmiento_paciente { get => error_nacmiento_paciente; set => error_nacmiento_paciente = value; }
        public string Error_foto { get => error_foto; set => error_foto = value; }
        public string Error_session { get => error_session; set => error_session = value; }
        public string Error_sexo { get => error_sexo; set => error_sexo = value; }
    }
}

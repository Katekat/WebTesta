using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cAccesoModulo
    {
        private int id;
        private string nombre;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public class cRol {
            public int id;
            public string nombre;

            public int Id { get => id; set => id = value; }
            public string Nombre { get => nombre; set => nombre = value; }
        }

        public class cRoloperacion {
            public int id;
            public int idRol;
            public int idOperacion;

        }

        public class cOperacion {
            public int id;
            public string nombre;
            public int idModulo;

            public int Id { get => id; set => id = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public int IdModulo { get => idModulo; set => idModulo = value; }
        }

       


    }
}

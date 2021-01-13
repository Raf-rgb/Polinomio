using System;

namespace Lagrange 
{
    class Polinomio 
    {
        public double[] coeficientes;
        public int grado;
        public int n;

        // Metodo constructor que recibe como parametro
        // un arreglo de tipo double con los coeficientes
        // del polinomio ordenado.
        public Polinomio(double[] coeficientes_) {
            coeficientes = coeficientes_;
            grado = coeficientes.Length - 1;
            n = coeficientes.Length;
        }

        // Metodo constructor que recibe como parametro
        // el numero de coeficientes del polinomio.
        public Polinomio(int n_) {
            n = n_;
            coeficientes = new double[n];
            grado = n - 1;
        }

        // Funcion que imprime en consola el polinomio 
        // en su expresion matematica.
        public void Print() {
            // Variable que guardará el polinomio en notacion
            // matematica.
            string polinomio = "";

            // Variable auxiliar que guardará el grado de cada
            // variable x del polinomio. Su valor será igual
            // al valor de la variable global grado.
            int g = grado;

            // El primer termino siempre tiene el grado más alto
            // por lo que directamente se concatena a la variable
            // polinomio.
            if(grado > 1) {
                if(coeficientes[0] != 1) polinomio += $"{coeficientes[0]}x^{grado}";
                else polinomio += $"x^{grado}";
            } else {
                if(coeficientes[0] != 1) polinomio += $"{coeficientes[0]}x";
                else polinomio += $"x";
            }

            // Se pasa a un grado menor.
            g = g - 1;

            // Para cada coeficiente entre los extremos del polinomio
            for(int i = 1; i < coeficientes.Length - 1; i++) {
                // Si el coeficiente es positivo, se agrega el
                // signo +
                if(coeficientes[i] > 0) polinomio += " +";
                
                // Se agrega el coeficiente si es mayor a 1
                if(coeficientes[i] != 1) polinomio += " " + coeficientes[i];

                // Si el grado es mayor a 1, se agrega
                // la variable x y su respectivo grado.
                // si no, entonces solo se agrega la
                // variable x
                if(g > 1) polinomio += $"x^{g}";
                else polinomio += "x";

                g--;
            }

            // Si el valor constante del polinomio (el ultimo coeficiente)
            // es positivo, se agrega el signo +
            if(coeficientes[coeficientes.Length - 1] > 0) polinomio += " + ";
            else polinomio += " ";

            // Se agrega el valor constante del polinomio.
            polinomio += coeficientes[coeficientes.Length - 1];

            // Se imprime el polinomio en notacion matematica
            Console.WriteLine($"[ {polinomio} ]");
        }

        // Funcion que imprime los coeficientes del
        // polinomio.
        public void PrintCoef() {
            Console.Write("[ ");
            for(int i = 0; i < coeficientes.Length; i++) {
                Console.Write($" {coeficientes[i]}");
                if(i < coeficientes.Length - 1) Console.Write(", ");
            }
            Console.Write(" ]");
        }

        // Funcion que calcula el producto de la multiplicacion
        // de dos polinomios. La funcion recibe como parametro
        // dos polinomios y devuelve un nuevo polinomio, 
        // producto de la multiplicacion.
        public static Polinomio Mult(Polinomio p, Polinomio q) {
            // Polinomio resultante de la multiplicacion
            Polinomio producto = new Polinomio(p.n + q.n - 1);

            // Se multiplica cada termino de P(x)
            // por cada termino de Q(x), a su vez
            // se suman terminos comunes y se
            // guarda en el polinomio resultante.
            for(int i = 0; i < p.n; i++) {
                for(int j = 0; j < q.n; j++) {
                    producto.coeficientes[i + j] += p.coeficientes[i] * q.coeficientes[j];
                }
            }
            
            // Se devuelve el polinomio resultante
            return producto;
        }

        // Funcion que realiza la multiplicacion de un polinomio
        // por una constante. La funcion recibe como parametro
        // el polinomio y la constante, realiza la multiplicacion
        // y devuelve el polinomio resultante.
        public static Polinomio Mult(Polinomio p, double c) {
            // Polinomio resultante
            Polinomio producto = new Polinomio(p.n);
            
            // Se multiplica cada coeficiente por la 
            // constante y se guarda en el polinomio
            // resultante.
            for(int i = 0; i < producto.n; i++) producto.coeficientes[i] = p.coeficientes[i] * c;

            // Se devuelve el polinomio resultante
            return producto;
        }
    }
}
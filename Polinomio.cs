using System;

namespace Polinomios
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

            // Si el polinomio tiene más de 2 coeficientes
            // quiere decir que su grado es mayor a 0
            if(n > 1) {
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
                    if(coeficientes[i] != 1 && coeficientes[i] != 0) polinomio += " " + coeficientes[i];

                    // Si el grado es mayor a 1, se agrega
                    // la variable x y su respectivo grado.
                    // si no, entonces solo se agrega la
                    // variable x
                    if(g > 1 && coeficientes[i] != 0) polinomio += $"x^{g}";
                    else polinomio += "x";

                    g--;
                }

                // Si el valor constante del polinomio (el ultimo coeficiente)
                // es positivo, se agrega el signo +
                if(coeficientes[coeficientes.Length - 1] > 0) polinomio += " + " + coeficientes[coeficientes.Length - 1];
                else if (coeficientes[coeficientes.Length - 1] < 0) polinomio += " " + coeficientes[coeficientes.Length - 1];
            } 
            // Si el polinomio tiene solo un coeficiente, entonces
            // es de grado 0, solo se imprime como constante.
            else {
                polinomio += coeficientes[0];
            }

            // Se imprime el polinomio en notacion matematica
            Console.WriteLine($"[ {polinomio} ]\n");
        }

        // Funcion que imprime los coeficientes del
        // polinomio.
        public void PrintCoef() {
            Console.Write("[ ");
            for(int i = 0; i < coeficientes.Length; i++) {
                Console.Write($" {coeficientes[i]}");
                if(i < coeficientes.Length - 1) Console.Write(", ");
            }
            Console.Write(" ]\n");
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

        // Funcion que suma dos polinomios.
        // La funcion recibe como argumentos
        // dos polinomios para sumar.
        // Devuelve el resultado como la suma.
        public static Polinomio Add(Polinomio p, Polinomio q) {
            // Polinomio resultante de la suma
            Polinomio resultante;

            // Si el los polinomios son del mismo tamaño
            // solo se suma termino por termino.
            if(p.n == q.n) {
                resultante = new Polinomio(p.n);

                // Se suma termino por termino
                for (int i = 0; i < resultante.n; i++)
                    //Se guarda la suma de los terminos en el 
                    //polinomio resultante.
                    resultante.coeficientes[i] = p.coeficientes[i] + q.coeficientes[i];
            
            } else {
                // Se define el polinomio de grado mayor y el 
                // polinomio de grado menor.
                Polinomio max, min;

                // Variable auxiliar que guardará la 
                // diferencia de terminos de los dos
                // polinomios a sumar
                int dif;

                if(p.n < q.n) {
                    max = q;
                    min = p;
                } else {
                    max = p;
                    min = q;
                }

                // El polinomio resultante será del mismo
                // tamaño que el polinomio de grado mayor.
                resultante = new Polinomio(max.n);

                // Se calcula la diferencia de terminos.
                dif = max.n - min.n;
                
                // Se almacenan los terminos no comunes de
                // los polinomios en el polinomio resultante.
                for(int i = 0; i < dif; i++) {
                    resultante.coeficientes[i] = max.coeficientes[i];
                }

                // Se suman terminos comunes en el el 
                // polinomio resultante.
                for(int i = dif; i < max.n; i++) {
                    resultante.coeficientes[i] = max.coeficientes[i] + min.coeficientes[i - dif];
                }
            }

            // Se devuelve el polinomio resultante.
            return resultante;
        }
    }
}
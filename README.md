# Polinomio
Una librería simple para trabajar con polinomios

## Creando un polinomio
Para crear un polinomio con los terminos ordenados, se crea un objeto de tipo polinomio y se pasa como argumento al constructor los coeficientes del polinomio como un arreglo

```c#
  // Creando un polinomio P(x) = -2x^3 + 5x^2 + 6x - 3
  Polinomio p = new Polinomio(new double[]{-2, 5, 6, -3});
```

Tambien se pueden crear polinomios con vacios que sirvan como moldes, pasando como argumento la cantidad de terminos al constructor

```c#
  // Creando un polinomio P(x) vacio, de la forma: ax^2 + bx + c 
  Polinomio p = new Polinomio(3);
```

## Imprimiendo un polinomio
Podemos visualizar en consola nuestro polinomio en notacion matematica con la funcion Print()

```c#
  // Creando un polinomio P(x) = -2x^3 + 5x^2 + 6x - 3
  Polinomio p = new Polinomio(new double[]{-2, 5, 6, -3});
  
  // Imprimiendo el polinomio en notacion matematica
  p.Print();
  
  // Resultado en consola:
  // [ -2x^3 + 5x^2 + 6x -3 ]
```

## Multiplicando un polinomio por una constante  << c * P(x) >> 
Para multiplicar un polinomio por una constante, se utiliza la funcion Mult() que recibe como parametros el polinomio y la constante de tipo double

```c#
  // Creando un polinomio P(x) = 2x^4 + 5x^3 - 6x^2 + 7x + 1
  Polinomio p = new Polinomio(new double[]{2, 5, -6, 7, 1});
  
  // Constante
  double c = 3;
  
  // Nuevo polinomio que guardará el polinomio resultante de la multiplicacion
  Polinomio producto = Polinomio.Mult(p, c);
  
  // Imprimiendo el polinomio resultante en notacion matematica
  producto.Print();
  
  // Resultado en consola:
  // [ 6x^4 + 15x^3 -18x^2 + 21x + 3 ]
```

## Multiplicando dos polinomios << P(x) * Q(x) >>
Podemos realizar la multiplicacion de dos polinomios P(x) y Q(x) con la funcion Mult() que recibe como argumentos los dos polinomios y devuelve el polinomio resultante

```c#
  // Creando un polinomio P(x) = -2x^3 + 5x^2 + 6x - 3
  Polinomio p = new Polinomio(new double[]{-2, 5, 6, -3});
  
  // Creando un polinomio Q(x) = 3x^2 + x - 4
  Polinomio q = new Polinomio(new double[]{3, 1, -4});
  
  // Nuevo polinomio que guardará el polinomio resultante de la multiplicacion
  Polinomio producto = Polinomio.Mult(p, q);
  
  // Imprimiendo el polinomio resultante en notacion matematica
  producto.Print();
  
  // Resultado en consola:
  // [ -6x^5 + 13x^4 + 31x^3 -23x^2 -27x + 12 ]
```

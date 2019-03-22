# Proyecto Calculadora y consumo de servicios REST

Herramienta de desarrollo: Visual Studio.net community 2017

Este proyecto consta de dos soluciones que se encuentran dentro de la carpeta Calculator.

## CalculatorClient

Una aplicacion de consola creada para consumir el servicio CalculatorService, en esta aplicacion tenemos las opciones de Suma, Resta, 
Multiplicación, División, Raiz Cuadrada y revision de logs; El usuario debe ingresar el valor solicitado por la aplicacion para posteriormente ver el resultado.

En la ejecución de cualquier operacion , la aplicacion va a solicitar un parametro opcional que es "Tracking-Id", si se envia este parametro, 
el sistema procedera a guardar el historial en un arhivo ubicado en la ruta: "CalculatorService\CalculatorService.Server\jsondata.json" en formato JSON, este parametro "Tracking-Id" es un header que se adiciona a la peticion POST, sin embargo si no es diligenciado se envia este header siempre con valor 0.

Este archivo se inicializara como una lista vacia.

Si en cualquier caso se ingresa letras en vez de numeros, el sistema contestara con un -1, y se podra volver a seleccionar alguna opcion.

#### DEPENDENCIAS

Este proyecto usa el paquete Nugget => RestSharp.


## CalculatorService

En esta solución tenemos los siguientes proyectos:

- CalculatorService.BusinessLayer: Capa de negocio.

   #### Dependencias: 
     Proyecto CalculatorService.DataLayer

- CalculatorService.DataLayer: Capa de acceso a datos.
- CalculatorService.Server.Tests: Pruebas unitarias.
  #### Dependencias: 
     -CalculatorService.DataLayer

- Common: Proyecto transversal donde se encuentra modelos compartidos y demas.
- CalculatorService.Server: Este proyecto es el WEB API, y es el que se inicia el servicio REST.

Las operaciones que tiene este servicio son las siguientes:

Add : Hace la suma de varios numeros y devuelve el resultado a la consola. Este método recibe un objeto de tipo array de int y es un metodo de tipo: POST.

Sub : Realiza la resta entre dos numeros y devuelve el resultado. Este método recibe dos objetos de tipo int y es un metodo de Tipo: POST.

Mult : Método que hace la multiplicación de varios números y devuelve el resultado. Este método espera un objeto de tipo array de int y es un metodo de tipo POST.

Div : Método que realiza la división entre dos números y devuelve el resultado (Cociente y resto). Este método espera dos objetos int (dividendo y divisor) y es un método de tipo POST.

Sqrt - Método que realiza la raíz cuadrada de un número ingresado. Este método espera un objeto int sobre el que se resuelve la raíz cuadrada y devuelve el resultado , este método es de tipo POST.

Query - Consulta una lista de operaciones realizadas anteriormente que tenga el mismo identificador (ID). Este método recibe un int y devuelve una lista de las operaciones realizadas, este método es de tipo POST.


   #### Dependencias: 

   -CalculatorService.DataLayer

   -Paquete nugget  Microsoft.AspNet.Cors.





## Installation

      git clone https://github.com/germangc125/Calculator.git

- Ejecutar la solución CalculatorService.sln y levantar el web api, verificar que el proyecto CalculatorService.Server este configurado como inicial.

- Ejecutar la solución del cliente y usar las opciones programadas.


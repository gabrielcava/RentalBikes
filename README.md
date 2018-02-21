# RentalBikes
Ejercicio de desarrollo de estructura de clases para resolver el contexto de un alquiler de bicicletas

El diseño que elegi es una composicion, teniendo 1 clase abstracta que contenga la firma para calcular los precios, 2 clases que hereden de la misma.
La primer clase define el calculo normal de unidades totales por precio por unidad (hora, dia o semana)
La segunda clase contiene una lista de clases y un descuento para aplicar en el calculo total (alquiler familiar)
Se desarrollo todo en C#, creando un proyecto de libreria para Entity Framework 4.5.2

Se creo un proyecto separado para construir los Unit Test, para no generar dependencias.
Los UT tienen un 100% de covertura aproximadamente.
Se pueden correr utlizando la herramienta de unit test del visual studio.

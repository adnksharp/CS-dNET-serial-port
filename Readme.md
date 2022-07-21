# SerialPort in C#

[![Captura-de-pantalla-2022-07-21-122726.png](https://i.postimg.cc/YCJ1M48p/Captura-de-pantalla-2022-07-21-122726.png)](https://postimg.cc/XrkZgYTh)

Uso de ```SerialPort``` para conectar apliacaciones de Windows Forms con dispositivos por el puerto serie.

Medionte dos botones:

- La apliación busca los puertos serie disponibles en la máquina.
- Inicia/Finaliza conexiones por medio del puerto serie con la aplicación.

La aplicación considera únicamente si es posible conectarse con el puerto serie  y realiza la conexión de ser posible pero no maneja datos entre dispositivos como ```Serial.Write``` o ```Serial.Read```.

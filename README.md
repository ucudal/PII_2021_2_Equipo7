# **Proyecto Programacion II - Los 4 Fantasticos**

ChatBot diseñado para actuar de intermediario entre empresas en posesion de materiales residuales/desechables y emprendedores quienes podrian utilizar dichos materiales. Este proyecto se realiza para el curso de Programacion II en la Universidad Catolica del Uruguay

## **Consigna y Entregas**

1. [Consigna](./docs/Consigna/Consigna.md)
2. [1ra Entrega](./docs/Entregas/Entrega1.md)
3. [2da Entrega](./docs/Entregas/Entrega2.md)

## **Diagramas**

<img src="./docs/Diagramas/DiagramaUML.svg">
<img src="./docs/Diagramas/DiagramaFlujoEmpresa.svg">

## **Notas del Proceso**

TODO: Agregar notas.

### **Autenticacion del Usuario**

Todo usuario registrado esta en el sistema con una lista de cuentas asociadas. Estas cuentas estan formadas por pares de servicio de mensajeria y identificador en el servicio. Todos los puntos de contacto con las API de servicios de mensajeria toman los datos asociados al mensaje y lo convierten en un MessageWrapper con el servicio, el identificador, y el mensaje enviado por el usuario. Despues de esto se pasa a procesar los datos de identificacion para saber si la cuenta que envio el mensaje esta registrada, suspendida, o no registrada. Estos datos del usuario asociado y su estado son guardados en el MessageWrapper para su posterior uso en estructuras de control de flujo y filtrado de datos.

### **Recorrido del mensaje**

1. El mensaje es recibido por los puntos de contacto con las API soportadas, que formatea los datos de la cuenta y el mensaje para utilizar un `MessageWrapper`.
2. El `MessageWrapper` es enviado al `MessageHandler` para cargar datos del usuario con el `UserAuthenticator`.
3. Se envia el mismo objeto, ahora con los datos del usuario, al `CommandHandler` quien procesa los datos de la sesion existente y crea un Selector para enviar a la cadena de responsabilidad encargada de procesar los mensajes.
4. El objeto `ChatDialogEntry` configura todos los casos concretos de la cadena de responsabilidad y envia el selector recibido desde el `CommandHandler` al primer miembro de la cadena.
5. Dentro de la cadena, cada miembro utiliza el metodo `ValidateDataEntry(...)` para confirmar si el mismo es quien debe responder al mensaje enviado por el usuario. De serlo asi, este llama al metodo `Execute(...)` quien realiza las operaciones relevantes y fabrica el mensaje de respuesta al usuario.
6. El mensaje de respuesta es retornado desde el miembro concreto de la cadena hasta el `MessageHandler` (pasando por el `ChatDialogEntry` y `CommandHandler`) quien crea un contenedor de respuesta y lo envia al `ResponseHandler`.
7. El `ResponseHandler` se encarga de enviar al punto de contacto con el servicio de mensajeria, el mensaje al usuario asociado.

### **Proceso de comandos**

Decidimos utilizar los patrones Command y Chain of Responsibility para manejar el proceso de los comandos y datos introducidos por el usuario, ademas de una clase `Session` la cual tiene la responsabilidad de conocer los datos de la sesion del usuario relevante (Esta sesion esta siempre disponible en todo lugar del programa mediante un `SessionContainer` accedido por medio de un Singleton). 

Cada Command dentro de la cadena tiene asociado 3 propiedades que referencian: su codigo identificador, una lista de codigos padres, y una ruta de acceso. El codigo identificador es unico para cada Command y permite establecer en la sesion cual fue el ultimo comando ejecutado por el usuario. La lista de codigos de padres se utiliza para mediante el contexto (ultimo Command ejecutado) guardado en la sesion, si es posible ejecutar el commando actual. La ruta de acceso es el texto del comando que el usuario debe enviar para poder que sea posible ejecutar este Command.

La verificacion elegibilidad para ejecucion en si de cada Command se realiza en el metodo `ValidateDataEntry(...)`. La clase abstracta base de todos los Commands - `ChatDialogHandlerBase` - implementa un codigo de generico para todos los Commands que puede o no ser sobreescrito por cada Command concreto. Esta validacion generica revisa 2 condiciones: 1) Que el el codigo del ultimo Command ejecutado (el contexto de la sesion) este entre los padres del Command actual, o que este no tenga padres y que el contexto sea vacio; 2) Que la ruta sea igual al commando ingresado por el usuario. En caso de cumplirse estas dos condiciones, y asumiendo que el el `ValidateDataEntry(...)` no haya sido sobreescrito por el Command concreto, entonces el Command actual sera el que se ejecute por medio del metodo `Execute(...)`.

### **Prompts al usuario**

El pedido de datos al usuario (prompt) funciona sobreescribiendo el metodo `ValidateDataEntry(...)` del Command que responde a la entrada de datos. Este Command de respuesta debe tener entre sus padres al codigo del Command que le pidio al usuario ingresar datos, y tambien debe tener su ruta nula ya que no va a responder a un texto concreto. El `ValidateDataEntry(...)` deberia entonces verificar la existencia del contexto de sesion en la lista de padres, que el texto enviado por el usuario no empiece con el caracter reservado para commandos (`\`), y que el dato entrado sea valido para lo esperado (id existente en base de datos, numero cuando se espera uno, etc...).

### **Memoria de conversacion**

Al realizar operaciones con multiples datos requeridos el Bot debe de poder 'recordar' datos entre cada comando para poder ejecutar el codigo asociado a la operacion al terminar de recolectar los datos especificados por el usuario. Esto lo implementamos en la clase `Session`, la cual guarda un proceso el cual contiene al mismo tiempo un campo de tipo variable con el contenedor de datos relevante al proceso actual. Las clases de datos especificas se crean para cada proceso y contienen los datos precisos por el proceso asociado para realizar la operacion que se le pide.




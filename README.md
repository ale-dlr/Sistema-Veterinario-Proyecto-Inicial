# Sistema-Veterinario-Proyecto-Inicial

> Proyecto desarrollado en **Java (BlueJ)** como parte del curso de **Programación II** en la Universidad Mariano Gálvez (UMG).

---

## 📋 Descripción del Proyecto
Sistema automatizado de consola para la gestión integral de una clínica veterinaria. Permite administrar tutores, dar de alta a pacientes (mascotas), registrar consultas con su respectivo historial clínico y calcular cobros para la facturación de servicios y medicamentos. 

El sistema está diseñado aplicando los pilares de la **Programación Orientada a Objetos (POO)**, destacando el uso de herencia, encapsulamiento y asociaciones bidireccionales mediante estructuras de datos dinámicas (`ArrayList`).

---

## 🏗️ Clases y Estructura del Sistema

El proyecto consta de 5 clases principales organizadas de la siguiente manera:

1. **`Persona`** (Superclase base): Almacena los atributos corporales y de contacto generales (`nombre`, `documento`, `telefono`, `direccion`).
2. **`Tutor`** (Subclase): Hereda de `Persona` y representa al propietario de la mascota. Contiene una lista dinámica de pacientes asociados (`List<Paciente>`).
3. **`Paciente`** (Entidad): Modela al animal atendido (`nombre`, `especie`, `raza`, `peso`, `edad`). Cuenta con una referencia a su dueño (`Tutor`) y un historial de consultas médicas (`List<Consulta>`).
4. **`Consulta`** (Entidad clínica): Registra los detalles médicos por visita (`fecha`, `motivo`, `temperatura`, `diagnosticoVeterinario`, `medicamentosRecetados`).
5. **`SistemaVeterinario`** (Controlador / Simulador): Clase principal que gestiona el menú interactivo en la terminal y coordina las operaciones del sistema.

---

## ⚙️ Menú de Funcionalidades

El simulador interactivo ofrece las siguientes opciones en consola:

* **1. Registrar Tutor (Cliente):** Captura los datos personales del propietario y los almacena en el sistema.
* **2. Registrar Mascota (Paciente):** Vincula un nuevo paciente seleccionando previamente a su tutor responsable de una lista.
* **3. Registrar Consulta e Historia Clínica:** Busca al paciente por su nombre y añade un registro clínico con temperatura, diagnóstico y receta.
* **4. Facturar Consulta y Medicamentos:** Calcula el costo total sumando servicios médicos e insumos, generando un comprobante formateado en pantalla.
* **5. Ver Expediente de una Mascota:** Muestra la ficha técnica completa y el historial cronológico de todas sus visitas pasadas.
* **6. Salir:** Finaliza la ejecución del programa.

---

## 🚀 Cómo Ejecutar el Proyecto

### Opción A: En Visual Studio (C#)
1. Abre **Visual Studio** y crea un nuevo proyecto de tipo **Aplicación de consola** (.NET Core o .NET Framework).
2. Asegúrate de que el espacio de nombres (*namespace*) sea `SistemaVeterinario`.
3. Pega el código fuente original en el archivo `Program.cs`.
4. Haz clic en el botón verde **Iniciar** (o presiona la tecla `F5`) para compilar y abrir la consola interactiva.

### Opción B: En BlueJ (Java)
1. Abre **BlueJ** y crea un nuevo proyecto llamado `SistemaVeterinario`.
2. Crea las clases en el siguiente orden para evitar errores de compilación por dependencias:
   * `Persona`
   * `Consulta`
   * `Tutor` (extiende de `Persona`)
   * `Paciente`
   * `SistemaVeterinario` (Clase principal con el menú)
3. Pega el código fuente correspondiente en cada clase y haz clic en **Compilar**.
4. Haz clic derecho sobre la clase **`SistemaVeterinario`**, selecciona `void main(String[] args)` y presiona Aceptar para iniciar la consola interactiva.

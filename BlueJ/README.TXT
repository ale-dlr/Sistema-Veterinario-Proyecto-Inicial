------------------------------------------------------------------------
PROYECTO: Sistema Veterinario
CURSO: Programación II - UMG Portales
AUTOR: Mónica Alejandra de la Rosa Hernández
VERSIÓN: 1.0 
------------------------------------------------------------------------
DESCRIPCIÓN DEL PROYECTO:
Sistema automatizado para la gestión integral de una clínica veterinaria, 
permitiendo el registro de tutores, el control de pacientes (mascotas), 
el registro de consultas con su historial clínico y el cálculo de cobros 
para la facturación. Aplica conceptos de Programación Orientada a Objetos 
(POO) como herencia, encapsulamiento y relaciones de asociación bidireccional.

OBJETOS INCLUIDOS:
1. Persona: Superclase base con datos de identificación personal (Nombre, Documento, Teléfono, Dirección).
2. Tutor: Subclase de Persona que modela al propietario y contiene una lista de sus mascotas asociadas.
3. Paciente: Modela a la mascota (Nombre, Especie, Raza, Peso, Edad), enlazada a su tutor y a su historial médico.
4. Consulta: Modela el historial clínico de cada visita (Fecha, Motivo, Temperatura, Diagnóstico y Medicamentos recetados).
5. SistemaVeterinario: Clase principal con el simulador de consola interactivo basado en menús para la ejecución y pruebas del sistema.

NOTA TÉCNICA:
Implementa diseño estructural en BlueJ con relaciones de herencia (Tutor hereda de Persona), 
asociaciones bidireccionales y uso de colecciones dinámicas (ArrayList) para el almacenamiento 
en memoria de tutores, pacientes e historiales médicos.
------------------------------------------------------------------------
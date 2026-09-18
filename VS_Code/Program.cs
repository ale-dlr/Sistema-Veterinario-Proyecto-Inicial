using System;
using System.Collections;
using System.Collections.Generic;

namespace SistemaVeterinario
{
    // Clase Base para personas (Principio de Herencia)
    public class Persona
    {
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }

    // Clase Tutor (Propietario de la mascota)
    public class Tutor : Persona
    {
        public List<Paciente> Mascotas { get; set; } = new List<Paciente>();
    }

    // Clase Paciente (Mascota: Perro, Gato, etc.)
    public class Paciente
    {
        public string Nombre { get; set; }
        public string Especie { get; set; } // Perro, Gato, etc.
        public string Raza { get; set; }
        public double Peso { get; set; }
        public int Edad { get; set; }
        public Tutor Duenio { get; set; }
        public List<Consulta> HistorialMedico { get; set; } = new List<Consulta>();
    }

    // Clase Consulta (Historia Clínica y Tratamiento separados)
    public class Consulta
    {
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Motivo { get; set; }
        public double Temperatura { get; set; }
        public string DiagnosticoVeterinario { get; set; } // Lo que dice el veterinario
        public string MedicamentosRecetados { get; set; }   // El medicamento que le deje
    }

    class Program
    {
        static List<Tutor> listaTutores = new List<Tutor>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("      SISTEMA  VETERINARIO      ");
                Console.WriteLine("=============================");
                Console.WriteLine("1. Registrar Tutor (Cliente)");
                Console.WriteLine("2. Registrar Mascota (Paciente)");
                Console.WriteLine("3. Registrar Consulta e Historia Clínica");
                Console.WriteLine("4. Facturar Consulta y Medicamentos");
                Console.WriteLine("5. Ver Expediente de una Mascota");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarTutor();
                            break;
                        case 2:
                            RegistrarMascota();
                            break;
                        case 3:
                            RegistrarConsulta();
                            break;
                        case 4:
                            FacturarServicios();
                            break;
                        case 5:
                            VerExpediente();
                            break;
                        case 6:
                            Console.WriteLine("\n¡Gracias por usar el sistema!");
                            break;
                        default:
                            Console.WriteLine("\n[Error] Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n[Error] Por favor ingrese un número válido.");
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }

        static void RegistrarTutor()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE NUEVO TUTOR ---");
            Tutor tutor = new Tutor();

            Console.Write("Nombre completo: ");
            tutor.Nombre = Console.ReadLine();
            Console.Write("Documento (DPI / Cédula): ");
            tutor.Documento = Console.ReadLine();
            Console.Write("Teléfono: ");
            tutor.Telefono = Console.ReadLine();
            Console.Write("Dirección: ");
            tutor.Direccion = Console.ReadLine();

            listaTutores.Add(tutor);
            Console.WriteLine("\n[Éxito] ¡Tutor registrado correctamente!");
        }

        static void RegistrarMascota()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE NUEVA MASCOTA ---");

            if (listaTutores.Count == 0)
            {
                Console.WriteLine("[Aviso] No hay tutores registrados. Registre un tutor primero.");
                return;
            }

            Console.WriteLine("Seleccione al tutor responsable:");
            for (int i = 0; i < listaTutores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {listaTutores[i].Nombre} (Tel: {listaTutores[i].Telefono})");
            }

            Console.Write("\nNúmero del tutor: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= listaTutores.Count)
            {
                Tutor tutorSeleccionado = listaTutores[index - 1];
                Paciente mascota = new Paciente();

                Console.Write("Nombre de la mascota: ");
                mascota.Nombre = Console.ReadLine();
                Console.Write("Especie (Perro, Gato, etc.): ");
                mascota.Especie = Console.ReadLine();
                Console.Write("Raza: ");
                mascota.Raza = Console.ReadLine();

                Console.Write("Peso (kg): ");
                double.TryParse(Console.ReadLine(), out double peso);
                mascota.Peso = peso;

                Console.Write("Edad (años): ");
                int.TryParse(Console.ReadLine(), out int edad);
                mascota.Edad = edad;

                mascota.Duenio = tutorSeleccionado;
                tutorSeleccionado.Mascotas.Add(mascota);

                Console.WriteLine($"\n[Éxito] ¡{mascota.Nombre} registrado(a) con éxito!");
            }
            else
            {
                Console.WriteLine("\n[Error] Selección inválida.");
            }
        }

        static void RegistrarConsulta()
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE CONSULTA E HISTORIA CLÍNICA ---");

            Paciente mascota = BuscarMascota();
            if (mascota == null) return;

            Consulta consulta = new Consulta();

            Console.Write("Motivo de la visita: ");
            consulta.Motivo = Console.ReadLine();

            Console.Write("Temperatura corporal (°C): ");
            double.TryParse(Console.ReadLine(), out double temp);
            consulta.Temperatura = temp;

            Console.WriteLine("\n--- DIAGNÓSTICO MÉDICO ---");
            Console.Write("¿Qué dice el veterinario (Observación / Diagnóstico)?: ");
            consulta.DiagnosticoVeterinario = Console.ReadLine();

            Console.WriteLine("\n--- RECETA / TRATAMIENTO ---");
            Console.Write("¿Qué medicamento se le deja (Fármaco, dosis, duración)?: ");
            consulta.MedicamentosRecetados = Console.ReadLine();

            mascota.HistorialMedico.Add(consulta);
            Console.WriteLine($"\n[Éxito] ¡Historia clínica actualizada para {mascota.Nombre}!");
        }

        static void FacturarServicios()
        {
            Console.Clear();
            Console.WriteLine("--- CAJA Y FACTURACIÓN ---");

            Paciente mascota = BuscarMascota();
            if (mascota == null) return;

            Console.WriteLine($"\nFacturando para la mascota: {mascota.Nombre} (Tutor: {mascota.Duenio.Nombre})");

            Console.Write("Costo de la Consulta Médica (Q): ");
            double.TryParse(Console.ReadLine(), out double costoConsulta);

            Console.Write("Costo de los Medicamentos / Productos (Q): ");
            double.TryParse(Console.ReadLine(), out double costoMedicamentos);

            double total = costoConsulta + costoMedicamentos;

            Console.WriteLine("\n================================================");
            Console.WriteLine("                   FACTURA VETERINARIA            ");
            Console.WriteLine("==================================================");
            Console.WriteLine($" Fecha: {DateTime.Now}");
            Console.WriteLine($" Cliente: {mascota.Duenio.Nombre}");
            Console.WriteLine($" Paciente: {mascota.Nombre} ({mascota.Especie})");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($" * Consulta Médica..............: {costoConsulta:F2}");
            Console.WriteLine($" * Medicamentos / Insumos.......: {costoMedicamentos:F2}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($" TOTAL A PAGAR..................: {total:F2}");
            Console.WriteLine("==================================================");
            Console.WriteLine("¡Pago registrado y factura generada con éxito!");
        }

        static void VerExpediente()
        {
            Console.Clear();
            Console.WriteLine("--- CONSULTAR EXPEDIENTE CLÍNICO ---");

            Paciente mascota = BuscarMascota();
            if (mascota == null) return;

            Console.WriteLine("\n==================================================");
            Console.WriteLine($" PACIENTE: {mascota.Nombre} | Especie: {mascota.Especie} ({mascota.Raza})");
            Console.WriteLine($" Datos: {mascota.Peso} kg | {mascota.Edad} años");
            Console.WriteLine($" Tutor: {mascota.Duenio.Nombre} | Tel: {mascota.Duenio.Telefono}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($" Historial Clínico ({mascota.HistorialMedico.Count} registros):");

            if (mascota.HistorialMedico.Count == 0)
            {
                Console.WriteLine("  (No hay consultas registradas)");
            }
            else
            {
                int num = 1;
                foreach (var c in mascota.HistorialMedico)
                {
                    Console.WriteLine($"\n  [Visita #{num++}] Fecha: {c.Fecha}");
                    Console.WriteLine($"    - Motivo: {c.Motivo} ({c.Temperatura} °C)");
                    Console.WriteLine($"    - Diagnóstico del Veterinario: {c.DiagnosticoVeterinario}");
                    Console.WriteLine($"    - Medicamento recetado: {c.MedicamentosRecetados}");
                }
            }
            Console.WriteLine("==================================================");
        }

        static Paciente BuscarMascota()
        {
            if (listaTutores.Count == 0)
            {
                Console.WriteLine("\n[Aviso] No hay tutores ni mascotas registrados.");
                return null;
            }

            Console.Write("Ingrese el nombre de la mascota: ");
            string nombreBuscado = Console.ReadLine();

            foreach (var tutor in listaTutores)
            {
                foreach (var mascota in tutor.Mascotas)
                {
                    if (mascota.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
                    {
                        return mascota;
                    }
                }
            }

            Console.WriteLine("\n[Aviso] No se encontró ninguna mascota con ese nombre.");
            return null;
        }
    }
}
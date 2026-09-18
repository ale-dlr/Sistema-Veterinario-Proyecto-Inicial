import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class SistemaVeterinario {
    private static List<Tutor> listaTutores = new ArrayList<>();
    private static Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        int opcion = 0;

        do {
            System.out.println("\n=================================");
            System.out.println("      SISTEMA  VETERINARIO       ");
            System.out.println("=================================");
            System.out.println("1. Registrar Tutor (Cliente)");
            System.out.println("2. Registrar Mascota (Paciente)");
            System.out.println("3. Registrar Consulta e Historia Clínica");
            System.out.println("4. Facturar Consulta y Medicamentos");
            System.out.println("5. Ver Expediente de una Mascota");
            System.out.println("6. Salir");
            System.out.print("\nSeleccione una opción: ");

            if (scanner.hasNextInt()) {
                opcion = scanner.nextInt();
                scanner.nextLine(); // Limpiar buffer

                switch (opcion) {
                    case 1:
                        registrarTutor();
                        break;
                    case 2:
                        registrarMascota();
                        break;
                    case 3:
                        registrarConsulta();
                        break;
                    case 4:
                        facturarServicios();
                        break;
                    case 5:
                        verExpediente();
                        break;
                    case 6:
                        System.out.println("\n¡Gracias por usar el sistema!");
                        break;
                    default:
                        System.out.println("\n[Error] Opción no válida.");
                        break;
                }
            } else {
                System.out.println("\n[Error] Por favor ingrese un número válido.");
                scanner.next(); // Limpiar entrada errónea
            }

            if (opcion != 6) {
                System.out.println("\nPresione Enter para continuar...");
                scanner.nextLine();
            }

        } while (opcion != 6);
    }

    private static void registrarTutor() {
        System.out.println("\n--- REGISTRO DE NUEVO TUTOR ---");
        Tutor tutor = new Tutor();

        System.out.print("Nombre completo: ");
        tutor.setNombre(scanner.nextLine());
        System.out.print("Documento (DPI / Cédula): ");
        tutor.setDocumento(scanner.nextLine());
        System.out.print("Teléfono: ");
        tutor.setTelefono(scanner.nextLine());
        System.out.print("Dirección: ");
        tutor.setDireccion(scanner.nextLine());

        listaTutores.add(tutor);
        System.out.println("\n[Éxito] ¡Tutor registrado correctamente!");
    }

    private static void registrarMascota() {
        System.out.println("\n--- REGISTRO DE NUEVA MASCOTA ---");

        if (listaTutores.isEmpty()) {
            System.out.println("[Aviso] No hay tutores registrados. Registre un tutor primero.");
            return;
        }

        System.out.println("Seleccione al tutor responsable:");
        for (int i = 0; i < listaTutores.size(); i++) {
            System.out.println((i + 1) + ". " + listaTutores.get(i).getNombre() + " (Tel: " + listaTutores.get(i).getTelefono() + ")");
        }

        System.out.print("\nNúmero del tutor: ");
        if (scanner.hasNextInt()) {
            int index = scanner.nextInt();
            scanner.nextLine();

            if (index >= 1 && index <= listaTutores.size()) {
                Tutor tutorSeleccionado = listaTutores.get(index - 1);
                Paciente mascota = new Paciente();

                System.out.print("Nombre de la mascota: ");
                mascota.setNombre(scanner.nextLine());
                System.out.print("Especie (Perro, Gato, etc.): ");
                mascota.setEspecie(scanner.nextLine());
                System.out.print("Raza: ");
                mascota.setRaza(scanner.nextLine());

                System.out.print("Peso (kg): ");
                mascota.setPeso(scanner.nextDouble());
                System.out.print("Edad (años): ");
                mascota.setEdad(scanner.nextInt());
                scanner.nextLine();

                mascota.setDuenio(tutorSeleccionado);
                tutorSeleccionado.agregarMascota(mascota);

                System.out.println("\n[Éxito] ¡" + mascota.getNombre() + " registrado(a) con éxito!");
            } else {
                System.out.println("\n[Error] Selección inválida.");
            }
        } else {
            System.out.println("\n[Error] Entrada no numérica.");
            scanner.next();
        }
    }

    private static void registrarConsulta() {
        System.out.println("\n--- REGISTRO DE CONSULTA E HISTORIA CLÍNICA ---");
        Paciente mascota = buscarMascota();
        if (mascota == null) return;

        Consulta consulta = new Consulta();

        System.out.print("Motivo de la visita: ");
        consulta.setMotivo(scanner.nextLine());

        System.out.print("Temperatura corporal (°C): ");
        consulta.setTemperatura(scanner.nextDouble());
        scanner.nextLine();

        System.out.println("\n--- DIAGNÓSTICO MÉDICO ---");
        System.out.print("¿Qué dice el veterinario (Observación / Diagnóstico)?: ");
        consulta.setDiagnosticoVeterinario(scanner.nextLine());

        System.out.println("\n--- RECETA / TRATAMIENTO ---");
        System.out.print("¿Qué medicamento se le deja (Fármaco, dosis, duración)?: ");
        consulta.setMedicamentosRecetados(scanner.nextLine());

        mascota.agregarConsulta(consulta);
        System.out.println("\n[Éxito] ¡Historia clínica actualizada para " + mascota.getNombre() + "!");
    }

    private static void facturarServicios() {
        System.out.println("\n--- CAJA Y FACTURACIÓN ---");
        Paciente mascota = buscarMascota();
        if (mascota == null) return;

        System.out.println("\nFacturando para la mascota: " + mascota.getNombre() + " (Tutor: " + mascota.getDuenio().getNombre() + ")");

        System.out.print("Costo de la Consulta Médica (Q): ");
        double costoConsulta = scanner.nextDouble();

        System.out.print("Costo de los Medicamentos / Productos (Q): ");
        double costoMedicamentos = scanner.nextDouble();
        scanner.nextLine();

        double total = costoConsulta + costoMedicamentos;

        System.out.println("\n================================================");
        System.out.println("              FACTURA VETERINARIA               ");
        System.out.println("==================================================");
        System.out.println(" Fecha: " + new java.util.Date());
        System.out.println(" Cliente: " + mascota.getDuenio().getNombre());
        System.out.println(" Paciente: " + mascota.getNombre() + " (" + mascota.getEspecie() + ")");
        System.out.println("--------------------------------------------------");
        System.out.printf(" * Consulta Médica..............: %.2f\n", costoConsulta);
        System.out.printf(" * Medicamentos / Insumos.......: %.2f\n", costoMedicamentos);
        System.out.println("--------------------------------------------------");
        System.out.printf(" TOTAL A PAGAR..................: %.2f\n", total);
        System.out.println("==================================================");
        System.out.println("¡Pago registrado y factura generada con éxito!");
    }

    private static void verExpediente() {
        System.out.println("\n--- CONSULTAR EXPEDIENTE CLÍNICO ---");
        Paciente mascota = buscarMascota();
        if (mascota == null) return;

        System.out.println("\n==================================================");
        System.out.println(" PACIENTE: " + mascota.getNombre() + " | Especie: " + mascota.getEspecie() + " (" + mascota.getRaza() + ")");
        System.out.println(" Datos: " + mascota.getPeso() + " kg | " + mascota.getEdad() + " años");
        System.out.println(" Tutor: " + mascota.getDuenio().getNombre() + " | Tel: " + mascota.getDuenio().getTelefono());
        System.out.println("--------------------------------------------------");
        System.out.println(" Historial Clínico (" + mascota.getHistorialMedico().size() + " registros):");

        if (mascota.getHistorialMedico().isEmpty()) {
            System.out.println("  (No hay consultas registradas)");
        } else {
            int num = 1;
            for (Consulta c : mascota.getHistorialMedico()) {
                System.out.println("\n  [Visita #" + (num++) + "] Fecha: " + c.getFecha());
                System.out.println("    - Motivo: " + c.getMotivo() + " (" + c.getTemperatura() + " °C)");
                System.out.println("    - Diagnóstico del Veterinario: " + c.getDiagnosticoVeterinario());
                System.out.println("    - Medicamento recetado: " + c.getMedicamentosRecetados());
            }
        }
        System.out.println("==================================================");
    }

    private static Paciente buscarMascota() {
        if (listaTutores.isEmpty()) {
            System.out.println("\n[Aviso] No hay tutores ni mascotas registrados.");
            return null;
        }

        System.out.print("Ingrese el nombre de la mascota: ");
        String nombreBuscado = scanner.nextLine();

        for (Tutor tutor : listaTutores) {
            for (Paciente mascota : tutor.getMascotas()) {
                if (mascota.getNombre().equalsIgnoreCase(nombreBuscado)) {
                    return mascota;
                }
            }
        }

        System.out.println("\n[Aviso] No se encontró ninguna mascota con ese nombre.");
        return null;
    }
}
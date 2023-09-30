using System;
class Programa {
    static void Main () {
        int Parciales = 3;
        Console.Write("¿Cuantos alumnos desea calificar?: ");
        int NAlumnos = int.Parse(Console.ReadLine()!);
        double[,] Alumnos = new double [NAlumnos,Parciales];
        string[] Calis = {"  0 - 4.9","5.0 - 5.9", "6.0 - 6.9","7.0 - 7.9","8.0 - 8.9","9.0 - 10 "};
        Random random = new ();

        Maestro gus = new();

        Console.WriteLine("___________________Promedio");
        for (int i = 0; i < NAlumnos; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < Parciales; j++)
            {
                double ran = random.NextDouble()*10;
                Alumnos[i,j] = ran+.01;
                Console.Write("{0} | ", Alumnos[i,j].ToString("0.0"));
            }
            Console.Write(gus.Promediar(Alumnos)[i,0].ToString("#.##"));
            Console.WriteLine();
        }
        Console.WriteLine("El promedio mayor es de: "+gus.PromediarMax().ToString("#.##"));
        Console.WriteLine("El promedio menor es de: "+gus.PromediarMin().ToString("#.##"));
        Console.WriteLine("Total de parciales reprobados: "+gus.ParcialesReprobados(Alumnos));
        Console.WriteLine("Distribución de las calificaciones: ");
        for (int i = 0; i < Calis.GetLength(0); i++)
        {
            Console.WriteLine(Calis[i]+":  "+gus.DistribuirCalis(Alumnos,Calis)[i]+" Alumnos");
        }
    }
}
public class Maestro {
    public double[,] Prom;
    public double[,] Promediar (double[,] Alumnos) {
        double[,] SumaFila = new double[Alumnos.GetLength(0),1];
        double[,] Promedio = new double[Alumnos.GetLength(0),1];
        for (int i = 0; i < Alumnos.GetLength(0); i++)
        {
            for (int j = 0; j < Alumnos.GetLength(1); j++)
            {
                SumaFila[i,0] += Alumnos[i,j];
            }
        }
        for (int i = 0; i < SumaFila.GetLength(0); i++)
        {
            for (int j = 0; j < SumaFila.GetLength(1); j++)
            {
                Promedio[i,0] = SumaFila[i,j]/Alumnos.GetLength(1);
            }
        }
        Prom = Promedio;
        return Promedio;
    }
    public double PromediarMax () {
        double Max = 0;
        for (int i = 0; i < Prom.GetLength(0); i++)
        {
            for (int j = 0; j < Prom.GetLength(1); j++)
            {
                if(Max < Prom[i,j]){
                    Max = Prom[i,j];
                }
            }
        }
        return Max;
    }
    public double PromediarMin () {
        double Min = Prom[0,0];
        for (int i = 0; i < Prom.GetLength(0); i++)
        {
            for (int j = 0; j < Prom.GetLength(1); j++)
            {
                if(Min > Prom[i,j]){
                    Min = Prom[i,j];
                }
            }
        }
        return Min;
    }
    public int ParcialesReprobados (double[,] Alumnos) {
        int ParcialesReprobados = 0;
        for (int i = 0; i < Alumnos.GetLength(0); i++)
        {
            for (int j = 0; j < Alumnos.GetLength(1); j++)
            {
                if (Alumnos[i,j] < 7) {
                    ParcialesReprobados++;
                }
            }
        }
        return ParcialesReprobados;
    }
    public int [] DistribuirCalis (double[,] Alumnos, string[] Calis) {
        int[] Distribucion = new int [Calis.GetLength(0)];
        for (int i = 0; i < Alumnos.GetLength(0); i++)
        {
            for (int j = 0; j < Alumnos.GetLength(1); j++)
            {
                if (Alumnos[i,j] <= 4.9) {
                    Distribucion[0]++;
                } else if (Alumnos[i,j] <= 5.9) {
                    Distribucion[1]++;
                } else if (Alumnos[i,j] <= 6.9) {
                    Distribucion[2]++;
                } else if (Alumnos[i,j] <= 7.9) {
                    Distribucion[3]++;
                } else if (Alumnos[i,j] <= 8.9) {
                    Distribucion[4]++;
                } else if (Alumnos[i,j] <= 10) {
                    Distribucion[5]++;
                }
            }
        }
        return Distribucion;
    }
}
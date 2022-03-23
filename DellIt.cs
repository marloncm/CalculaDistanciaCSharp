using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static int indexCidade(string cidadeEntrada)
    {
        using (var reader = new StreamReader(@"Distancias.csv"))
        {
            cidadeEntrada = cidadeEntrada.ToUpper();
            int achou = 0;
            int index = 0;
            int indexresultado = 0;
            var line = reader.ReadLine();
            var values = line.Split(';');
            foreach (var cidade in values)
            {
                if (cidade.ToString() == cidadeEntrada)
                {
                    achou = 1;
                    indexresultado = index;
                }

                index++;
            }
            if (achou == 0)
            {
                Console.WriteLine("cidade não encontrada");
                System.Environment.Exit(1);
            }
            return indexresultado;
        }
    }

    public static IList<string> getCidades()
    {
        using (var reader = new StreamReader(@"Distancias.csv"))
        {
            List<string> listaCidades = new List<string>();
            var line = reader.ReadLine();
            var values = line.Split(';');
            foreach (var cidade in values)
            {
                listaCidades.Add (cidade);
            }
            return listaCidades;
        }
    }

    public static int getDistancia(int size, int cidOrigem, int cidDestino)
    {
 
        int[,] array = new int[size, size];
        using (var reader = new StreamReader(@"Distancias.csv"))
        {
          var _line = reader.ReadLine();
            int i = 0;
            int distanciaResultado;
            while (!reader.EndOfStream)
            {
                int j = 0;
                var line = reader.ReadLine();
                var values = line.Split(';');
                foreach (var dist in values)
                {
                    array[i, j] = Convert.ToInt32(dist);
                    j++;
                }
                i++;
            }
            distanciaResultado = array[cidOrigem, cidDestino];
            return distanciaResultado;
        }
    }

    public static int distanciaEntreCidades(string cid1, string cid2)
    {
        int indexCidade1 = indexCidade(cid1);

        int indexCidade2 = indexCidade(cid2);

        IList<string> listaDeCidades = getCidades();
        int distancia =
            getDistancia(listaDeCidades.Count, indexCidade1, indexCidade2);
         
        return distancia;
    }

    public static void Main()
    {
        const double LITROS_POR_KM = 2.57;
        const int KM_POR_DIA = 283;
        bool exit = false;
        double custoKM = 0;
        bool custoKMSet = false;
      double custoT=0;
        do  
        {
            Console.WriteLine("1- Configura preco por km");
            Console.WriteLine("2- consulta trecho");
            Console.WriteLine("3- tem rota?");
            Console.WriteLine("4- vlw flw");

            Console.WriteLine("qual vai ser?");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    do{
                    Console.WriteLine("quale o custo pro km?");
                    custoKM = Convert.ToDouble(Console.ReadLine());
                    }while(custoKM <=0);
                    custoKMSet = true;

                    break;
                case 2:
                    if(custoKMSet == true)
                    {Console.WriteLine("Digite a cidade de origem");
                    string cidadeDeOrigem = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Digite a cidade de destino");
                    string cidadeDeDestino = Console.ReadLine();
                    
                    
                        
                    Console.WriteLine (distanciaEntreCidades(cidadeDeOrigem, cidadeDeDestino));
                    }
                    
                    return;
                    break;
                case 3:
                    Console.WriteLine("muitas cidades");
                    string cidades = Console.ReadLine();
                    IList<string> listaCidades = cidades.Split(',');
                    if (listaCidades.Count < 2)
                    {
                        
                    }
                    else
                    {
                    }
                    break;
                case 4:
                    Console.WriteLine("flw ze");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("digita direito seu merda");
                    break;
            }
        }
        while (!exit);
        Console.WriteLine("da onde vai?");
        string cidadeOrigem = Console.ReadLine();
        Console.WriteLine("pra onde vem?");
        string cidadeDestino = Console.ReadLine();
    }
}
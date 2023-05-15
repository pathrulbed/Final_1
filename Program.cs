using System;

class Program
{
    public struct City_temp
    {
        public string name;
        public int numberCity;
        public int level; 
        public void city(string name, int level, int numberCity) 
        {
            string Name = name;
            int Level = level;
            int NumberCity = numberCity;
        }
    }
    public struct City 
    {
        public string name;
        public int numberCity;
        public int level; 
        public void city(string name, int level, int numberCity) 
        {
            this.name = name;
            this.level = level;
            this.numberCity = numberCity;
        }

        public void DisplayCity()
        {
            Console.WriteLine("{0}  {1}  Level:{2}",numberCity, name, level);
        }

    }

    static void Main(string[] agrs)
    {
        Console.Clear();
        bool exit = false;
        bool loop = true;
        int choose_city = 0;
        int Amount_Connect = 0;
        int check = 0;
        Console.Write("Please Input Amount Of Cities: ");
        int AmountOfCities = int.Parse(Console.ReadLine());
        City[] cities = new City[AmountOfCities];
        int[] cities_temp = new int[AmountOfCities];
        int[][] City_all = new int[AmountOfCities][];
        for (int i = 0;i < (AmountOfCities);i++)
        {
            Console.Write("Name Of City: ");
            string name = Console.ReadLine();
           
            while (true)
                {
                    Console.Write("Please Input Amount Of Connect City: ");
                    int Amount_num = int.Parse(Console.ReadLine());
                    if (((Amount_num>=0)&&(Amount_num<AmountOfCities)))
                    {
                        Amount_Connect = Amount_num;
                        break;
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid Number");
                    }
                }
            cities[i].city(name,0,i);
            
            
            if (Amount_Connect==0)
            {
                City_all[i] = new int[0];
            }
            else
            {
                City_all[i] = new int[Amount_Connect];
                for (int k =0;k<Amount_Connect;k++)
                {
                    City_all[i][k]=-1;
                }
                for (int j=0;j<Amount_Connect;j++)
                {
                    check=0;
                    loop = true;
                    Console.Write("Connect City --> ");
                    while (loop)
                    {
                        
                        int connect_num = int.Parse(Console.ReadLine());
                        for (int c=0;c<Amount_Connect;c++)
                        {
                            if ((connect_num==City_all[i][c])||(connect_num<0)||(connect_num>AmountOfCities-1)||(connect_num==i))
                            {
                                Console.Write("Invalid ID");
                                loop = true;
                                check=0;
                                Console.WriteLine();
                                Console.Write("Connect City --> ");
                                break;
                            }
                            
                            else if (check>=Amount_Connect-1)
                            {
                                City_all[i][j]=connect_num;
                                loop = false;
                            }
                            check++;
                            
                        }
                        
                    }
                
                }   
        
            }
            
        }
        for (int i = 0;i < (AmountOfCities);i++)
                    {
                        cities[i].DisplayCity();
                    }
        while (exit==false)
        {
            Console.WriteLine("Choose Operation (“Outbreak”, “Vaccinate”, “Lockdown”, “Spread”, “Exit”)");
            string Choose = Console.ReadLine();
            for (int t =0;t<cities.Length;t++)
            {
                cities_temp[t] = cities[t].level;
            }
            switch(Choose)
            {
                case "Outbreak":
                    Console.WriteLine("Please Choose City");
                    choose_city = int.Parse(Console.ReadLine());
                    cities[choose_city].level+=2;
                    for (int i=0;i<(City_all[choose_city].Length);i++)
                    {
                        cities[City_all[choose_city][i]].level+=1;
                    }
                    for (int i = 0;i < (AmountOfCities);i++)
                    {
                        cities[i].DisplayCity();
                    }
                    
                break;
                case "Vaccinate":
                    Console.WriteLine("Please Choose City");
                    choose_city = int.Parse(Console.ReadLine());
                    cities[choose_city].level=0;
                    for (int i = 0;i < (AmountOfCities);i++)
                    {
                        cities[i].DisplayCity();
                    }
                break;
                case "Lockdown":
                    Console.WriteLine("Please Choose City");
                    choose_city = int.Parse(Console.ReadLine());
                    cities[choose_city].level-=1;
                    for (int i=0;i<(City_all[choose_city].Length);i++)
                    {
                        cities[City_all[choose_city][i]].level-=1;
                    }
                    for (int i = 0;i < (AmountOfCities);i++)
                    {
                        cities[i].DisplayCity();
                    }
                break;
                case "Spread":
                    for (int i=0;i<AmountOfCities;i++)
                    {
                        for (int j=0;j<(City_all[i].Length);j++)
                        {
                            if (cities[i].level < cities_temp[City_all[i][j]])
                            {
                                cities[i].level+=1;
                                break;
                            }
                        }
                    }
                    
                    for (int i = 0;i < (AmountOfCities);i++)
                    {
                        cities[i].DisplayCity();
                    }
                break;
                case "Exit":
                    exit = true;
                break;
                default:
                    Console.WriteLine("Invalid");
                break;
            }
            
        }
        
    }
}

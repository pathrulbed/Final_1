using System;

class Program
{
    public struct City 
    {
        public string name;
        public int Amount_num;
        public int NumberCity;
        public int level; 
        public void city(string name, int level, int NumberCity) 
        {
            this.name = name;
            this.level = level;
            this.NumberCity = NumberCity;
        }
        public void DisplayCity()
        {
            Console.WriteLine("City:"+ name);
            Console.WriteLine("Number   : " + NumberCity);
            Console.WriteLine("Level   : " + level);
            Console.WriteLine("\n");
        }

    }

    static void Main(string[] agrs)
    {
        bool exit = false;
        int choose_city = 0;
        int Amount_Connect = 0;
        Console.WriteLine("Please Input Amount Of Cities");
        int AmountOfCities = int.Parse(Console.ReadLine());
        City[] cities = new City[AmountOfCities];
        int[][] City_all = new int[AmountOfCities][];
        for (int i = 0;i < (AmountOfCities);i++)
        {
            Console.WriteLine("Please Input Name Of City");
            string name = Console.ReadLine();
           
            while (true)
                {
                    Console.WriteLine("Please Input Amount Of Connect City");
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
            for (int j=0;j<Amount_Connect;j++)
            {
                while (true)
                {
                    City_all[i] = new int[Amount_Connect];
                    Console.WriteLine("Please Input number Of Connect City");
                    int connect_num = int.Parse(Console.ReadLine());
                    if (((connect_num>=0)&&(connect_num<=AmountOfCities))&&(connect_num!=i))
                    {
                        for (int m =0;m<=AmountOfCities-1;m++)
                        {
                            if (City_all[i][m]!=connect_num)
                            {
                                City_all[i][j] = connect_num;
                            }
                            else
                            {
                                Console.WriteLine("Please Input number Of Connect City");
                                connect_num = int.Parse(Console.ReadLine());
                                City_all[i][j] = connect_num;
                            }
                        }
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID");
                    }
                }
            }
        
            }
            
        }

        while (exit==false)
        {
            Console.WriteLine("Choose Operation (“Outbreak”, “Vaccinate”, “Lockdown”, “Spread”)", "Exit");
            string Choose = Console.ReadLine();
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
                    
                break;
                case "Vaccinate":
                    Console.WriteLine("Please Choose City");
                    choose_city = 0;
                break;
                case "Lockdown":
                    Console.WriteLine("Please Choose City");
                    choose_city = int.Parse(Console.ReadLine());
                    cities[choose_city].level-=1;
                    for (int i=0;i<(City_all[choose_city].Length);i++)
                    {
                        cities[City_all[choose_city][i]].level-=1;
                    }
                break;
                case "Spread":
                    for (int i=0;i<(City_all[choose_city].Length);i++)
                    {
                        
                        cities[City_all[choose_city][i]].level+=1;
                    }
                break;
                case "Exit":
                    exit = true;
                break;
                default:
                    Console.WriteLine("Invalid");
                break;
            }
            for (int i = 0;i < (AmountOfCities);i++)
            {
                cities[i].DisplayCity();
            }
        }
        
        
        
        
        
        
        
        
        
        /*
        for (int i = 0;i < (AmountOfCities);i++)
        {
            cities[i].DisplayCity();
        }
        Console.WriteLine("Please Input Level Of Virus");
            int AmountOfVirus = int.Parse(Console.ReadLine());
        
        int[] box = {(cities[0].level), (cities[1].level)};
        for (int i=0;i<box.Length;i++)
        {
            cities[i].level+=AmountOfVirus;
        }
        for (int i = 0;i < (AmountOfCities);i++)
        {
            cities[i].DisplayCity();
        }*/
    }
}

using System;

namespace Kolcsonzo
{
	class Program
	{
		public static void Main(string[] args)
		{

			double egyenleg = 500000.0;

			double uzemanyagAr = 437.0; // Ft/liter

			KolcsonozhetoAuto[] flotta = new KolcsonozhetoAuto[10];

			KolcsonozhetoAuto elsoAuto =
				new KolcsonozhetoAuto("ABC-123", "Suzuki", 2020, 4, 40, 5.7, 'A');

			KolcsonozhetoAuto kettoAuto =
				new KolcsonozhetoAuto("BCD-234", "BMW", 2018, 2, 30, 3.7, 'A');

			KolcsonozhetoAuto haromAuto =
				new KolcsonozhetoAuto("CDE-345", "Toyota", 2021, 5, 36, 4.1, 'A');

			flotta[0] = elsoAuto;
			flotta[1] = kettoAuto;
			flotta[2] = haromAuto;


			flotta[3] = randomUjAuto(3);
			flotta[4] = randomUjAuto(4);

			flotta[5] = randomHasznaltAuto(5);
			flotta[6] = randomHasznaltAuto(6);

			flotta[7] = adatBekeres();  



			for (int i = 0; i <= 8; i++)
			{

				Console.Write(flotta[i].getRendszam() + " ; ");
				Console.Write(flotta[i].getGyarto() + " ; ");
				Console.Write(flotta[i].getGyartasEve() + " ; ");
				Console.Write(flotta[i].getUtasSzam() + " ; ");
				Console.Write(flotta[i].getuzemanyagMennyiseg() + " ; ");
				Console.Write(flotta[i].getFogyasztas() + " ; ");
				Console.Write(flotta[i].getMegtettKm() + " ; ");
				Console.Write(flotta[i].getBerelheto() + " ; ");
				Console.WriteLine(flotta[i].getKategoria());
			}
			Console.ReadKey();

            for (int i = 0; i < 8; i++)
            {
				flotta[i].kategoriaBeallitas();
            }

		}

		public static KolcsonozhetoAuto randomUjAuto(int seed)
		{

			Random gen = new Random(seed);

			string[] gyartok = {
				"Maserati",
				"Jeep",
				"Ferrari",
				"Suzuki",
				"Volvo",
				"Lada"
			};


			char[] abc = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
							'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W',
							'X', 'Y', 'Z'};

			string abcS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			string rszam = "";

			for (int i = 0; i < 3; i++)
			{

				rszam += abcS[gen.Next(0, abcS.Length)];
			}

			rszam = rszam + "-";

			for (int i = 0; i < 3; i++)
			{

				rszam += gen.Next(0, 10).ToString();
			}


			string marka = gyartok[gen.Next(0, gyartok.Length)];
			int ev = gen.Next(1995, 2022);
			int utasok = gen.Next(2, 10);
			int tartaly = gen.Next(20, 71);
			double lpkm = 5.5 + (11 * gen.NextDouble());
			char kat = abc[gen.Next(0, 3)];

			KolcsonozhetoAuto auto =
				new KolcsonozhetoAuto(rszam, marka, ev, utasok, tartaly, lpkm, kat);

			return auto;
		}

		public static KolcsonozhetoAuto randomHasznaltAuto(int seed)
        {
			KolcsonozhetoAuto auto = randomUjAuto(seed);
            {
				if(auto.getGyartasEve() ==2021)
                {
					auto.setGyartasiIdo(auto.getGyartasEve() -4);
                }

				auto.setMegtettKm(362000);


				return auto;
            }		      

        }

		public static KolcsonozhetoAuto adatBekeres()
        {
			/*string rszam, string marka, int ev, int utasok, int tartaly, double lpkm, char kat*/

			//rendszám ellenőrzés
			string rszam;
			bool joe = false;
			string ujrszam;
			do
			{
				do
				{
					Console.WriteLine("Add meg az autó rendszámát: ");
					Console.WriteLine("A rendszám formátuma: ABC-123");

					rszam = Console.ReadLine();
				} while (rszam.Length < 7);

				
				ujrszam = rszam.Substring(0, 3).ToUpper() + rszam.Substring(3, 4);

				int i = 0;
				while (ujrszam[i] >= 'A' && ujrszam[i] <= 'Z');
                {
					i++;

                }

				if (i >= 3) joe = true;

				if (ujrszam[3] != '-') joe = false;

				i = 4;
				while (ujrszam[i] >= '0' && ujrszam[i] <= '9') ;
				{
					i++;
				}

				if (i >= 7) joe = true;


			} while (joe);


			//gyártási év bekérése
			int gyev = 0;
			do
			{
				Console.WriteLine("Add meg az autó gyártási évét:");
				gyev = Convert.ToInt32(Console.ReadLine());

			} while (1999 > gyev || gyev >= 2021);

			//utasok száma
			int utsz = 0;
			do
			{

				Console.WriteLine("Add meg az utasok számát: ");
				utsz = Convert.ToInt32(Console.ReadLine());


			} while (1 > utsz || utsz >= 11);

			//tartály mérete
			int urt = 0;
			do
			{

				Console.WriteLine("Add meg a tank űrtartalmát: ");
				urt = Convert.ToInt32(Console.ReadLine());


			} while (28 > urt || urt >=85);

			//fogyasztás 100km-en
			double fogy = 0;
			do
			{

				Console.WriteLine("Add meg az autó fogyasztását 100km-en: ");
				fogy = Convert.ToDouble(Console.ReadLine());


			} while (3.8 > fogy || fogy >= 60.4);

			//kategória bekérése
			char kat = 'Z';
			do
			{

				Console.WriteLine("Add meg az autó kategóriáját: ");
				Console.WriteLine("Lehetséges érték: A; B; C");

				kat = (Console.ReadLine().ToUpper())[0];


			} while (kat !='A' && kat !='B' && kat !='C');

			//márka bekérés
			string gyarto;
			do
			{

				Console.WriteLine("Add meg az autó gyártóját: ");
				gyarto = Console.ReadLine();

			} while (gyarto.Length < 3);


			KolcsonozhetoAuto auto = new KolcsonozhetoAuto(ujrszam, gyarto , gyev , utsz , urt , fogy , kat );

			return auto;


		}
		

	}

}
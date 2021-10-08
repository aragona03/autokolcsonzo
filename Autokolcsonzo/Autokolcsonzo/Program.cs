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


			for (int i = 0; i <= 4; i++)
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
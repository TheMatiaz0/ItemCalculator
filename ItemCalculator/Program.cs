﻿using System;

namespace ItemCalculator
{
	class Program
	{
		private static int price;
		private static int itemQuantity;
		private static int howManyToSell;

		private static ConsoleColor DefaultColor { get; } = ConsoleColor.White;
		private static ConsoleColor InputColor { get; } = ConsoleColor.Green;
		private static ConsoleColor SpecialColor { get; } = ConsoleColor.Red;
		private static ConsoleColor FinalColor { get; } = ConsoleColor.Yellow;
		private static ConsoleColor CreditsColor { get; } = ConsoleColor.DarkGray;

		static void Main()
		{
			DisplayCredits();
			InputQuantityOfItems();
			InputPriceOfOne();
			InputHowMany();
			DisplayResult();
		}

		private static void DisplayCredits()
		{
			Console.ForegroundColor = creditsColor;
			Console.WriteLine(@"+----------------------------------------------------------+
|                                                          |
|     Program made by Mateusz 'TheMatiaz0' Kusionowicz     |
|    +-------------------------------------------------+   |
+----------------------------------------------------------+
");
			Console.Write("\n\n\n\n");
		}

		private static void InputQuantityOfItems ()
		{
			Console.ForegroundColor = defaultColor;
			Console.Write("Wprowadź liczbę itemów, która ma standardową cenę (o której wiesz jaka jest): ");
			Console.ForegroundColor = inputColor;
			itemQuantity = TryParseParse(() => InputQuantityOfItems());
			Console.ForegroundColor = defaultColor;
		}

		private static void InputPriceOfOne()
		{
			Console.Write($"Podaj cenę {itemQuantity} przedmiotów: ");
			Console.ForegroundColor = inputColor;
			price = TryParseParse(() => InputPriceOfOne());
			Console.ForegroundColor = defaultColor;
		}

		private static void InputHowMany ()
		{
			Console.Write("Ile przedmiotów chcesz sprzedać? ");
			Console.ForegroundColor = inputColor;
			howManyToSell = TryParseParse(() => InputHowMany());
			Console.ForegroundColor = defaultColor;
		}

		private static int TryParseParse (Action rewindAction)
		{
			if (!int.TryParse(Console.ReadLine(), out int result))
			{
				Console.Clear();
				rewindAction.Invoke();
			}

			return result;
		}


		private static void DisplayResult ()
		{
			Console.WriteLine($"Za {howManyToSell} itemów, jeśli {itemQuantity} sztuk po {price} to wychodzi:");
			int finalResult = howManyToSell * price / itemQuantity;
			Console.ForegroundColor = finalColor;
			Console.WriteLine($"{finalResult.ToString()}");
			Console.ForegroundColor = specialColor;
			Console.Write("\n\nNaciśnij jakikolwiek klawisz, aby wyjść, chyba że chcesz ponowić to wtedy kliknij 'R'.");
			Console.ForegroundColor = defaultColor;
			ConsoleKeyInfo keyInfo = Console.ReadKey();

			if (keyInfo.Key == ConsoleKey.R)
			{
				Console.Clear();
				Main();
			}

			else
			{
				Environment.Exit(0);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SFC_App
{
	public class Products
	{
		private int productID { get; };
		private int energy { get; };
		private int fat { get; };
		private int carbonhydrates { get; };
		private int sugar { get; };
		private int protein { get; };
		private int salts { get; };
		private int sodium { get; };

		private Char nutrientScore { get; };

		private String productName { get; };

		private bool isFavorite { get; set; };

		public Product(int ProductID, int Energy, int Fat, int Carbonhydrates, int Sugar, int Protein, int Salts, int Sodium, Char NutrientScore, String ProductName, bool IsFavorite)
		{
			productID = ProductID;
			energy = Energy;
			fat = Fat;
			carbonhydrates = Carbonhydrates;
			sugar = Sugar;
			protein = Protein;
			salts = Salts;
			sodium = Sodium;
			nutrientScore = NutrientScore;
			productName = ProductName;
			isFavorite = IsFavorite;
		}

		// If you click on the function to make it favorite then it checks if it already is favorite and removes or adds the favorite to the corresponding movement.
		public void MakeFavorite(bool IsFavorite)
		{
			if (IsFavorite)
			{
				isFavorite = false;
			}
			else
			{
				isFavorite = true;
			}
		}
	}
}



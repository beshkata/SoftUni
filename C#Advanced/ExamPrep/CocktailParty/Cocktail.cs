using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        //private List<Ingredient> ingredients;

        //public Cocktail(string name, int capacity, int maxAlcoholLevel)
        //{
        //    Name = name;
        //    Capacity = capacity;
        //    MaxAlcoholLevel = maxAlcoholLevel;
        //    ingredients = new List<Ingredient>(capacity);
        //}
        //public string Name { get; set; }
        //public int Capacity { get; set; }
        //public int MaxAlcoholLevel { get; set; }
        //public int CurrentAlcoholLevel { get { return GetAlcoholLevel(); } }
        //public void Add(Ingredient ingredient)
        //{
        //    int index = -1;
        //    for (int i = 0; i < ingredients.Count; i++)
        //    {
        //        if (ingredients[i].Name == ingredient.Name)
        //        {
        //            index = i;
        //            break;
        //        }
        //    }
        //    if (ingredients.Count < Capacity && ingredient.Alcohol + CurrentAlcoholLevel <= MaxAlcoholLevel)
        //    {
        //        ingredients.Add(ingredient);
        //    }
        //}

        //public bool Remove(string name)
        //{
        //    Ingredient ingredient = ingredients.FirstOrDefault(i => i.Name == name);
        //    if (ingredient == null)
        //    {
        //        return false;
        //    }
        //    ingredients.Remove(ingredient);
        //    return true;
        //}

        //public Ingredient FindIngredient(string name)
        //{
        //    Ingredient ingredient = ingredients.FirstOrDefault(i => i.Name == name);
        //    return ingredient;

        //}

        //public Ingredient GetMostAlcoholicIngredient()
        //{
        //    return ingredients.OrderByDescending(i=> i.Alcohol).FirstOrDefault();
        //}

        //private int GetAlcoholLevel()
        //{
        //    int alcoholLevel = 0;

        //    for (int i = 0; i < ingredients.Count; i++)
        //    {
        //        alcoholLevel += ingredients[i].Alcohol;
        //    }
        //    return alcoholLevel;
        //}

        //public string Report()
        //{
        //    //"Cocktail: {name} - Current Alcohol Level: {CurrentAlcoholLevel}
        //    //{ Ingredient1}
        //    //{ Ingredient2}
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}\n");

        //    foreach (var ingredient in ingredients)
        //    {
        //        sb.AppendLine(ingredient.ToString());

        //    }

        //    return sb.ToString();
        //}
        Dictionary<string, Ingredient> Ingredients = new Dictionary<string, Ingredient>();
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel { get; set; } = 0;

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.ContainsKey(ingredient.Name)
                && Ingredients.Count < Capacity
                && CurrentAlcoholLevel + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient.Name, ingredient);
                CurrentAlcoholLevel += ingredient.Alcohol;
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                CurrentAlcoholLevel -= Ingredients[name].Alcohol;
                Ingredients.Remove(name);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.ContainsKey(name))
            {
                return Ingredients[name];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholic = null;

            foreach (var item in Ingredients.OrderByDescending(i => i.Value.Alcohol))
            {
                mostAlcoholic = new Ingredient(item.Value.Name, item.Value.Alcohol, item.Value.Quantity);
                break;
            }

            return mostAlcoholic;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine($"Ingredient: {ingredient.Value.Name}");
                sb.AppendLine($"Quantity: {ingredient.Value.Quantity}");
                sb.AppendLine($"Alcohol: {ingredient.Value.Alcohol}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
 
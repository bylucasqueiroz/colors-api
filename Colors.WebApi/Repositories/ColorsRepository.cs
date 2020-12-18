using System.Collections.Generic;
using Colors.WebApi.Models;

namespace Colors.WebApi.Repositories
{
    public static class ColorsRepository
    {
        public static List<Color> Get()
        {
            var colors = new List<Color>();

            colors.Add(new Color { Id = 1, Name = "Red" });
            colors.Add(new Color { Id = 2, Name = "Black" });
            colors.Add(new Color { Id = 3, Name = "Pink" });
            colors.Add(new Color { Id = 4, Name = "Green" });
            colors.Add(new Color { Id = 5, Name = "Gray" });

            return colors;
        }
    }
}

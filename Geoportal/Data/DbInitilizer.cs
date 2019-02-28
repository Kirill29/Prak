using System;
using System.Linq;
using Geoportal.Models;
namespace Geoportal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PointContext context)
        {
            // проверяем на таблицу точек на пустоту
            if (context.Points.Any())
            {
                return;   // DB has been seeded
            }


            //создаем массив точек
            var points = new Point[]
            {
                new Point{X=55, Y = 37},
                new Point{X=34, Y = 36},
                new Point{X=23, Y = 67}

            };
           
            //записываем точки в базу данных
            foreach (Point p in points)
            {
                context.Points.Add(p);

            }

            //сохраняем результаты
            context.SaveChanges();
           


        }
    }
}

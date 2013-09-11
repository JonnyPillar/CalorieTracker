using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;
using System.Linq.Expressions;

namespace CalorieTracker.ViewModels
{
    public class PagedFoodList
    {
        public int TotalRows { get; set; }
        public IEnumerable<tbl_food_log> Customer { get; set; }
        public int PageSize { get; set; }
    }

    public static class SortExtension
    {
        public static IOrderedEnumerable<TSource> OrderByWithDirection<TSource, TKey>
            (this IEnumerable<TSource> source,
             Func<TSource, TKey> keySelector,
             bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                              : source.OrderBy(keySelector);
        }

        public static IOrderedQueryable<TSource> OrderByWithDirection<TSource, TKey>
            (this IQueryable<TSource> source,
             Expression<Func<TSource, TKey>> keySelector,
             bool descending)
        {
            return descending ? source.OrderByDescending(keySelector)
                              : source.OrderBy(keySelector);
        }
    }

    public class ModelServices : IDisposable
    {
        private readonly calorie_tracker_v1Entities entities = new calorie_tracker_v1Entities();

        //For Custom Paging
        public IEnumerable<tbl_food_log> GetFoodLogPage(int pageNumber, int pageSize, string sort, bool Dir)
        {
            if (pageNumber < 1)
                pageNumber = 1;

            if (sort == "food_name")
                return entities.tbl_food_log.OrderByWithDirection(x => x.tbl_food.food_name, Dir)
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToList();
            else if (sort == "food_log_quantity")
                return entities.tbl_food_log.OrderByWithDirection(x => x.food_log_quantity, Dir)
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToList();
            else if (sort == "food_calories")
                return entities.tbl_food_log.OrderByWithDirection(x => x.tbl_food.food_calories, Dir)
              .Skip((pageNumber - 1) * pageSize)
              .Take(pageSize)
              .ToList();
            else
            return entities.tbl_food_log.OrderByWithDirection(x => x.tbl_food.food_name, Dir)
         .Skip((pageNumber - 1) * pageSize)
         .Take(pageSize)
         .ToList();
        }

        public int CountCustomer()
        {
            return entities.tbl_food_log.Count();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}
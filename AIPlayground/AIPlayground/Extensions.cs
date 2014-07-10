using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIPlayground.Search.Algorithm;
using AIPlayground.Search.Problem.State;

namespace AIPlayground
{
    public static class Extensions
    {
        public static void Enqueue(this ObservableCollection<SearchNode> fringe, IEnumerable<SearchNode> nodes)
        {
            foreach (var searchNode in nodes)
            {
                fringe.Add(searchNode);   
            }
        }

        public static SearchNode Dequeue(this ObservableCollection<SearchNode> fringe)
        {
            return fringe.GetAndRemoveFirst();
        }

        public static T GetAndRemoveFirst<T>(this ObservableCollection<T> list)
        {
            if (list.Count() != 0)
            {
                var temp = list.First();
                list.RemoveAt(0);
                return temp;
            }
            return default(T);
        }
    }
}

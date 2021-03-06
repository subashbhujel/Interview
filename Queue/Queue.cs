﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPreparation.Queue
{
    class Queue
    {
        /// <summary>
        /// Minimum time required to rot all oranges
        /// Given a matrix of dimension m*n where each 
        /// cell in the matrix can have values 0, 1 or 2 which has the following meaning:
        /// 0: Empty cell
        /// 1: Cells have fresh oranges
        /// 2: Cells have rotten oranges 
        /// So we have to determine what is the minimum time required so that all the oranges 
        /// become rotten. A rotten orange at index [i,j] can rot other fresh orange at indexes 
        /// [i-1,j], [i+1,j], [i,j-1], [i,j+1] (up, down, left and right). If it is impossible 
        /// to rot every orange then simply return -1.
        /// Ref: http://www.geeksforgeeks.org/minimum-time-required-so-that-all-oranges-become-rotten/
        /// </summary>
        /// <param name="basket">Basket will have set of oranges</param>
        internal void MinimumTimeToRotOranges(int[,] basket)
        {

        }
    }
}

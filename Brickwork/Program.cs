using System;
using System.Collections.Generic;
using System.Linq;

namespace Brickwork
{
    class Program
    {
        static void Main(string[] args)
        {
            // defining the dimensions
            int[] dim = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            // defining the area for the first layer
            int[,] area = new int[dim[0], dim[1]];
            // validating the dimensions
            if (dim[0] %2 !=0 || dim[1] %2 != 0 || dim[0]>100 || dim[1]>100)
            {
                Console.WriteLine($"Dimensions need to be even number and less than 100");
                return;
            }
            //filling the area with "bricks"
            for (int i = 0; i < area.GetLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < area.GetLength(1); j++)
                {
                    area[i, j] = tokens[j];
                }

            }
            //defining new array for the second layer
            List<string> newArea = new List<string>();

            if (dim[0] * dim[1] <= 4)                  
            {
                Console.WriteLine($"Area too small");
            }
            //----------------------------------
            if (area.GetLength(1) == 2)
            {
                for (int i = 0; i < area.GetLength(0); i+=4)
                {
                    for (int j = 0; j < area.GetLength(1); j+=2)
                    {
                        if (area.GetLength(0)-i != 2 && area[i,j] == area[i+1,j] && area[i,j+1] == area[i+1,j+1] && area[i+2,j] != area[i+2,j+1])
                        {
                            // 3 1 | 2 2
                            // 3 1 | 3 1
                            // 4 2 | 3 1
                            // 4 2 | 4 4
                            if (area[i+1,j] != area[i+2,j] && area[i+1,j+1] != area[i+2,j+1])
                            {
                                newArea.Add($"|{area[i+2,j+1]} {area[i+3,j+1]}|");
                                newArea.Add($"|{area[i,j]}|{area[i,j+1]}|");
                                newArea.Add($"|{area[i,j]}|{area[i,j+1]}|");
                                newArea.Add($"|{area[i+2,j]} {area[i+3,j]}|");
                            }
                           else 
                           { 
                                Console.WriteLine("No solution exists!");
                                return;
                           } 
                           
                            
                        }
                        if (area.GetLength(0)-i != 2 &&area[i,j] == area[i,j+1] && area[i,j] != area[i+1,j] && area[i,j+1] != area[i+1,j+1] && area[i+1,j] != area[i+1,j+1])
                        {
                            // 2 2 | 3 1
                            // 3 1 | 3 1
                            // 3 1 | 4 2
                            // 4 4 | 4 2
                            if (area[i+1,j] == area[i+2,j] && area[i+1,j+1] == area[i+2,j+1] && area[i+3,j] == area[i+3,j+1])
                            {
                                newArea.Add($"|{area[i+1,j]}|{area[i+1,j+1]}|");
                                newArea.Add($"|{area[i+2,j]}|{area[i+2,j+1]}|");
                                newArea.Add($"|{area[i+3,j]}|{area[i,j]}|");
                                newArea.Add($"|{area[i+3,j+1]}|{area[i,j+1]}|");
                            }
                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            } 
                        }

                        if (area.GetLength(0)-i != 2 &&area[i,j] == area[i,j+1] && area[i+1,j] == area[i+1,j+1] && area[i+2,j] == area[i+2,j+1])
                        {
                            // 1 1 | 3 1
                            // 2 2 | 3 1
                            // 3 3 | 4 2
                            // 4 4 | 4 2
                            if (area[i+2,j] == area[i+2,j+1] && area[i+3,j] == area[i+3,j+1])
                            {
                                newArea.Add($"|{area[i+2,j]}|{area[i,j]}|");
                                newArea.Add($"|{area[i+2,j+1]}|{area[i,j+1]}|");
                                newArea.Add($"|{area[i+3,j]}|{area[i+1,j]}|");
                                newArea.Add($"|{area[i+3,j+1]}|{area[i+1,j+1]}|");

                            }
                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            } 
                        }

                        if (area.GetLength(0)-i != 2 &&area[i,j] == area[i+1,j] && area[i,j+1] == area[i+1,j+1] && area[i,j+1] != area[i+2,j] && area[i+1,j+1] != area[i+2,j+1])
                        {
                            // 4 1 | 1 1
                            // 4 1 | 2 2
                            // 2 2 | 4 3
                            // 3 3 | 4 3
                            if (area[i+2,j] == area[i+2,j+1] && area[i+3,j] == area[i+3,j+1])
                            {
                                newArea.Add($"|{area[i,j+1]}-{area[i+1,j+1]}|");
                                newArea.Add($"|{area[i+2, j]}-{area[i+2,j+1]}|");
                                newArea.Add($"|{area[i,j]}|{area[i+3,j]}|");
                                newArea.Add($"|{area[i+1,j]}|{area[i+3,j+1]}|");
                            }

                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            } 
                        }

                        if (area.GetLength(0)-i != 2 &&area[i,j] == area[i,j+1] && area[i+1,j] == area[i+1,j+1] && area[i+2,j] == area[i+3,j])
                        {
                            // 1 1 | 4 1
                            // 2 2 | 4 1
                            // 4 3 | 2 2
                            // 4 3 | 3 3
                            if (area[i+2,j+1] == area[i+3,j+1])
                            {
                                newArea.Add($"|{area[i+2,j]}|{area[i,j]}|");
                                newArea.Add($"|{area[i+3,j]}|{area[i,j+1]}|");
                                newArea.Add($"|{area[i+1,j]}-{area[i+1,j+1]}|");
                                newArea.Add($"|{area[i+2,j+1]}-{area[i+3,j+1]}|");                               
                            }
                            
                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            }
                        }
                        if (i>0 && (area.GetLength(0)-2) / i ==1)
                        {
                                if (area[i,j] == area[i,j+1] && area[i+1,j] == area[i+1,j+1])
                                {
                                    newArea.Add($"|{area[i,j]}|{area[i+1,j]}|");
                                    newArea.Add($"|{area[i,j]}|{area[i+1,j]}|");
                                    continue;
                                }

                                if (area[i,j] == area[i+1,j] && area[i,j+1] == area[i+1,j+1])
                                { 
                                    newArea.Add($"|{area[i,j]}-{area[i+1,j]}|");
                                    newArea.Add($"|{area[i,j+1]}-{area[i+1,j+1]}|");
                                    continue;
                                }

                                else
                                { 
                                    Console.WriteLine("No solution exists!");
                                    return;
                                }
                        }
                    }
                }
                Console.WriteLine("============================");
                int count = 0;
                while (count < area.GetLength(0))
                {
                    Console.Write($"{newArea[count]}\n");
                    count++;
                }
  
            }
            //-----------------------------------
            //looping the first layer to arrange the bricks for the second layer based on the requirements and validating solutions
            else
            {
                for (int i = 0; i < area.GetLength(0); i+=2)
                {
                    for (int j = 0; j < area.GetLength(1); j+=4)
                    {
                        if (area.GetLength(1) - j > 2 && area[i,j] == area[i,j+1] && area[i,j+2] == area[i,j+3])
                        {
                            // 1 1 2 2 | 2 1 1 4
                            // 3 3 4 4 | 2 3 3 4
                            if (area[i+1,j] == area[i+1,j+1] && area[i+1,j+2] == area[i+1,j+3])
                            {
                                newArea.Add($"|{area[i,j+2]}||{area[i,j]}-{area[i,j+1]}||{area[i+1,j+3]}|");
                                newArea.Add($"|{area[i,j+3]}||{area[i+1,j]}-{area[i+1,j+1]}||{area[i+1,j+2]}|");
                            }
                           else 
                           { 
                                Console.WriteLine("No solution exists!");
                                return;
                           } 
                           
                            
                        }
                        if (area.GetLength(1) - j > 2 && area[i,j] != area[i,j+1] && area[i,j+1] == area[i,j+2])
                        {
                            // 2 1 1 4 | 1 1 2 2
                            // 2 3 3 4 | 3 3 4 4
                            if (area[i,j] == area[i+1,j] && area[i+1,j+1] == area[i+1,j+2] && area[i,j+3] == area[i+1,j+3])
                            {
                                newArea.Add($"|{area[i,j+1]}-{area[i,j+2]}||{area[i,j]}-{area[i+1,j]}|");
                                newArea.Add($"|{area[i+1,j+1]}-{area[i+1,j+2]}||{area[i,j+3]}-{area[i+1,j+3]}|");
                            }
                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            } 
                        }

                        if (area.GetLength(1) - j > 2 && area[i,j] != area[i,j+1] && area[i,j+1] != area[i,j+2] && area[i,j+2] != area[i,j+3])
                        {
                            // 1 2 3 4 | 1 1 2 2
                            // 1 2 3 4 | 3 3 4 4
                            if (area[i,j] == area[i+1,j] && area[i,j+1] == area[i+1,j+1] && area[i,j+2] == area[i+1,j+2] && area[i,j+3] == area[i+1,j+3])
                            {
                                newArea.Add($"|{area[i, j]}-{area[i+1, j]}||{area[i, j+1]}-{area[i+1, j+1]}|");
                                newArea.Add($"|{area[i, j+2]}-{area[i+1, j+2]}||{area[i, j+3]}-{area[i+1, j+3]}|");

                            }
                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            } 
                        }

                        if (area.GetLength(1) - j > 2 && area[i,j] == area[i,j+1] && area[i,j+2] != area[i,j+3])
                        {
                            // 1 1 2 3 | 1 2 3 3
                            // 4 4 2 3 | 1 2 4 4
                            if (area[i+1,j] == area[i+1,j+1] && area[i,j+2] == area[i+1,j+2] && area[i,j+3] == area[i+1,j+3])
                            {
                                newArea.Add($"|{area[i, j]}||{area[i, j+2]}||{area[i, j+3]}-{area[i+1, j+3]}|");
                                newArea.Add($"|{area[i, j+1]}||{area[i+1, j+2]}||{area[i+1, j]}-{area[i+1, j+1]}|");
                            }

                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            } 
                        }

                        if (area.GetLength(1) - j > 2 && area[i,j] != area[i,j+1] && area[i,j+2] == area[i,j+3])
                        {
                            // 1 2 3 3 | 1 1 2 3
                            // 1 2 4 4 | 4 4 2 3
                            if (area[i,j] == area[i+1,j] && area[i,j+1] == area[i+1,j+1] && area[i+1,j+2] == area[i+1,j+3])
                            {
                                newArea.Add($"|{area[i,j]}-{area[i+1, j]}||{area[i, j+1]}||{area[i, j+2]}|");
                                newArea.Add($"|{area[i+1, j+2]}-{area[i+1, j+3]}||{area[i+1, j+1]}||{area[i, j+3]}|");
                            }
                            
                            else 
                            { 
                                Console.WriteLine("No solution exists!");
                                return;
                            }
                        }

                        if (area.GetLength(1) % 4 !=0 && area.GetLength(1) - j == 2)
                        {
                                if (area[i,j] == area[i,j+1] && area[i+1,j] == area[i+1,j+1])
                                {
                                    newArea.Add($"|{area[i,j]}|{area[i+1,j]}|");
                                    newArea.Add($"|{area[i,j]}|{area[i+1,j]}|");
                                    continue;
                                }

                                if (area[i,j] == area[i+1,j] && area[i,j+1] == area[i+1,j+1])
                                { 
                                    newArea.Add($"|{area[i,j]}-{area[i+1,j]}|");
                                    newArea.Add($"|{area[i,j+1]}-{area[i+1,j+1]}|");
                                    continue;
                                }

                                else
                                { 
                                    Console.WriteLine("No solution exists!");
                                    return;
                                }
                        }
                    }
                  
                }
                Console.WriteLine("============================");
                //generating the output 
               int count = 0;

                if (area.GetLength(0) == 2 && area.GetLength(1) > 4)
                {
                    for (count = 0; count < area.GetLength(1) / 4; count++)
                    {
                        if (area.GetLength(1) % 4 != 0 && area.GetLength(1) - (count + 1) * 4 == 2)
                        {
                            Console.Write($"{newArea[count * 2]}{newArea[count * 2 + 2]}");
                        }
                        else Console.Write($"{newArea[count * 2]}");
                    }
                    Console.WriteLine();

                    for (count = 1; count <= area.GetLength(1) / 4; count++)
                    {
                        if (area.GetLength(1) % 4 != 0 && area.GetLength(1) - count * 4 == 2)
                        {
                            Console.Write($"{newArea[count * 2 - 1]}{newArea[count * 2 + 1]}");
                        }
                        else Console.Write($"{newArea[count * 2 - 1]}");
                    }

                }
                if (area.GetLength(0) > 2 && area.GetLength(1) == 4)
                {
                    for (count = 0; count < area.GetLength(0); count++)
                    {
                        Console.Write($"{newArea[count]}\n");
                    }
                }
                if (area.GetLength(0) > 2 && area.GetLength(1) > 4)
                {
                    for (int i = 0; i < area.GetLength(0) / 2; i++)
                    {
                        if (i > 0)
                        {
                            for (count = i * 2; count < area.GetLength(1) / 2 * i; count++)
                            {
                                if (area.GetLength(1) % 4 != 0 && area.GetLength(1) - (count - 1) * 4 == 2)
                                {
                                    Console.Write($"{newArea[count * 2]}{newArea[count * 2 + 2]}");
                                }
                                else Console.Write($"{newArea[count * 2]}");
                            }
                            Console.WriteLine();

                            for (count = i * 2 + 1; count <= area.GetLength(1) / 2 * i; count++)
                            {
                                if (area.GetLength(1) % 4 != 0 && area.GetLength(1) - (count - 2) * 4 == 2)
                                {
                                    Console.Write($"{newArea[count * 2 - 1]}{newArea[count * 2 + 1]}");
                                }
                                else Console.Write($"{newArea[count * 2 - 1]}");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            for (count = 0; count < area.GetLength(1) / 4; count++)
                            {
                                if (area.GetLength(1) % 4 != 0 && area.GetLength(1) - (count + 1) * 4 == 2)
                                {
                                    Console.Write($"{newArea[count * 2]}{newArea[count * 2 + 2]}");
                                }
                                else Console.Write($"{newArea[count * 2]}");
                            }
                            Console.WriteLine();

                            for (count = 1; count <= area.GetLength(1) / 4; count++)
                            {
                                if (area.GetLength(1) % 4 != 0 && area.GetLength(1) - count * 4 == 2)
                                {
                                    Console.Write($"{newArea[count * 2 - 1]}{newArea[count * 2 + 1]}");
                                }
                                else Console.Write($"{newArea[count * 2 - 1]}");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                if (area.GetLength(0) == 2 && area.GetLength(1) == 4)
                {
                    Console.Write($"{newArea[count]}\n");
                    Console.Write($"{newArea[count + 1]}");

                }
            }

        }
    }
}

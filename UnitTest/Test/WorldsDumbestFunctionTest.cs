using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Test
{
    public static class WorldsDumbestFunctionTest
    {
        public  static void WorldsDumbestFunction_returnsPikachuIfZero_ReturnString()
        {
            try
            {
                int num = 0;
                var worldsDumbestFunction = new WorldsDumbestFunction();

                string result = worldsDumbestFunction.ReturnsPikachuIfZero(num);

                if (result=="pikachu!".ToUpper())
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction_returnsPikachuIfZero_ReturnString ");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction_returnsPikachuIfZero_ReturnString ");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

    }
}

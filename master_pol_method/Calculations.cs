using master_pol.Config;
using System;

namespace master_pol_method
{
    public class Calculations
    {
        public int CalcMaterials(int idTypeProduct, int idTypeMaterial, int countProduct, double param1, double param2)
        {
            DataContext Contex = new DataContext();
            try
            {
                double defectRate = Contex.typeMaterials.Find(idTypeMaterial).defectRate;
                double coef = Contex.typeProducts.Find(idTypeProduct).coefficient;
                return (int)Math.Ceiling(param1 * param2 * coef * countProduct * (1.0 + defectRate));
            }
            catch
            {
                return -1;
            }
        }
    }
}

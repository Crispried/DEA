using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEA
{
    class DEA
    {
        private static DEA dea;
        private DEA()
        {
        }

        public static DEA GetDEA()
        {
            if(dea == null)
            {
                dea = new DEA();
            }
            return dea;
        }
        public void AddProject(Project project)
        {
            ProjectContainer.Projects.Add(project);
        }
        /* #region pozitivnum est maximum
         public static decimal PokazatelEffektivnostiTovarnoiPolitiki(decimal tovaroOborot, decimal vutratuNaZbyt)
         {
             return tovaroOborot / vutratuNaZbyt;
         }
         public static decimal PokazatelEffektivnostiCenovoiPolitiki(decimal finansovuiRezultat, decimal vutratuKooperativa)
         {
             return finansovuiRezultat / vutratuKooperativa;
         }
         public static decimal IndexTovarooborota(decimal tekyshiiObjem, decimal predudyshiiObjem)
         {
             return tekyshiiObjem / predudyshiiObjem;
         }
         public static decimal IndexVutratKooperativa(decimal predudyshieVutratu, decimal tekyshieVutratu)
         {
             return predudyshieVutratu / tekyshieVutratu;
         }
         #endregion
         #region pozitivnum est minimum
         public static decimal PokazatelEffektivnostiZbytovoiPolitiki(decimal vutratuNaZbyt, decimal vurychkaOtRealizacii)
         {
             return vutratuNaZbyt / vurychkaOtRealizacii;
         }
         public static decimal PokazatelEffektivnostiKommynikacionoiPolitiki(decimal marketingovueZatratu, decimal vurychkaOtRealizaciiProdykciiRabotUslyg)
         {
             return marketingovueZatratu / vurychkaOtRealizaciiProdykciiRabotUslyg;
         }
         #endregion
         public static decimal RunochnayaChast(decimal objemProdajCherezKooperativ, decimal objemProdajCherezRunok)
         {
             return objemProdajCherezKooperativ / objemProdajCherezRunok;
         }*/
    }
}

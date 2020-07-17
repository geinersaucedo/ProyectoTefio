using System;
using System.Collections.Generic;
using System.Text;

using Tefio.Data;
using Tefio.Entity.Entity;
using Tefio.Entity.Model;
using Tefio.Core.Utilitario;
using Tefio.Core.Constant;

namespace Tefio.Service
{
    public class CategoriaService
    {
        public Result ListarCategoriasByIdBodega(String IdBodega)
        {
            CategoriaData categoriaData = new CategoriaData();
            var result = new Result();
            try
            {
                List<Categoria> categorias = new List<Categoria>();
                categorias = (List<Categoria>)categoriaData.ListarCategoriasByIdBodega(IdBodega);
                if (categorias.Count==0)
                {
                    result.setError(ResultTable.RESULT_ERR_CATEGORIAS_NO_CATEGORIAS_CODE);
                    result.Data = String.Empty;
                }
                result.Data = categorias;
            }
            catch (Exception ex)
            {
                result.setError(ResultTable.RESULT_ERR_GENERIC_CODE,
                ResultTable.RESULT_ERR_GENERIC_MSG,
                ex.Message);
            }
            return result;
        }
    }
}
